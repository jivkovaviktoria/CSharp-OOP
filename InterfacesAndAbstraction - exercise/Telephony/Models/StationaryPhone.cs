using System;
using System.Collections.Generic;
using System.Text;
using Telephony.Models.Contracts;

namespace Telephony.Models
{
    public class StationaryPhone : IStationaryPhone
    {
        public void Call(string number)
        {
            Console.WriteLine($"Dialing... {number}");
        }
    }
}
