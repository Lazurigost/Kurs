using System;
using System.Collections.Generic;

namespace Oleg_LessonDiary;

public partial class Teacher
{
    public int IdTeacher { get; set; }

    public string TeacherLogin { get; set; } = null!;

    public string TeacherPassword { get; set; } = null!;

    public string? TeacherSurname { get; set; }

    public string? TeacherName { get; set; }

    public string? TeacherQualification { get; set; }

    public int IdDirection { get; set; }

    public virtual Direction IdDirectionNavigation { get; set; } = null!;

    public virtual ICollection<Journal> Journals { get; } = new List<Journal>();
}
