using System;
using System.Collections.Generic;
using System.Text;

namespace Cars.Models.Contracts
{
    public interface ICar
    {
        string Model { get; }
        string Color { get; }

        string Start();
        string Stop();
    }
}
