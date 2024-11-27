using System;
using System.Collections.Generic;

namespace MidExamMVCCore.Models;

public partial class Student
{
    public int StudentId { get; set; }

    public string StudentName { get; set; } = null!;

    public DateOnly Dob { get; set; }

    public string MobileNo { get; set; } = null!;

    public string? ImageUrl { get; set; }

    public bool IsEnrolled { get; set; }

    public int CourseId { get; set; }

    public virtual Course Course { get; set; } = null!;

    public virtual ICollection<Module> Modules { get; set; } = new List<Module>();
}
