using Bb.ComponentModel;
using Bb.ComponentModel.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Photino.Blazor.Docking.Sample.Services;
using Photino.Blazor.Docking.Services;

namespace Photino.Blazor.Docking.Sample;

[ExposeClass(DockingService.Context, ExposedType = typeof(IInjectBuilder<IServiceCollection>), LifeCycle = IocScopeEnum.Transiant)]
[ExposeClass(ConstantsCore.Service, ExposedType = typeof(IInjectBuilder<IServiceCollection>), LifeCycle = IocScopeEnum.Transiant)]
public class ServiceCollectionBuilder : InjectBuilder<IServiceCollection>
{

    public override object Execute(IServiceCollection services)
    {
        services.AddLogging();
        services.AddSingleton<TestService>();
        return null;
    }
}

