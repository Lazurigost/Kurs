namespace Oleg_LessonDiary
{
    internal class ViewModelLocator
    {
        public static ServiceProvider? _provider;
        public static void Init()
        {
            ServiceCollection services = new ServiceCollection();
            
            #region Services
            services.AddScoped<PageService>();
            services.AddTransient<UserService>();
            services.AddTransient<GuitarService>();
            services.AddTransient<TeacherService>();
            services.AddTransient<DirectionsService>();
            services.AddTransient<JournalService>();
            #endregion

            #region ViewModels
            services.AddTransient<MainWindowViewModel>();
            services.AddTransient<SignUpPageViewModel>();
            services.AddTransient<SignInPageViewModel>();
            services.AddTransient<AuthorizedUserControlViewModel>();
            services.AddTransient<TeacherUserControlViewModel>();
            services.AddTransient<UserStartupPageViewModel>();
            #endregion
            
            #region Contexts
            services.AddDbContext<OdinsonlearnContext>(options =>
            {
                string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["OdinsonlearnDatabase"].ConnectionString;
                options.UseLazyLoadingProxies().UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            }, ServiceLifetime.Transient);
            #endregion
            
            _provider = services.BuildServiceProvider();

            foreach (var service in services) 
            {
                _provider.GetRequiredService(service.ServiceType);
            }

            
        }
        public MainWindowViewModel MainWindowViewModel => _provider.GetRequiredService<MainWindowViewModel>();
        public SignInPageViewModel SignInPageViewModel => _provider.GetRequiredService<SignInPageViewModel>();
        public SignUpPageViewModel SignUpPageViewModel => _provider.GetRequiredService<SignUpPageViewModel>();
        public AuthorizedUserControlViewModel AuthorizedUserControlViewModel => _provider.GetRequiredService<AuthorizedUserControlViewModel>();
        public TeacherUserControlViewModel TeacherUserControlViewModel => _provider.GetRequiredService<TeacherUserControlViewModel>();
        public UserStartupPageViewModel UserStartupPageViewModel => _provider.GetRequiredService<UserStartupPageViewModel>();
    }
}
