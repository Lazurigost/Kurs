using System;
using System.Collections.Generic;

namespace Oleg_LessonDiary.Models.DbEntities;

public partial class Journal
{
    public int IdJournal { get; set; }

    public DateOnly LessonDate { get; set; }

    public string? LessonDecription { get; set; }

    public int IdUser { get; set; }

    public int IdTecher { get; set; }

    public virtual Teacher IdTecherNavigation { get; set; } = null!;

    public virtual User IdUserNavigation { get; set; } = null!;
}
