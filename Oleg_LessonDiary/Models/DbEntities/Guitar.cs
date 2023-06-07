using System;
using System.Collections.Generic;

namespace Oleg_LessonDiary.Models.DbEntities;

public partial class Guitar
{
    public int IdGuitar { get; set; }

    public string GuitarName { get; set; } = null!;

    public virtual ICollection<Kur> Kurs { get; } = new List<Kur>();
}
