using Microsoft.EntityFrameworkCore;
using Models;
using Models.Dtos;
using Models.Entities;
using Models.Response;

namespace Services
{
    public interface IProductsServices
    {
        Task<ServiceResponse<List<ProductsResponse>>> GetProductsByCategorie(ProductsRequest request);
        Task<ServiceResponse<List<ProductsResponse>>> GetProductsBySupplier(ProductsRequest request);
        Task<ServiceResponse<List<ProductsResponse>>> GetAllProducts(ProductsRequest request);
        Task<ServiceResponse<ProductsResponse>> GetProductById(ProductsRequest request);
        Task<ServiceResponse<ProductsResponse>> CreateProduct(ProductsRequest request);
        Task<ServiceResponse<ProductsResponse>> EditProduct(ProductsRequest request);
    }

    public class ProductsServices(DataContext context) : IProductsServices
    {
        private readonly DataContext _context = context;

        public async Task<ServiceResponse<List<ProductsResponse>>> GetProductsByCategorie(ProductsRequest request)
        {
            var response = new ServiceResponse<List<ProductsResponse>>();
            try
            {
                var products = await _context.Products
                    .Include(p => p.Categories)
                    .Select(p => new ProductsResponse
                    {
                        Categorie = p.Categories.CategoryName,
                        ProductName = p.ProductName,
                        ProductId = p.ProductId,
                        Price = p.Price,
                        Unit = p.Unit,
                    })
                    .AsNoTracking()
                    .Where(e => e.Categorie.Equals(request.Categorie))
                    .ToListAsync();

                    if (products.Count == 0)
                    {
                        response.Success = false;
                        response.Message = "No se encontraron productos";
                        return response;
                    }

                response.Success = true;
                response.Message = "Productos por categoria obtenidos exitosamente";
                response.Data = products;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Error al obtener los productos";    
                response.Error = $"Error al obtener los productos: {ex.Message}";
            }
            return response;
        }
        public async Task<ServiceResponse<List<ProductsResponse>>> GetProductsBySupplier(ProductsRequest request)
        {
            var response = new ServiceResponse<List<ProductsResponse>>();
            try
            {
                var products = await _context.Products
                    .Include(p => p.Categories)
                    .Include(p => p.Suppliers)
                    .Select(p => new ProductsResponse
                    {
                        Categorie = p.Categories.CategoryName,
                        Supplier = p.Suppliers.SupplierName,
                        ProductName = p.ProductName,
                        ProductId = p.ProductId,
                        Price = p.Price,
                        Unit = p.Unit,
                    })
                    .AsNoTracking()
                    .Where(e => e.Supplier.Equals(request.Supplier))
                    .ToListAsync();

                    if (products.Count == 0)
                    {
                        response.Success = false;
                        response.Message = "No se encontraron productos";
                        return response;
                    }

                response.Success = true;
                response.Message = "Productos por categoria obtenidos exitosamente";
                response.Data = products;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Error al obtener los productos";    
                response.Error = $"Error al obtener los productos: {ex.Message}";
            }
            return response;
        }

        public async Task<ServiceResponse<List<ProductsResponse>>> GetAllProducts(ProductsRequest request)
        {
            var response = new ServiceResponse<List<ProductsResponse>>();
            try
            {
                var products = await _context.Products
                    .Include(p => p.Categories)
                    .Select(p => new ProductsResponse
                    {
                        Categorie = p.Categories.CategoryName,
                        ProductName = p.ProductName,
                        ProductId = p.ProductId,
                        Price = p.Price,
                        Unit = p.Unit,
                    })
                    .AsNoTracking()
                    .ToListAsync();

                    if (products.Count == 0)
                    {
                        response.Success = false;
                        response.Message = "No se encontraron productos";
                        return response;
                    }

                response.Success = true;
                response.Message = "Productos obtenidos exitosamente";
                response.Data = products;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Error al obtener los productos";    
                response.Error = $"Error al obtener los productos: {ex.Message}";
            }
            return response;
        }
        public async Task<ServiceResponse<ProductsResponse>> GetProductById(ProductsRequest request)
        {
            var response = new ServiceResponse<ProductsResponse>();
            try
            {
                var products = await _context.Products
                    .Include(p => p.Categories)
                    .Select(p => new ProductsResponse
                    {
                        Categorie = p.Categories.CategoryName,
                        ProductName = p.ProductName,
                        ProductId = p.ProductId,
                        Price = p.Price,
                        Unit = p.Unit,
                    })
                    .AsNoTracking()
                    .FirstOrDefaultAsync(e => e.ProductId.Equals(request.ProductId));

                    if (products == null)
                    {
                        response.Success = false;
                        response.Message = "No se encontro producto";
                        return response;
                    }

                response.Success = true;
                response.Message = "Producto obtenido exitosamente";
                response.Data = products;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Error al obtener los productos";    
                response.Error = $"Error al obtener los productos: {ex.Message}";
            }
            return response;
        }
        public async Task<ServiceResponse<ProductsResponse>> CreateProduct(ProductsRequest request)
        {
            var response = new ServiceResponse<ProductsResponse>();
            try
            {
                bool existsProducts = await _context.Products.AnyAsync(c => c.ProductName.Equals(request.ProductName));    

                if (existsProducts)
                {
                    response.Success = false;
                    response.Message = "El producto ya existe";
                    return response;
                }

                response.Success = true;
                response.Message = "Producto creado exitosamente";
                _context.Products.Add(new Products
                {
                    ProductName = request.ProductName,
                    Unit = request.Unit,
                    Price = request.Price,
                    CategoryId = request.CategoryId,
                    SupplierId = request.SupplierId
                });
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Error al crear los productos";    
                response.Error = $"Error: {ex.Message}";
            }
            return response;
        }
        public async Task<ServiceResponse<ProductsResponse>> EditProduct(ProductsRequest data)
        {
            var response = new ServiceResponse<ProductsResponse>();
            try
            {
                bool existsProduct = await _context.Products.AnyAsync(c => c.ProductId.Equals(data.ProductId));    

                if (!existsProduct)
                {
                    response.Success = false;
                    response.Message = "El producto no existe";
                    return response;
                }

                response.Success = true;
                response.Message = "Producto editado exitosamente";

                _context.Entry(data).State = EntityState.Modified;
                _context.Products.Update(new Products
                {
                    ProductName = data.ProductName,
                    Unit = data.Unit,
                    Price = data.Price,
                    CategoryId = data.CategoryId,
                    SupplierId = data.SupplierId
                });
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Error al editar el producto";
                response.Tipo = $"error {ex.Message}";
            }
            return response;
        }
    }
}