using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony.Models.Contracts
{
    public interface IStationaryPhone
    {
        public void Call(string number);
    }
}
