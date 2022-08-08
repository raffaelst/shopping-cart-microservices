using Catalogs.Application.Interface.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogs.Application.Interface.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetAllAsync();
        Task<IEnumerable<ProductDTO>> GetPaged(int pageSize, int page);
        Task<bool> CheckStock(List<StockDTO> stockDTOs);
    }
}
