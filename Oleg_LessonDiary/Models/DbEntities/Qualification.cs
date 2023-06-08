using System;
using System.Collections.Generic;

namespace Oleg_LessonDiary.Models.DbEntities;

public partial class Qualification
{
    public int IdQualifications { get; set; }

    public string QualificationsName { get; set; } = null!;

    public virtual Teacher? Teacher { get; set; }
}
