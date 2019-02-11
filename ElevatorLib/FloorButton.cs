using BuildingLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Elevator
{
    public class FloorButton : Button
    {        
        ElevatorRequests _requests;
        public FloorButton(ElevatorRequests requests, Direction direction,  int floorNo) : base(direction, floorNo)
        {
            _requests = requests;          
        }
        public override void PlaceRequest()
        {
            _requests.AddRequest(this);
        }      
    }
}
