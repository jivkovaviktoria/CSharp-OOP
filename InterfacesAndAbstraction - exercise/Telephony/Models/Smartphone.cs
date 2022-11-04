using System;
using System.Collections.Generic;
using System.Text;
using Telephony.Models.Contracts;

namespace Telephony.Models
{
    public class Smartphone : ISmartphone
    {
        public void Browse(string website)
        {
            Console.WriteLine($"Browsing: {website}!");
        }

        public void Call(string number)
        {
            Console.WriteLine($"Calling... {number}");
        }
    }
}
