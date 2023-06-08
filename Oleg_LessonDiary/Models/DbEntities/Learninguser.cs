using System;
using System.Collections.Generic;

namespace Oleg_LessonDiary.Models.DbEntities;

public partial class Learninguser
{
    public int IdLearningUsers { get; set; }

    public virtual User IdLearningUsersNavigation { get; set; } = null!;

    public virtual ICollection<Userssubscription> Userssubscriptions { get; } = new List<Userssubscription>();
}
