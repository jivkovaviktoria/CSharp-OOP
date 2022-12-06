using System.Collections.Generic;
using System.Linq;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories.Contracts;

namespace BookingApp.Repositories
{
    public class RoomRepository : IRepository<IRoom>
    {
        private readonly List<IRoom> models = new List<IRoom>();
        public IReadOnlyCollection<IRoom> Models => this.models.AsReadOnly();

        public void AddNew(IRoom model) => this.models.Add(model);

        public IRoom Select(string criteria) => this.models.FirstOrDefault(x => x.GetType().Name == criteria);

        public IReadOnlyCollection<IRoom> All() => this.models.AsReadOnly();
    }
}