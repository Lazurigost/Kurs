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
            _pageService.ChangePage(new SignInPage());
        }
    }
}
