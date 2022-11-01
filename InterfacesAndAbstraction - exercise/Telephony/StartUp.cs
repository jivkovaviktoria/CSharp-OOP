using System;
using Telephony.Models;

namespace Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var smathphone = new Smartphone();
            var stationaryPhone = new StationaryPhone();

            var numbers = Console.ReadLine().Split();
            var urls = Console.ReadLine().Split();

            foreach(var number in numbers)
            {
                if (!IsValidNumber(number)) Console.WriteLine("Invalid number!");
                else if (number.Length == 10) smathphone.Call(number);
                else stationaryPhone.Call(number);
            }

            foreach(var url in urls)
            {
                if (!IsValidUrl(url)) Console.WriteLine("Invalid URL!");
                else smathphone.Browse(url);
            }
        }

        public static bool IsValidNumber(string s) 
        {
            foreach (char c in s) 
            { 
                if (!char.IsDigit(c)) return false;
            }
            
            return true;
        }

        public static bool IsValidUrl(string s)
        {
            foreach(char c in s)
            {
                if (char.IsDigit(c)) return false;
            }

            return true;
        }
    }
}
