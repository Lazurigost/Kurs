using DevExpress.Mvvm.POCO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Oleg_LessonDiary.ViewModels;
using Oleg_LessonDiary.Services;
using System.Configuration;

namespace Oleg_LessonDiary
{
    internal class ViewModelLocator
    {
        public static ServiceProvider? _provider;
        public static void Init()
        {
            ServiceCollection services = new ServiceCollection();
            
            #region Services
            services.AddSingleton<PageService>();
            services.AddSingleton<UserService>();
            #endregion

            #region ViewModels
            services.AddTransient<MainWindowViewModel>();
            services.AddTransient<SignInPageViewModel>();
            services.AddTransient<SignUpPageViewModel>();
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
    }
}
