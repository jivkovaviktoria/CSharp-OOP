using FrontDeskApp;
using NUnit.Framework;
using System;

namespace BookigApp.Tests
{
    public class Tests
    {
        private Room room;
        private Hotel hotel;
        private Booking booking;
        
        [SetUp]
        public void Setup()
        {
            room = new Room(1, 10);
            hotel = new Hotel("hotel", 2);
            booking = new Booking(10, room, 1);
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        //Room tests
        [Test]
        public void TestRoomConstructor()
        {
            Assert.AreEqual(1, room.BedCapacity);
            Assert.AreEqual(10, room.PricePerNight);
        }

        [Test]
        public void BedCapacityShouldThrowExceptionIfValueIsZeroOrNegative()
        {
            Assert.Throws<ArgumentException>(() => room = new Room(-1, 10));
            Assert.Throws<ArgumentException>(() => room = new Room(0, 10));
        }

        [Test]
        public void PricePerNightCanBeSet()
        {
            room.PricePerNight = 50;
            Assert.AreEqual(50, room.PricePerNight);
        }

        [Test]
        public void PricePerNightShouldThrowExceptionIfValueIsZeroOrNegative()
        {
            Assert.Throws<ArgumentException>(() => room.PricePerNight = -1);
            Assert.Throws<ArgumentException>(() => room.PricePerNight = 0);
        }
        
        //Hotel tests

        [Test]
        public void TestHotelConstructor()
        {
            Assert.AreEqual("hotel", hotel.FullName);
            Assert.AreEqual(2, hotel.Category);
            Assert.AreEqual(0, hotel.Bookings.Count);
            Assert.AreEqual(0, hotel.Rooms.Count);
        }

        [Test]
        public void FullNameShouldThrowExceptionIfValueIsNullOrWhitespace()
        {
            Assert.Throws<ArgumentNullException>(() => hotel = new Hotel(" ", 4));
            Assert.Throws<ArgumentNullException>(() => hotel = new Hotel(null, 4));
        }

        [Test]
        public void CategoryShouldThrowExceptionIfItIsNotBetweenOneAndFive()
        {
            Assert.Throws<ArgumentException>(() => hotel = new Hotel("a", 0));
            Assert.Throws<ArgumentException>(() => hotel = new Hotel("a", 6));
            Assert.DoesNotThrow(() => hotel = new Hotel("a", 1));
            Assert.DoesNotThrow(() => hotel = new Hotel("a", 2));
            Assert.DoesNotThrow(() => hotel = new Hotel("a", 3));
            Assert.DoesNotThrow(() => hotel = new Hotel("a", 4));
            Assert.DoesNotThrow(() => hotel = new Hotel("a", 5));
        }

        [Test]
        public void AddRoomShouldWorkCorrectly()
        {
            hotel.AddRoom(room);
            Assert.AreEqual(1, this.hotel.Rooms.Count);
        }

        [Test]
        public void BookRoomShouldThrowExceptionIfAdultCountIsZeroOrNegative()
        {
            Assert.Throws<ArgumentException>(() => this.hotel.BookRoom(0, 0, 1, 10));
            Assert.Throws<ArgumentException>(() => this.hotel.BookRoom(-1, 0, 1, 10));
        }

        [Test]
        public void BookRoomShouldThrowExceptionIfChildrenCountIsNegative()
        {
            Assert.Throws<ArgumentException>(() => this.hotel.BookRoom(1, -1, 1, 10));
        }

        [Test]
        public void BookRoomShouldThrowExceptionIfDurationIsNegative()
        {
            Assert.Throws<ArgumentException>(() => this.hotel.BookRoom(1, 0, -1, 10));
        }

        [Test]
        public void BookRoomShouldWorkCorrectly()
        {
            hotel.AddRoom(room);
            hotel.BookRoom(1, 0, 1, 5000);
            
            Assert.AreEqual(1, hotel.Bookings.Count);
        }

        [Test]
        public void TurnoverShouldWorkCorrectly()
        {
            hotel.AddRoom(room);
            hotel.BookRoom(1, 0, 1, 5000);
            
            Assert.AreEqual(10, hotel.Turnover);
        }

        [Test]
        public void TestBookingConstructor()
        {
            Assert.AreEqual(10, booking.BookingNumber);
            Assert.AreEqual(1, booking.ResidenceDuration);
            Assert.AreEqual(room, booking.Room);
        }
        
    }
}