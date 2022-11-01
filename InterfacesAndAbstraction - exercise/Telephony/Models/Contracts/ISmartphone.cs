using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony.Models.Contracts
{
    public interface ISmartphone
    {
        public void Call(string number);
        public void Browse(string website);
    }
}
