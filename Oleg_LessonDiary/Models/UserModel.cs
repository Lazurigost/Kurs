using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oleg_LessonDiary.Models
{
    public partial class UserModel : ObservableObject
    {
        [ObservableProperty]
        private List<int> subbedList = new();
    }
}
