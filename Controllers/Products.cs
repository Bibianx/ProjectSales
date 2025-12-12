using Microsoft.AspNetCore.Mvc;
using Models.Dtos;
using Models.Response;
using Services;

namespace Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class ProductsController(IProductsServices productsServices) : ControllerBase
    {
        private readonly IProductsServices _productsServices = productsServices;

        [HttpGet("get-products-by-categorie")]
        public async Task<ActionResult<ServiceResponse<List<ProductsResponse>>>> GetProductsByCategorie([FromBody] ProductsRequest request)
        {
            return await _productsServices.GetProductsByCategorie(request);
        }

        [HttpGet("get-products-by-supplier")]
        public async Task<ActionResult<ServiceResponse<List<ProductsResponse>>>> GetProductsBySupplier([FromBody] ProductsRequest request)
        {
            return await _productsServices.GetProductsBySupplier(request);
        }
        
        [HttpGet("get-all-products")]
        public async Task<ActionResult<ServiceResponse<List<ProductsResponse>>>> GetAllProducts([FromBody] ProductsRequest request)
        {
            return await _productsServices.GetAllProducts(request);
        }
        [HttpGet("get-product-by-id")]
        public async Task<ActionResult<ServiceResponse<ProductsResponse>>> GetProductById([FromBody] ProductsRequest request)
        {
            return await _productsServices.GetProductById(request);
        }
     
        [HttpPost("create-product")]
        public async Task<ActionResult<ServiceResponse<ProductsResponse>>> CreateProduct([FromBody] ProductsRequest request)
        {
            return await _productsServices.CreateProduct(request);
        }

        [HttpPut("edit-product")]
        public async Task<ActionResult<ServiceResponse<ProductsResponse>>> EditProduct([FromBody] ProductsRequest request)
        {
            return await _productsServices.EditProduct(request);
        }
    }
}