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

    public DateOnly UsersDatebirth { get; set; }

    public int UsersRole { get; set; }

    public virtual Learninguser? Learninguser { get; set; }

    public virtual Teacher? Teacher { get; set; }

    public virtual Role UsersRoleNavigation { get; set; } = null!;
}
