using System;
using System.Collections.Generic;

namespace WebAPI.Models;

public partial class CategoryList
{
    public int CategoryId { get; set; }

    public string CategoryName { get; set; } = null!;

    public bool IsActive { get; set; }

    public virtual ICollection<TaskList> TaskLists { get; set; } = new List<TaskList>();
}
