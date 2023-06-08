using System;
using System.Collections.Generic;

namespace Oleg_LessonDiary.Models.DbEntities;

public partial class Userssubscription
{
    public int IdUserssubsription { get; set; }

    public int UserssubsriptionIdUsers { get; set; }

    public DateTime? UserssubsriptionDate { get; set; }

    public string UserssubsriptionStatus { get; set; } = null!;

    public int? UserssubscriptionIdPlan { get; set; }

    public virtual Learnplan? UserssubscriptionIdPlanNavigation { get; set; }

    public virtual Learninguser UserssubsriptionIdUsersNavigation { get; set; } = null!;
}
