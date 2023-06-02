using System;
using System.Collections.Generic;

namespace Oleg_LessonDiary;

public partial class User
{
    public int IdUsers { get; set; }

    public string UserLogin { get; set; } = null!;

    public string UsersPassword { get; set; } = null!;

    public string? UserSurname { get; set; }

    public string? UserName { get; set; }

    public string? UserPatronymics { get; set; }

    public DateOnly UserDatebirth { get; set; }

    public int IdType { get; set; }

    public virtual GuitarType IdTypeNavigation { get; set; } = null!;

    public virtual ICollection<Journal> Journals { get; } = new List<Journal>();
}
