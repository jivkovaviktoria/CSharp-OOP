using System;

namespace BirthdayCelebration.Models
{
    public interface IBirthable
    {
        public DateTime Birthday { get; }
        public string GetYear();
    }
}