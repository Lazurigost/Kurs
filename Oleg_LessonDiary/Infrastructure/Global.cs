using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oleg_LessonDiary.Infrastructure
{
    public static class Global
    {
        public static Journal? journal { get; set; } = null;
        public static User? user { get; set; } = null;
        public static Teacher? teacher { get; set; } = null;
    }
}
