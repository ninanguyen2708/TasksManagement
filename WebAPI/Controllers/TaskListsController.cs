using Microsoft.AspNetCore.Mvc;
using WebAPI.Data;
using WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class TaskListsController : ControllerBase
    {
        private readonly MyDbContext _context;

        public TaskListsController(MyDbContext context)
        {
            _context = context; // Nhận kết nối thông qua Dependency Injection
        }

        [HttpGet]
        public List<TaskList> GetTaskLists()
        {
            return _context.TaskLists.Include(t => t.Employee).ThenInclude(t => t.Department).Include(t => t.Category).ToList(); // Lấy toàn bộ công việc từ DB
        }

        // Source - https://stackoverflow.com/q/24800449

        [HttpPost("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var task = _context.TaskLists.Find(id);
            if (task == null)
            {
                return NotFound(new { message = "Task not found" });
            }
            _context.TaskLists.Remove(task);
            _context.SaveChanges();
            return Ok(new { message = "Task deleted successfully" });
        }

        [HttpPost("edit/{id}")]
        public IActionResult Edit(int id, [FromBody] TaskList updatedTask)
        {
            var task = _context.TaskLists.Find(id);
            if (task == null)
            {
                return NotFound(new { message = "Task not found" });
            }

            task.TaskName = updatedTask.TaskName;
            task.EmployeeId = updatedTask.EmployeeId;
            task.CategoryId = updatedTask.CategoryId;
            task.TaskStatus = updatedTask.TaskStatus;

            _context.SaveChanges();
            return Ok(task);
        }

        [HttpPost("add")]
        public IActionResult Add([FromBody] TaskList newTask)
        {
            var employee = _context.EmployeeLists.Find(newTask.EmployeeId);
            if (employee == null)
            {
                return NotFound(new { message = "Employee not found" });
            }
            var category = _context.CategoryLists.Find(newTask.CategoryId);
            if (category == null)            {
                return NotFound(new { message = "Category not found" });
            }

            _context.TaskLists.Add(newTask);
            _context.SaveChanges();
            return Ok(newTask);

        }
    }
}