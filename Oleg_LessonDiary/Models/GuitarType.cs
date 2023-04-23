using System;
using System.Collections.Generic;

namespace Oleg_LessonDiary;

public partial class GuitarType
{
    public int IdType { get; set; }

    public string TypeName { get; set; } = null!;

    public virtual ICollection<User> Users { get; } = new List<User>();
}
