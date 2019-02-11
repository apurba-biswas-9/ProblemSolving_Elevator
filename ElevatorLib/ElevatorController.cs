using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BuildingLib;

namespace Elevator
{
    public class ElevatorController
    {
        #region Private Variables
        ElevatorRequests _requests;
        IBuilding _building;
        List<BaseElevator> _elevators = new List<BaseElevator>();
        bool[] _floorPressed = null;
        #endregion

        #region Constructor
        public ElevatorController(ElevatorRequests requests, IBuilding building)
        {
            this._requests = requests;
            this._building = building;
            this._floorPressed = new bool[_building.Floors.Count];
        }
        #endregion

        
        public Request GetNextRequestToProcesses()
        {
            return this._requests.GetNextRequestToProcesses();
        }
        public void AttachElevator(BaseElevator elevator)
        {
            _elevators.Add(elevator);
        }
        public void DetachElevator(BaseElevator elevator)
        {
            _elevators.Remove(elevator);
        }
        public void Notify(Request request)
        {
            this._floorPressed[request.FloorNo] = true;
            foreach (BaseElevator o in _elevators)
            {
                o.Update(request, this._floorPressed);
            }
        }
        public void StratElevator(Request request)
        {
            List<Task> tasks = new List<Task>();
            for (int i = 0; i < _elevators.Count; i++)
            {
                var elv = ((Elevator)_elevators[i]);
                tasks.Add(Task.Run(() =>
                {
                    while (!request.IsProcesed)
                    {
                        elv.ElevatorMovement();
                    }
                }));              
            }
            Task.WaitAll(tasks.ToArray());
        }
    }    
}

