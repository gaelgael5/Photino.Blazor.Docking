using System.ComponentModel;
using System.Reflection;

namespace Photino.Blazor.Docking;

[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
public sealed class DockPanelConfigAttribute : Attribute
{

    public DockPanelConfigAttribute(Type componentType, string id, string title)
    {
        this.ComponentType = componentType;
        this.Id = id;
        this.Title = title;
    }

    /// <summary>
    /// Non-repeating type of blazor component to display inside dock panel.
    /// </summary>
    public Type ComponentType { get; }

    /// <summary>
    /// Unique panel identifier.
    /// </summary>
    public string Id { get; }

    /// <summary>
    /// Title displayed in panel header.
    /// </summary>
    public string Title { get; }

    /// <summary>
    /// Disabled compass zones for this panel.
    /// </summary>
    public DockZone DisabledZones { get; init; }

    /// <summary>
    /// Is panel can be detached from its location or not.
    /// </summary>
    public bool CanBeDetached { get; set; }

    /// <summary>
    /// Returns the configuration of the dock panel.
    /// </summary>
    /// <returns></returns>
    public DockPanelConfig GetConfiguration()
    {
        return new DockPanelConfig(this.ComponentType, this.Id, this.Title, this.CanBeDetached, this.DisabledZones);
    }

    /// <summary>
    /// Return the configuration of the dock panel.
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public static DockPanelConfig? GetConfiguration(Type type)
    {

        var attribute =
            TypeDescriptor.GetAttributes(type)
            .OfType<DockPanelConfigAttribute>()
            .FirstOrDefault();

        return attribute?.GetConfiguration();

    }

    /// <summary>
    /// Returns the configuration of the dock panel of exposed types.
    /// </summary>
    /// <param name="assembly"></param>
    /// <returns></returns>
    public static IEnumerable<DockPanelConfig> GetConfigurations(Assembly assembly)
    {

        foreach (var type in assembly.GetTypes())
        {

            DockPanelConfigAttribute attribute = null;
            if (type.IsClass && !type.IsNested && !type.IsAbstract)
            {
                try
                {
                    attribute =
                        TypeDescriptor.GetAttributes(type)
                        .OfType<DockPanelConfigAttribute>()
                        .FirstOrDefault();
                }
                catch (Exception)
                {

                }

                if (attribute != null)
                    yield return attribute.GetConfiguration();
            }
        }

    }


}
