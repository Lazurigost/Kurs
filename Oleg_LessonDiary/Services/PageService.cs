﻿namespace Oleg_LessonDiary.Services
{
     public class PageService
     {
        public event Action<Page> onPageChanged;
        public void ChangePage(Page page) => onPageChanged?.Invoke(page);
     }
}
