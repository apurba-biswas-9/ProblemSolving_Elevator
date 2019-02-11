using System;
using System.Collections.Generic;
using System.Text;

namespace Elevator
{
    public class Request
    {
        public Guid RequestId { get; set; }
        public int FloorNo { get; set; }
        public bool IsProcesed { get; set; }
        public Direction Direction { get; set; }
    }
}
