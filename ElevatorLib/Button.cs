using System;
using System.Collections.Generic;
using System.Text;

namespace Elevator
{
    public abstract class Button
    {
        public readonly Direction Direction;
        public readonly int FloorNumber;
        public Button(Direction direction, int floorNo)
        {
            this.Direction = direction;
            this.FloorNumber = floorNo+2;
        }
        public abstract void PlaceRequest();       
    }
}
