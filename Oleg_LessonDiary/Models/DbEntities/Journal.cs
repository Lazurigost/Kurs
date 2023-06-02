using System;
using System.Collections.Generic;

namespace Oleg_LessonDiary.Models.DbEntities;

public partial class Journal
{
    public int LessonId { get; set; }

    public DateOnly LessonDate { get; set; }

    public string? LessonDescription { get; set; }

    public int JournalUserId { get; set; }

    public int JournalTeacherId { get; set; }

    public virtual Teacher JournalTeacher { get; set; } = null!;

    public virtual User JournalUser { get; set; } = null!;
}
