using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BookingApp.Core.Contracts;
using BookingApp.Models.Bookings;
using BookingApp.Models.Hotels;
using BookingApp.Models.Hotels.Contacts;
using BookingApp.Models.Rooms;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories;
using BookingApp.Utilities.Messages;

namespace BookingApp.Core
{
    public class Controller : IController
    {
        private HotelRepository hotels = new HotelRepository();
        public string AddHotel(string hotelName, int category)
        {
            if (this.hotels.Select(hotelName) != null)
                return string.Format(OutputMessages.HotelAlreadyRegistered, hotelName);
            
            this.hotels.AddNew(new Hotel(hotelName, category));
            return string.Format(OutputMessages.HotelSuccessfullyRegistered, category, hotelName);
        }

        public string UploadRoomTypes(string hotelName, string roomTypeName)
        {
            var hotel = this.hotels.Select(hotelName);

            if (hotel == null) return string.Format(OutputMessages.HotelNameInvalid, hotelName);
            if (hotel.Rooms.All().FirstOrDefault(x => x.GetType().Name == roomTypeName) != null)
                return OutputMessages.RoomTypeAlreadyCreated;

            IRoom room;
            if (roomTypeName == nameof(DoubleBed)) room = new DoubleBed();
            else if (roomTypeName == nameof(Studio)) room = new Studio();
            else if (roomTypeName == nameof(Apartment)) room = new Apartment();
            else throw new ArgumentException(ExceptionMessages.RoomTypeIncorrect);
            
            hotel.Rooms.AddNew(room);
            return string.Format(OutputMessages.RoomTypeAdded, roomTypeName, hotelName);
        }

        public string SetRoomPrices(string hotelName, string roomTypeName, double price)
        {
            if (hotels.All().All(x => x.FullName != hotelName))
                return String.Format(OutputMessages.HotelNameInvalid, hotelName);

            if (!new string[] { "Apartment", "DoubleBed", "Studio" }.Contains(roomTypeName))
                throw new ArgumentException(ExceptionMessages.RoomTypeIncorrect);

            IHotel hotel = hotels.All().First(x => x.FullName == hotelName);
            if (hotel.Rooms.All().All(x => x.GetType().Name != roomTypeName))
                return OutputMessages.RoomTypeNotCreated;

            IRoom room = hotel.Rooms.All().First(x => x.GetType().Name == roomTypeName);
            if (room.PricePerNight != 0)
                throw new InvalidOperationException(ExceptionMessages.PriceAlreadySet);

            room.SetPrice(price);
            return string.Format(OutputMessages.PriceSetSuccessfully, roomTypeName, hotelName);
        }

        public string BookAvailableRoom(int adults, int children, int duration, int category)
        {
            var hotel = this.hotels.All().FirstOrDefault(x => x.Category == category);
            
            if (hotel == null)
                return string.Format(OutputMessages.CategoryInvalid, category);

            var test = this.hotels.Models.OrderBy(x => x.FullName).SelectMany(x => x.Rooms.All());
            var room = this.hotels.Models.OrderBy(x => x.FullName).SelectMany(x => x.Rooms.All())
                .Where(x => x.PricePerNight > 0).OrderBy(x => x.BedCapacity)
                .FirstOrDefault(x => x.BedCapacity >= adults + children);

            if (room == null) return string.Format(OutputMessages.RoomNotAppropriate);

            var bn = hotel.Bookings.All().Count + 1;
            
            var booking = new Booking(room, duration, adults, children, bn);
            hotel.Bookings.AddNew(booking);
            
            return string.Format(OutputMessages.BookingSuccessful, bn, hotel.FullName);
        }

        public string HotelReport(string hotelName)
        {
            IHotel hotel = hotels.Select(hotelName);
            if (hotel == null) return string.Format(OutputMessages.HotelNameInvalid, hotelName);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Hotel name: {hotel.FullName}");
            sb.AppendLine($"--{hotel.Category} star hotel");
            sb.AppendLine($"--Turnover: {hotel.Turnover:F2} $");
            sb.AppendLine($"--Bookings:");
            sb.AppendLine();

            if (hotel.Bookings.All().Count == 0) sb.Append("none");
            else foreach (var booking in hotel.Bookings.All()) sb.AppendLine(booking.BookingSummary());

            return sb.ToString().TrimEnd();
        }
    }
}