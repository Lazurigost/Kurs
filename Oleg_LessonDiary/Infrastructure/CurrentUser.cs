﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oleg_LessonDiary.Models.DbEntities;

namespace Oleg_LessonDiary.Infrastructure
{
    internal static class CurrentUser
    {
        public static User userSaved { get; set; }
    }
}