using Microsoft.EntityFrameworkCore;
using Models;
using Models.Dtos;
using Models.Entities;
using Models.Response;

namespace Services
{
    public interface ICategoriesServices
    {
        Task<ServiceResponse<CategoriesResponse>> CreateCategory(CategoriesRequest data);
        Task<ServiceResponse<CategoriesResponse>> EditCategory(CategoriesRequest data);
        Task<ServiceResponse<CategoriesResponse>> GetCategoryById(Guid categoryId);
        Task<ServiceResponse<List<CategoriesResponse>>> GetAllCategories();
    }

    public class CategoriesServices(DataContext context) : ICategoriesServices
    {
        private readonly DataContext _context = context;

        public async Task<ServiceResponse<CategoriesResponse>> GetCategoryById(Guid categoryId)
        {
            var response = new ServiceResponse<CategoriesResponse>();
            try
            {
                var category = await _context.Categories
                    .AsNoTracking()
                    .FirstOrDefaultAsync(c => c.CategoryId == categoryId);

                if (category == null)
                {
                    response.Success = false;
                    response.Message = "Categoria no encontrada";
                    return response;
                }

                response.Success = true;
                response.Message = "Categoria obtenida exitosamente";
                response.Data = new CategoriesResponse
                {
                    CategoryName = category.CategoryName,
                    Description =  category.Description
                };
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Error al obtener la categoria";
                response.Tipo = $"error {ex.Message}";
            }
            return response;
        }

        public async Task<ServiceResponse<List<CategoriesResponse>>> GetAllCategories()
        {
            var response = new ServiceResponse<List<CategoriesResponse>>();
            try
            {
                var responseCategories = await _context.Categories.Select(e => new CategoriesResponse
                {
                    CategoryName = e.CategoryName,
                    Description = e.Description
                }).AsNoTracking().ToListAsync();

                if (responseCategories.Count == 0)
                {
                    response.Message = "No se encontraron categorias";
                    response.Success = false;
                    return response;
                }

                response.Success = true;
                response.Data = responseCategories;
                response.Message = "Categorias obtenidas exitosamente";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Error al obtener las categorias";
                response.Tipo = $"error {ex.Message}";
            }
            return response;
        }

        public async Task<ServiceResponse<CategoriesResponse>> CreateCategory(CategoriesRequest data)
        {
            var response = new ServiceResponse<CategoriesResponse>();
            try
            {
                bool existsCategorie = await _context.Categories.AnyAsync(c => c.CategoryName.Equals(data.CategoryName));    

                if (existsCategorie)
                {
                    response.Success = false;
                    response.Message = "La categoria ya existe";
                    return response;
                }

                response.Success = true;
                response.Message = "Categoria creada exitosamente";
                _context.Categories.Add(new Categories
                {
                    CategoryName = data.CategoryName,
                    Description = data.Description
                });
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Error al crear la categoria";
                response.Tipo = $"error {ex.Message}";
            }
            return response;
        }

        public async Task<ServiceResponse<CategoriesResponse>> EditCategory(CategoriesRequest data)
        {
            var response = new ServiceResponse<CategoriesResponse>();
            try
            {
                bool existsCategorie = await _context.Categories.AnyAsync(c => c.CategoryName.Equals(data.CategoryName));    

                if (!existsCategorie)
                {
                    response.Success = false;
                    response.Message = "La categoria no existe";
                    return response;
                }

                response.Success = true;
                response.Message = "Categoria editada exitosamente";

                _context.Entry(data).State = EntityState.Modified;
                _context.Categories.Update(new Categories
                {
                    CategoryName = data.CategoryName,
                    Description = data.Description
                });
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Error al crear la categoria";
                response.Tipo = $"error {ex.Message}";
            }
            return response;
        }
    }
}