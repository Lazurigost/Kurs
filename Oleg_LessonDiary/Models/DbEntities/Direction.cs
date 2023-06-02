using System;
using System.Collections.Generic;

namespace Oleg_LessonDiary;

public partial class Direction
{
    public int IdDirection { get; set; }

    public string DirectionName { get; set; } = null!;

    public virtual ICollection<Teacher> Teachers { get; } = new List<Teacher>();
}
