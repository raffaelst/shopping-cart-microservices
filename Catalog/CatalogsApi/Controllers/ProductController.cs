
using Catalogs.Application.Interface.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CatalogsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var data = await _productService.GetAllAsync();
            return Ok(data);
        }

        [HttpGet("paged")]
        public async Task<IActionResult> GetPaged(int pagesize, int page)
        {
            var pageNumber = page <= 0 ? 1 : page;
            var pageSizeValid = pagesize <= 0 ? 10 : pagesize;

            var data = await _productService.GetPaged(pageSizeValid, pageNumber);
            return Ok(data);
        }
    }
}
