using System;
using System.Collections.Generic;
using System.Text;

namespace BuildingLib
{
   public interface IBuilding
    {
        Dictionary<int, IFloor> Floors { get; }
        void AddFloor(IFloor floor);
    }
}
