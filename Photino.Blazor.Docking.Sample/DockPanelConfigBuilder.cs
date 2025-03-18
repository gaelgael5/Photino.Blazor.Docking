using Bb.ComponentModel;
using Bb.ComponentModel.Attributes;
using Photino.Blazor.Docking.Sample.Pages;

namespace Photino.Blazor.Docking.Sample;

[ExposeClass(DockPanelConfigs.Context, ExposedType = typeof(IInjectBuilder<DockPanelConfigs>))]
public class DockPanelConfigBuilder : InjectBuilder<DockPanelConfigs>
{

    public override object Execute(DockPanelConfigs config)
    {

        config.Add(new DockPanelConfig(typeof(Index), "index", "Index page"));
        config.Add(new DockPanelConfig(typeof(Counter), "counter", "Counter Page"));
        config.Add(new DockPanelConfig(typeof(FetchData), "fetchData", "Fetch data page"));
        config.Add(new DockPanelConfig(typeof(TestPage1), "testPage1", "Test page #1"));
        config.Add(new DockPanelConfig(typeof(TestPage2), "testPage2", "Test page #2"));
        config.Add(new DockPanelConfig(typeof(TestFloatPanel), "testFloatPanel", "Test float panel"));

        return null;

    }
}
