using System;
using System.Collections.Generic;

namespace Oleg_LessonDiary.Models.DbEntities;

public partial class Direction
{
    public int IdDirection { get; set; }

    public string DirectionName { get; set; } = null!;

    public string? DirectionDescription { get; set; }

    public virtual ICollection<Teacher> Teachers { get; } = new List<Teacher>();
}
