using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservices10.Messaging.InterfacesConstants.Events
{
    public interface IOrderUpdateStatusEvent
    {
        long OrderId { get; }
    }
}
