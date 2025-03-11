using Bb.ComponentModel;
using Bb.ComponentModel.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Photino.Blazor.CustomWindow.Services;
using Photino.Blazor.Docking.Services;

namespace Photino.Blazor.Docking.Extensions;

[ExposeClass(ConstantsCore.Service, ExposedType = typeof(IInjectBuilder<IServiceCollection>))]
public class ServiceCollectionBuilder : InjectBuilder<IServiceCollection>
{

    public override object Execute(IServiceCollection services)
    {
        services.AddSingleton<ScreensAgentService>();
        services.AddSingleton<DockingService>();
        return null;
    }
}
