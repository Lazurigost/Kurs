using System;
using System.Collections.Generic;

namespace Oleg_LessonDiary;

public partial class Teacher
{
    public int IdTeacher { get; set; }

    public string TrLogin { get; set; } = null!;

    public string TrPassword { get; set; } = null!;

    public string? TrName { get; set; }

    public string? TrSurname { get; set; }

    public string? TrPatronymics { get; set; }

    public string? TrDegree { get; set; }

    public int TrDirection { get; set; }

    public virtual ICollection<Journal> Journals { get; } = new List<Journal>();

    public virtual Direction TrDirectionNavigation { get; set; } = null!;
}
