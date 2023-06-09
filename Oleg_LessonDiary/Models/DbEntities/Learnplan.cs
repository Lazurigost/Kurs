using System;
using System.Collections.Generic;

namespace Oleg_LessonDiary.Models.DbEntities;

public partial class Learnplan : ObservableObject
{
    public int IdLearnPlan { get; set; }

    public int LearnPlanIdTeacher { get; set; }

    public int LearnPlanIdKurs { get; set; }

    public int LearnPlanRestriction { get; set; }

    public virtual Kur LearnPlanIdKursNavigation { get; set; } = null!;

    public virtual Teacher LearnPlanIdTeacherNavigation { get; set; } = null!;

    public virtual ICollection<Userssubscription> Userssubscriptions { get; } = new List<Userssubscription>();
}
