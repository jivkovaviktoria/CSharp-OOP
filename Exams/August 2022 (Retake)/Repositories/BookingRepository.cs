using System.Collections.Generic;
using System.Linq;
using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories.Contracts;

namespace BookingApp.Repositories
{
    public class BookingRepository : IRepository<IBooking>
    {
        private readonly List<IBooking> models = new List<IBooking>();
        public IReadOnlyCollection<IBooking> Models => this.models.AsReadOnly();

        public void AddNew(IBooking model) => this.models.Add(model);

        public IBooking Select(string criteria) => this.models.FirstOrDefault(x => x.BookingNumber.ToString() == criteria);

        public IReadOnlyCollection<IBooking> All() => this.models.AsReadOnly();
    }
}