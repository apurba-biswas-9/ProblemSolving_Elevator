using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BuildingLib;
using Elevator;

namespace Buildding
{
    class Program
    {
        private const string QUIT = "q";
        static void Main(string[] args)
        {

            //Added LowerBasement, Basement, GroundFloor, 10 Floors            
            IBuilding building = new Building(); //Instance of Building

            //Added Extra Floor to the building, Now total Floor is 11
           //---> building.AddFloor(FloorFactory.CreateFloor(FloorType.Floor));

            //When a person presses up / down button on the floo
            //we can initiate multiple request
            var requests = new ElevatorRequests();
            var button = new FloorButton(requests, Direction.Down, 3);
            button.PlaceRequest();

            // button = new FloorButton(requests, Direction.Up, 9);
            //button.PlaceRequest();

            //Elevator controller which control all the elevators
            //we can add addition elevator as well            
            ElevatorController controller = new ElevatorController(requests, building);
            controller.AttachElevator(new Elevator.Elevator("EL1", 7, ElevatorStatus.UP)); //Attached 1 Elevator
            controller.AttachElevator(new Elevator.Elevator("EL2", 4, ElevatorStatus.DOOR_OPEN));  //Attached 2 Elevator
            controller.AttachElevator(new Elevator.Elevator("EL3", (int)FloorType.LowerBasement, ElevatorStatus.UP)); // //Attached 3 Elevator
            //---> controller.AttachElevator(new Elevator.Elevator("EL4", (int)FloorType.GroundFloor, ElevatorStatus.UP)); // //Attached 4 Elevator

            while (true)
            {
                var request = controller.GetNextRequestToProcesses();                
                if (request != null && !request.IsProcesed)
                {
                    Console.WriteLine("Processing Request Id :- {0}, Floor No. :- {1}", request.RequestId, (request.FloorNo-2));
                    controller.Notify(request);
                    controller.StratElevator(request);

                    if (request.IsProcesed)
                    {
                        requests.RemoveReqest(request);
                        Console.WriteLine("Processing Completed ");
                    }
                }
            }
        }
    }



}
