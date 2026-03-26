using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Models;

namespace WebAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeListsController : ControllerBase {
        private readonly MyDbContext _context;

        public EmployeeListsController(MyDbContext context) {
            _context = context; // Nhận kết nối thông qua Dependency Injection
        }

        [HttpGet]
        // left join department on d.departmentId = e.departmentId
        public IActionResult GetEmployeeLists() {
            var employees = _context.EmployeeLists
                .Include(e => e.Department)
                .Select(e => new {
                    e.EmployeeId,
                    e.EmployeeName,
                    e.IsActive,
                    e.DepartmentId,
                    DepartmentName = e.Department != null ? e.Department.DepartmentName : null
                })
                .ToList();
            return Ok(employees);
        }
    }
}