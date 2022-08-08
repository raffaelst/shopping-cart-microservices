using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Domain.Entities
{
    public enum Status
    {
        AwaitingShipment,
        Processed,
        Cancelled
    }
}
