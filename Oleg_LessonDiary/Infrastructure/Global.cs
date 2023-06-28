using Oleg_LessonDiary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oleg_LessonDiary.Infrastructure
{
    public static class Global
    {
        public static UserModel user { get; set; } = null;
        public static Teacher? teacher { get; set; } = null;
        public static Lplan? lplan { get; set; } = null;
    }
}
