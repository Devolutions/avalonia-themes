namespace Devolutions.AvaloniaControls.Controls;

using Avalonia.Controls;
using Avalonia.Styling;

public class TabPane : TabControl
{
    protected override void PrepareContainerForItemOverride(Control element, object? item, int index)
    {
        base.PrepareContainerForItemOverride(element, item, index);

        if (element.FindResource("TabPane_TabItem") is ControlTheme theme)
        {
            element.Theme = theme;
        }
    }
}