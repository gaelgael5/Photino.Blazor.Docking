using Bb.ComponentModel;
using Bb.ComponentModel.Loaders;
using System.Collections;
using System.Reflection;
using System.Runtime.Loader;

namespace Photino.Blazor.Docking;

public class DockPanelConfigs : IEnumerable<DockPanelConfig>
{

    public DockPanelConfigs()
    {

        _panelsConfigs = new Dictionary<string, DockPanelConfig>();

        IEnumerable<Assembly> assemblies = null;
        var ctx = AssemblyLoadContext.CurrentContextualReflectionContext;
        if (ctx == null)
        {
            ctx = AssemblyLoadContext.All.FirstOrDefault();
        }
        if (ctx != null)
            assemblies = ctx.Assemblies;
        
        if (assemblies != null)
            foreach (var assembly in assemblies)
                AddRange(DockPanelConfigAttribute.GetConfigurations(assembly));

        this.AutoConfigure(null, Context);

    }

    public void AddRange(IEnumerable<DockPanelConfig> items)
    {
        if (items != null)
            foreach (var item in items)
                Add(item);
    }

    public void Add(DockPanelConfig item)
    {
        
        if (_panelsConfigs.ContainsKey(item.Id))
            throw new Exception("Invalid docking service configuration: " +
                "there are duplicates of identifier or panel types in the dock panels configuration set.");

        _panelsConfigs.Add(item.Id, item);

    }

    public DockPanelConfig Get(Type componentType) => _panelsConfigs.Values.Single(p => p.ComponentType == componentType);

    public DockPanelConfig Get(string id) => _panelsConfigs[id];

    public IReadOnlyCollection<DockPanelConfig> AsReadOnly() => _panelsConfigs.Values.ToList().AsReadOnly();

    public IEnumerator<DockPanelConfig> GetEnumerator()
    {
        return _panelsConfigs.Values.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return _panelsConfigs.Values.GetEnumerator();
    }

    private Dictionary<string, DockPanelConfig> _panelsConfigs;

    public const string Context = "DockPanelConfigs";

}


