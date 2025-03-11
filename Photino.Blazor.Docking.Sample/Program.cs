using System;
using Bb.ComponentModel;
using Bb.ComponentModel.Attributes;
using Bb.ComponentModel.Loaders;
using Microsoft.Extensions.DependencyInjection;
using Photino.Blazor.Docking.Sample.Services;
using Photino.Blazor.Docking.Services;

namespace Photino.Blazor.Docking.Sample;

[ExposeClass(DockingService.Context, ExposedType = typeof(IInjectBuilder<IServiceCollection>))]
[ExposeClass(ConstantsCore.Service, ExposedType = typeof(IInjectBuilder<IServiceCollection>))]
public class ServiceCollectionBuilder : InjectBuilder<IServiceCollection>
{

    public override object Execute(IServiceCollection services)
    {
        services.AddLogging();
        services.AddScoped<TestService>();
        return null;
    }
}

class Program
{

    [STAThread]
    static void Main(string[] args)
    {




        var appBuilder = PhotinoBlazorAppBuilder.CreateDefault(args);
        appBuilder.Services.AutoConfigure(null, ConstantsCore.Service);
        appBuilder.RootComponents.Add<App>("app");
        var app = appBuilder.Build();

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
