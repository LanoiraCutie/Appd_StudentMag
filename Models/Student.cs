using System;
using System.Collections.Generic;

namespace LanoiraM_6th.Models;

public partial class Student
{
    public int Id { get; set; }

    public string FullName { get; set; } = null!;

    public int? Age { get; set; }

    public string? Email { get; set; }
}
