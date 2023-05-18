using Microsoft.Extensions.DependencyInjection;
using UI.ChuBao.ViewModels;

namespace UI.ChuBao
{
    public static class ExtensionServices
    {
        public static void ConfigureViews(this IServiceCollection services)
        {
            services.AddTransient<MainWindow>();
        }

        public static void ConfigureViewModels(this IServiceCollection services)
        {
            services.AddTransient<MainViewModel>();
        }
    }
}
