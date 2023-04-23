using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Oleg_LessonDiary.ViewModels
{
    public partial class MainWindowViewModel : ObservableObject
    {
        private readonly PageService _pageService;

        [ObservableProperty]
        private Page pageSource;

        public MainWindowViewModel(PageService pageService)
        {
            _pageService = pageService;
            _pageService.onPageChanged += (page) => PageSource = page;
            _pageService.ChangePage(new SignUpPage());
        }
    }
}
