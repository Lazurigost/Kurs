using System;
using System.Collections.Generic;

namespace Oleg_LessonDiary.Models.DbEntities;

public partial class Kur
{
    public int IdKurs { get; set; }

    public string KursName { get; set; } = null!;

    public int KursIdGuitar { get; set; }

    public int? KursDuration { get; set; }

    public DateTime KursStartDate { get; set; }

    public virtual Guitar KursIdGuitarNavigation { get; set; } = null!;

    public virtual ICollection<Learnplan> Learnplans { get; } = new List<Learnplan>();
}
