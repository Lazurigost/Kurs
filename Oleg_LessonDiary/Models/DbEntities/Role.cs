﻿using System;
using System.Collections.Generic;

namespace Oleg_LessonDiary.Models.DbEntities;

public partial class Role
{
    public int IdRole { get; set; }

    public string RoleName { get; set; } = null!;

    public virtual ICollection<User> Users { get; } = new List<User>();
}
