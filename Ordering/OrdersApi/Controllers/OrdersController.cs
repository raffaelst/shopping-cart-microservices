using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MassTransit;
using Messaging.InterfacesConstants.Commands;
using Messaging.InterfacesConstants.Constants;
using Microservices10.Messaging.InterfacesConstants.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using Orders.Application.Interface.DTO;
using Orders.Application.Interface.Interfaces;
using OrdersApi.Hubs;

namespace OrdersApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IBusControl _busControl;
        private readonly IOrderService _orderService;
        private readonly IOrderItemService _orderItemService;
        private readonly IHubContext<OrderHub> _hubContext;

        public OrdersController(IOrderService orderService, IOrderItemService orderItemService, IBusControl busControl, IHubContext<OrderHub> hubContext)
        {
            _orderService = orderService;
            _orderItemService = orderItemService;
            _busControl = busControl;
            _hubContext = hubContext;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] List<OrderItemDTO> orderitems)
        {
            OrderDTO order = _orderService.CreateOrder(orderitems);

            List<OrderItemSharedModel> orderItemSharedModels = new List<OrderItemSharedModel>();

            if (orderitems != null && orderitems.Count > 0)
            {
                foreach (var item in orderitems)
                {
                    OrderItemSharedModel orderItemSharedModel = new OrderItemSharedModel();
                    orderItemSharedModel.ProductId = item.ProductId;
                    orderItemSharedModel.Quantity = item.Quantity;
                    orderItemSharedModel.Price = item.Price;

                    orderItemSharedModels.Add(orderItemSharedModel);
                }
            }

            var jsonSettings = new JsonSerializerSettings();
            jsonSettings.Culture = System.Globalization.CultureInfo.InvariantCulture;
            jsonSettings.MissingMemberHandling = MissingMemberHandling.Ignore;
            string content = JsonConvert.SerializeObject(orderItemSharedModels, jsonSettings);

            var sendToUri = new Uri($"{RabbitMqMassTransitConstants.RabbitMqUri}/" +  $"{RabbitMqMassTransitConstants.RegisterOrderCommandQueue}");

            await _hubContext.Clients.All.SendAsync("UpdateOrders", "Dispatched", order.OrderId);

            var endPoint = await _busControl.GetSendEndpoint(sendToUri);
            await endPoint.Send<RegisterOrderCommand>(new RegisterOrderCommand { OrderId = order.OrderId, OrderItems = content});

            return Ok();
        }
    }
}
