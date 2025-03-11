using System.Drawing;

namespace Photino.Blazor.Docking.Services;

public class DockingServiceInitializer
{

    public Type floatPanelWrapperComponent { get; set; }

    public string multiplePanelsTitle { get; set; } = string.Empty;

    public bool restoreHostWindowOnOpen { get; set; } = true;

    public Size? panelsMinSize { get; set; } = null;

    public Size? defaultFloatPanelSize { get; set; } = null;

}
