using System;
using System.Collections.Generic;

namespace DAL.DbModels;

public partial class User
{
    public int UserId { get; set; }

    public string? FirstName { get; set; }

    public string LoginName { get; set; } = null!;

    public string? Mail { get; set; }

    public int? ALevel { get; set; }

    public string? Password { get; set; }

    public virtual ICollection<Task> Tasks { get; } = new List<Task>();
}
