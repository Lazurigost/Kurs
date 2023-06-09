using System;
using System.Collections.Generic;

namespace Oleg_LessonDiary.Models.DbEntities;

public partial class Status
{
    public int IdStatus { get; set; }

    public string StatusFull { get; set; } = null!;
}
