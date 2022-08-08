using MassTransit;
using Microservices10.Messaging.InterfacesConstants.Events;
using System.Threading.Tasks;

namespace Microservices10.OrdersApi.Messages.Consumers
{
    public class OrderUpdateStatusEventConsumer : IConsumer<IOrderUpdateStatusEvent>
    {
        public Task Consume(ConsumeContext<IOrderUpdateStatusEvent> context)
        {
            throw new System.NotImplementedException();
        }
    }
}
