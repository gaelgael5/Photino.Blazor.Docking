using System;
using Bb.ComponentModel;
using Bb.ComponentModel.Loaders;
using Microsoft.Extensions.DependencyInjection;
using Photino.Blazor.Docking.Extensions;
using Photino.Blazor.Docking.Sample.Pages;
using Photino.Blazor.Docking.Sample.Services;
using Photino.Blazor.Docking.Sample.Shared;
using Index = Photino.Blazor.Docking.Sample.Pages.Index;

namespace Photino.Blazor.Docking.Sample;

class Program
{
    private static void InitializeServices(IServiceCollection services)
    {
        services.AddLogging();
        services.AddScoped<TestService>();

        // to register singleton service (single between OS windows) -
        // use service instance manually created and statically stored:
        // services.AddSingleton(_testService);
    }

    [STAThread]
    static void Main(string[] args)
    {

        IocHelper.LoadAssemblies(true);

        var appBuilder = PhotinoBlazorAppBuilder.CreateDefault(args);
    	appBuilder.Services.AutoConfigure(null, ConstantsCore.Service);

        // InitializeServices(appBuilder.Services);

        appBuilder.Services.AddPhotinoBlazorDocking();

        // register root component and selector
        appBuilder.RootComponents.Add<App>("app");
                        
        var app = appBuilder.Build();

        //var r = app.Services.GetService(typeof(Photino.Blazor.Docking.Services.DockingService));


        // customize window
        app.MainWindow
            .SetSize(1500, 1000)
            .SetIconFile("favicon.ico")
            .SetTitle("Docking Demo");

        AppDomain.CurrentDomain.UnhandledException += (sender, error) =>
        {
            app.MainWindow.ShowMessage("Fatal exception", error.ExceptionObject.ToString());
        };

        app.Run();
    }
}

