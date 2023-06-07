using System;
using System.Collections.Generic;

namespace Oleg_LessonDiary.Models.DbEntities;

public partial class Userssubsription
{
    public int IdUserssubsription { get; set; }

    public int UserssubsriptionIdUsers { get; set; }

    public DateTime? UserssubsriptionDate { get; set; }

    public string? UserssubsriptionStatus { get; set; }

    public virtual User UserssubsriptionIdUsersNavigation { get; set; } = null!;
}
