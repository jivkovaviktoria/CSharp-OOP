using System;
using System.Collections.Generic;
using System.Text;

namespace CustomRandomList
{
    public class RandomList : List<string>
    {
        public string RandomString()
        {
            Random random = new Random();
            int n = random.Next(0, Count);

            string s = base[n];
            base.RemoveAt(n);
            return s;
        }
    }
}
