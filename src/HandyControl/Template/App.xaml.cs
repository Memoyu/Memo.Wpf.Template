using HandyControl.Template.Controls;
using HandyControl.Template.ViewModels;
using System;
using System.IO;
using System.Reflection.Metadata;
using System.Windows;
using System.Windows.Threading;
using HandyControl.Template.Controls.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using HandyControl.Template.Views.Pages;
using HandyControl.Template.Models;

namespace HandyControl.Template
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IHost host { get; private set; }

        public App()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder();
            BuildSerilogConfig(builder);
            Log.Logger = new LoggerConfiguration()
              .ReadFrom.Configuration(builder.Build())
              .Enrich.FromLogContext()
              .CreateLogger();

            host = Host.CreateDefaultBuilder()
                .ConfigureAppConfiguration(b => { b.SetBasePath(Path.GetDirectoryName(Assembly.GetEntryAssembly()!.Location)!); })
                .ConfigureServices((context, services) =>
                {
                    ConfigureServices(context, services);
                })
                .UseSerilog()
            .Build();
        }

        private void ConfigureServices(HostBuilderContext context, IServiceCollection services)
        {
            // Configuration App Setting
            services.Configure<AppSettings>(context.Configuration);

            // App Host
            services.AddHostedService<ApplicationHostService>();

            // Page resolver service
            services.AddSingleton<IPageService, PageService>();

            // Main window with navigation
            services.AddSingleton<INavigationWindow, MainWindow>();
            services.AddSingleton<MainWindowViewModel>();


            // Views and ViewModels
            services.AddSingleton<DashboardPage>();
            services.AddSingleton<DashboardViewModel>();
            services.AddSingleton<DataGridPage>();
            services.AddSingleton<DataGridViewModel>();
            services.AddSingleton<SettingPage>();
            services.AddSingleton<SettingViewModel>();

            // Business Services
            //services.AddTransient<IWorkService, ClientWorkService>();
        }

        /// <summary>
        /// Occurs when the application is loading.
        /// </summary>
        private async void OnStartup(object sender, StartupEventArgs e) => await host.StartAsync();

        /// <summary>
        /// Occurs when the application is closing.
        /// </summary>
        private async void OnExit(object sender, ExitEventArgs e)
        {
            Log.Error("程序退出了");
            await Log.CloseAndFlushAsync();
            await host.StopAsync();
            host.Dispose();
        }

        /// <summary>
        /// Occurs when an exception is thrown by an application but not handled.
        /// </summary>
        private void OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            // For more info see https://docs.microsoft.com/en-us/dotnet/api/system.windows.application.dispatcherunhandledexception?view=windowsdesktop-6.0
            Log.Fatal(e.Exception, "未处理异常");
        }

        private void BuildSerilogConfig(IConfigurationBuilder builder)
        {
            builder.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.serilog.json", optional: true, reloadOnChange: true);
        }
    }
}
