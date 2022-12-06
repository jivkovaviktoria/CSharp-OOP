using System;
using System.Text;
using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Utilities.Messages;

namespace BookingApp.Models.Bookings
{
    public class Booking : IBooking
    {
        public Booking(IRoom room, int residenceDuration, int adultsCount, int childrenCount, int bookingNumber)
        {
            if (residenceDuration < 1) throw new ArgumentException(ExceptionMessages.DurationZeroOrLess);
            if (adultsCount < 1) throw new ArgumentException(ExceptionMessages.AdultsZeroOrLess);
            if (childrenCount < 0) throw new ArgumentException(ExceptionMessages.ChildrenNegative);

            this.Room = room;
            this.ResidenceDuration = residenceDuration;
            this.AdultsCount = adultsCount;
            this.ChildrenCount = childrenCount;
            this.BookingNumber = bookingNumber;
        }
        public IRoom Room { get; }
        public int ResidenceDuration { get; }
        public int AdultsCount { get; }
        public int ChildrenCount { get; }
        public int BookingNumber { get; }
        
        public string BookingSummary()
        {
            var totalPaid = Math.Round(ResidenceDuration * this.Room.PricePerNight, 2);
            
            var sb = new StringBuilder();

            sb.AppendLine($"Booking number: {this.BookingNumber}");
            sb.AppendLine($"Room type: {this.Room.GetType().Name}");
            sb.AppendLine($"Adults: {this.AdultsCount} Children: {this.ChildrenCount}");
            sb.AppendLine($"Total amount paid: {totalPaid:f2} $");

            return sb.ToString().TrimEnd();
        }
    }
}