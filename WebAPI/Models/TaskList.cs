using System;
using System.Collections.Generic;

namespace WebAPI.Models;

public partial class TaskList
{
    public int Id { get; set; }

    public string TaskName { get; set; } = null!;

    public int? EmployeeId { get; set; }

    public int? CategoryId { get; set; }

    public bool TaskStatus { get; set; }

    public DateTime CreatedTime { get; set; }

    public virtual CategoryList? Category { get; set; }

    public virtual EmployeeList? Employee { get; set; }
}
