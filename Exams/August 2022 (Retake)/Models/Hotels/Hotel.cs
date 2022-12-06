using System;
using System.Linq;
using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Hotels.Contacts;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories;
using BookingApp.Repositories.Contracts;
using BookingApp.Utilities.Messages;

namespace BookingApp.Models.Hotels
{
    public class Hotel : IHotel
    {
        public Hotel(string fullName, int category)
        {
            if (string.IsNullOrWhiteSpace(fullName)) throw new ArgumentException(ExceptionMessages.HotelNameNullOrEmpty);
            if (category < 1 || category > 5) throw new ArgumentException(ExceptionMessages.InvalidCategory);

            this.FullName = fullName;
            this.Category = category;
            this.Rooms = new RoomRepository();
            this.Bookings = new BookingRepository();
        }
        public string FullName { get; }
        public int Category { get; }
        public double Turnover => this.Bookings.All().Sum(x => x.ResidenceDuration * x.Room.PricePerNight);
        public IRepository<IRoom> Rooms { get; }
        public IRepository<IBooking> Bookings { get; }
    }
}