using Microsoft.AspNetCore.Mvc;
using WebAPI.Data  ;
using WebAPI.Models;


namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class DepartmentListsController : ControllerBase
    {
        private readonly MyDbContext _context;

        public DepartmentListsController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet] 
        public List<DepartmentList> GetDepartmentLists() {
            return _context.DepartmentLists.ToList();
        }
    }
}