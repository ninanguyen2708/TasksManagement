using System;
using System.Collections.Generic;

namespace WebAPI.Models;

public partial class DepartmentList
{
    public int DepartmentId { get; set; }

    public string DepartmentName { get; set; } = null!;

    public virtual ICollection<EmployeeList> EmployeeLists { get; set; } = new List<EmployeeList>();

    public virtual ICollection<TrainingCourse> TrainingCourses { get; set; } = new List<TrainingCourse>();
}
