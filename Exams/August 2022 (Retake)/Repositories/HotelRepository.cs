using System.Collections.Generic;
using System.Linq;
using BookingApp.Models.Hotels.Contacts;
using BookingApp.Repositories.Contracts;

namespace BookingApp.Repositories
{
    public class HotelRepository : IRepository<IHotel>
    {
        private readonly List<IHotel> models = new List<IHotel>();
        public IReadOnlyCollection<IHotel> Models => this.models.AsReadOnly();

        public void AddNew(IHotel model) => this.models.Add(model);

        public IHotel Select(string criteria) => this.models.FirstOrDefault(x => x.FullName == criteria);

        public IReadOnlyCollection<IHotel> All() => this.models.AsReadOnly();
    }
}