using Catalogs.Application.Interface.DTO;
using Catalogs.Application.Interface.Interfaces;
using MassTransit;
using Messaging.InterfacesConstants.Commands;
using Microservices10.Messaging.InterfacesConstants.Model;
using Newtonsoft.Json;
using static System.Net.Mime.MediaTypeNames;

namespace CatalogsApi.Messages.Consumers
{
    public class RegisterOrderCommandConsumer : IConsumer<RegisterOrderCommand>
    {
        private readonly IProductService _productService;
        public RegisterOrderCommandConsumer(IProductService productService)
        {
            _productService = productService;
        }

        public Task Consume(ConsumeContext<RegisterOrderCommand> context)
        {
            var result = context.Message;

            if (result?.OrderId != null && result?.OrderItems != null)
            {
                List<OrderItemSharedModel>  productModels = JsonConvert.DeserializeObject<List<OrderItemSharedModel>>(result.OrderItems);

                List<StockDTO> stockDTOs = new List<StockDTO>();

                foreach (var item in productModels)
                {
                    stockDTOs.Add(new StockDTO { ProductId = item.ProductId, Quantity = item.Quantity });
                }

                _productService.CheckStock(stockDTOs);
            }


            return Task.CompletedTask;
        }
    }
}
