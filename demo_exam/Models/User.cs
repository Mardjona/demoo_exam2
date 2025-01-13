using System;
using System.Collections.Generic;

namespace demo_exam.Models;

public partial class User
{
    public int UserId { get; set; }

    public string? UserSurname { get; set; }

    public string? UserName { get; set; }

    public string? UserPatronomic { get; set; }

    public string? UserLogin { get; set; }

    public string? UserPassword { get; set; }

    public int? RoleId { get; set; }

    public virtual Role? Role { get; set; }
}
