using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Elevator
{
    public class Elevator : BaseElevator
    {

        private bool[] _floorPresed;
        private Request _request;
        private int topfloor;
        private ElevatorStatus _elevatorStatus;


        public readonly string ElevatorID;

        private int CurrentFloor { get; set; }
        public Elevator(string elevatorID, int CurrentFloor = 0, ElevatorStatus elevatorStatus = ElevatorStatus.UP)
        {
            this.ElevatorID = elevatorID;
            this.CurrentFloor = CurrentFloor + 2;
            _elevatorStatus = elevatorStatus;

        }

        public override void Update(Request request, bool[] floorPresed)
        {
            this._floorPresed = floorPresed;
            this._request = request;
            this.topfloor = _floorPresed.Length;

        }

        private void MovingDown(int floor)
        {
            for (int i = CurrentFloor; i >= 0; i--)
            {
                Console.WriteLine("Current Floor is {0} of Elevator {1}, and its going Down", (i - 2), ElevatorID);
                Thread.Sleep(1000);
                if (_floorPresed[i] && _request.Direction == Direction.Down)
                {
                    Stop(floor);
                    break;
                }
                else
                    CurrentFloor = i;
            }

            _elevatorStatus = ElevatorStatus.STOP;
            Console.WriteLine("Waiting.....................");
            Thread.Sleep(1000);
        }

        private void Stop(int floor)
        {
            _elevatorStatus = ElevatorStatus.STOP;
            CurrentFloor = floor;           
            Console.WriteLine("Waiting.....................");
            Thread.Sleep(1000);
        }

        private void MovingUp(int floor)
        {
            for (int i = CurrentFloor; i < topfloor; i++)
            {
                Console.WriteLine("Current Floor is {0} of Elevator {1}, and its going Up", (i - 2), ElevatorID);
                Thread.Sleep(1000);
                if (_floorPresed[i] && _request.Direction == Direction.Up)
                {
                    Stop(floor);
                    break;
                }
                else
                    CurrentFloor = i;
            }

            _elevatorStatus = ElevatorStatus.STOP;
            Console.WriteLine("Waiting.....................");
            Thread.Sleep(1000);
        }

        public void ElevatorMovement()
        {
            if (_request.FloorNo >= topfloor)
            {
                Console.WriteLine("We only have {0} floors", topfloor);
                return;
            }

            switch (_elevatorStatus)
            {
                case ElevatorStatus.DOWN:
                    MovingDown(_request.FloorNo);
                    break;

                case ElevatorStatus.UP:
                    MovingUp(_request.FloorNo);
                    break;

                case ElevatorStatus.STOP:
                    if (CurrentFloor < _request.FloorNo)
                        MovingUp(_request.FloorNo);
                    else if (CurrentFloor == _request.FloorNo)
                    {
                        Thread.Sleep(1000);
                        _floorPresed[_request.FloorNo] = false;
                        _elevatorStatus = ElevatorStatus.DOOR_OPEN;
                        Console.WriteLine("Stopped at Floor {0} of Elevator {1}",( _request.FloorNo-2), ElevatorID);
                    }
                    else
                        MovingDown(_request.FloorNo);

                    break;

                case ElevatorStatus.DOOR_OPEN:
                    Console.WriteLine("Door is Opened for  Elevator {0} at floor {1}", this.ElevatorID, this.CurrentFloor-2);

                    if (ElevatorID == "EL2")
                        Thread.Sleep(60000);
                    else
                        Thread.Sleep(1000);
                    _elevatorStatus = ElevatorStatus.DOOR_CLOSED;
                    break;

                case ElevatorStatus.DOOR_CLOSED:
                    Console.WriteLine("Door is Closed for Elevator {0} ", this.ElevatorID);
                    _request.IsProcesed = true;
                    _elevatorStatus = ElevatorStatus.DOWN;
                    Thread.Sleep(2000);
                    break;

                default:
                    break;

            }
        }
    }
}
