using System;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Utilities.Messages;

namespace BookingApp.Models.Rooms
{
    public abstract class Room : IRoom
    {
        private double pricePerNight;
        
        protected Room(int bedCapacity)
        {
            this.BedCapacity = bedCapacity;
            this.PricePerNight = 0;
        }
        
        public int BedCapacity { get; }

        public double PricePerNight
        {
            get { return this.pricePerNight; }
            private set
            {
                if (value < 0) throw new ArgumentException(ExceptionMessages.PricePerNightNegative);
                this.pricePerNight = value;
            }
        }

        public void SetPrice(double price) => this.PricePerNight = price;
    }
}