using System;
using System.Collections.Generic;

namespace Oleg_LessonDiary.Models.DbEntities;

public partial class Teacher
{
    public int IdTeacher { get; set; }

    public int TeacherIdQual { get; set; }

    public virtual User IdTeacherNavigation { get; set; } = null!;

    public virtual ICollection<Learnplan> Learnplans { get; } = new List<Learnplan>();

    public virtual Qualification TeacherIdQualNavigation { get; set; } = null!;
}
