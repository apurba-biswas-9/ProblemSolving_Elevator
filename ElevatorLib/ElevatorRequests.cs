using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Elevator
{
    public class ElevatorRequests
    {
        private List<Request> ListOfRequest { get; set; }
        public ElevatorRequests()
        {
            ListOfRequest = new List<Request>();
        }

        public void AddRequest(Button button)
        {
            ListOfRequest.Add(new Request() { RequestId = Guid.NewGuid(), Direction = button.Direction, FloorNo = button.FloorNumber, IsProcesed = false });
        }

        public void RemoveReqest(Request request)
        {
            ListOfRequest.Remove(request);
        }

        public Request GetNextRequestToProcesses()
        {
            return ListOfRequest.OrderBy(p=> p.RequestId).FirstOrDefault();
        }
    }    
}
