using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BuildingLib
{
    public class Building : IBuilding
    {
        public Dictionary<int, IFloor> Floors { get; }

        public Building(int? noOfFloors = 10)
        {
            Floors = new Dictionary<int, IFloor>();
            Floors.Add((int)FloorType.LowerBasement, FloorFactory.CreateFloor(FloorType.LowerBasement));
            Floors.Add((int)FloorType.Basement, FloorFactory.CreateFloor(FloorType.Basement));
            Floors.Add((int)FloorType.GroundFloor, FloorFactory.CreateFloor(FloorType.GroundFloor));
            if (noOfFloors.HasValue)
                for (int i = 1; i <= noOfFloors; i++)
                    Floors.Add(i, FloorFactory.CreateFloor(FloorType.Floor));
        }

        public void AddFloor(IFloor floor)
        {
            Floors.Add((Floors.Keys.Last() + 1), floor);
        }
    }
}
