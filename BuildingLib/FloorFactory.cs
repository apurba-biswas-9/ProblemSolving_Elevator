using System;
using System.Collections.Generic;
using System.Text;

namespace BuildingLib
{
    public class FloorFactory
    {
        public static IFloor CreateFloor(FloorType floorType)
        {
            switch (floorType)
            {
                case FloorType.LowerBasement: return new LowerBasement();
                case FloorType.GroundFloor: return new GroundFloor();
                case FloorType.Basement: return new Basement();
                case FloorType.Floor: return new Floor();
                default: throw new InvalidOperationException("Invalid type specified.");
            }
        }
    }
}
