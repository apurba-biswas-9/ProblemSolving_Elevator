using System;
using System.Collections.Generic;
using System.Text;

namespace Elevator
{
    public abstract class BaseElevator
    {
        public abstract void Update(Request request, bool[] floorPresed);
    }
}
