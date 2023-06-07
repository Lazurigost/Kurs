using System;
using System.Collections.Generic;

namespace Oleg_LessonDiary.Models.DbEntities;

public partial class User
{
    public int IdUsers { get; set; }

    public string UsersLogin { get; set; } = null!;

    public string UsersPassword { get; set; } = null!;

    public string? UsersName { get; set; }

    public string? UsersSurname { get; set; }

    public string? UsersPatronymics { get; set; }

    public DateTime UsersDatebirth { get; set; }

    public string UsersRole { get; set; } = null!;

    public virtual ICollection<Learnplan> Learnplans { get; } = new List<Learnplan>();

    public virtual ICollection<Userssubsription> Userssubsriptions { get; } = new List<Userssubsription>();
}
