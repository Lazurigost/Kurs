using System;
using System.Collections.Generic;

namespace Oleg_LessonDiary.Models.DbEntities;

public partial class User
{
    public int IdUsers { get; set; }

    public string UserLogin { get; set; } = null!;

    public string UsersPassword { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public string UserSurname { get; set; } = null!;

    public string UserPatronymics { get; set; } = null!;

    public DateOnly UserDatebirth { get; set; }

    public int IdType { get; set; }

    public virtual GuitarType IdTypeNavigation { get; set; } = null!;

    public virtual ICollection<Journal> Journals { get; } = new List<Journal>();
}
