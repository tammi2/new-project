using System;
using System.Collections.Generic;

namespace DAL.DbModels;

public partial class Task
{
    public int TaskId { get; set; }

    public string? TaskTital { get; set; }

    public string? Description { get; set; }

    public int? Hours { get; set; }

    public int? UserId { get; set; }

    public virtual User? User { get; set; }
}
