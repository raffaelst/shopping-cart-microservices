using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messaging.InterfacesConstants.Commands
{
    public  class RegisterOrderCommand
    {
        public long OrderId { get; set; }
        public string OrderItems { get; set; }
    }
}
