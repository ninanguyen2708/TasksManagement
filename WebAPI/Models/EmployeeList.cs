using System;
using System.Collections.Generic;

namespace WebAPI.Models;

public partial class EmployeeList
{
    public int EmployeeId { get; set; }

    public string EmployeeName { get; set; } = null!;

    public bool IsActive { get; set; }

    public int? DepartmentId { get; set; }

    public virtual DepartmentList? Department { get; set; }

    public virtual ICollection<TaskList> TaskLists { get; set; } = new List<TaskList>();
}
