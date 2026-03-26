using System;
using System.Collections.Generic;

namespace WebAPI.Models;

public partial class TrainingCourse
{
    public int Id { get; set; }

    public string? CourseName { get; set; }

    public int? DepartmentId { get; set; }

    public bool? IsActive { get; set; }

    public virtual DepartmentList? Department { get; set; }
}
