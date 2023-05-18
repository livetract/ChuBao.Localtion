using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Windows;

namespace UI.ChuBao
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IHost AppHost { get; private set; }
        public App()
        {
            var builder = Host.CreateDefaultBuilder()
                .ConfigureAppConfiguration(ConfigureApplication)
                .ConfigureServices(ConfigureServices);

            AppHost = builder.Build();
            AppHost.RunAsync();
        }

        private void ConfigureApplication(HostBuilderContext context, IConfigurationBuilder config)
        {
            var env = context.HostingEnvironment;
            config.Sources.Clear();
            config.SetBasePath(env.ContentRootPath);
            config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true, true);
            config.AddEnvironmentVariables();
            config.Build();
        }

        private void ConfigureServices(HostBuilderContext context, IServiceCollection services)
        {
            services.ConfigureViews();
            services.ConfigureViewModels();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            await AppHost.StartAsync();
            var start = AppHost.Services.GetRequiredService<MainWindow>();
            start.Show();

            base.OnStartup(e);
        }
        protected override async void OnExit(ExitEventArgs e)
        {
            await AppHost.StopAsync();
            base.OnExit(e);
        }
    }
}
