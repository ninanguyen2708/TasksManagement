using Microsoft.AspNetCore.Mvc;
using WebAPI.Data;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class CategoryListsController : ControllerBase
    {
        private readonly MyDbContext _context;

        public CategoryListsController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<CategoryList> GetCategoryLists()
        {
            return _context.CategoryLists.ToList();
        }
    }
}