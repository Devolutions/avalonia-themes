namespace Devolutions.AvaloniaControls.Controls;

using Avalonia;
using Avalonia.Controls;
using Avalonia.Styling;

public class TabPane : TabControl
{
    public static readonly StyledProperty<ControlTheme?> TabItemThemeProperty =
        AvaloniaProperty.Register<EditableComboBoxItem, ControlTheme?>(nameof(TabItemTheme));

    public ControlTheme? TabItemTheme
    {
        get => this.GetValue(TabItemThemeProperty);
        set => this.SetValue(TabItemThemeProperty, value);
    }

    protected override void PrepareContainerForItemOverride(Control element, object? item, int index)
    {
        base.PrepareContainerForItemOverride(element, item, index);

        ControlTheme? tabItemTheme = this.TabItemTheme ?? element.FindResource("TabPane_TabItem") as ControlTheme;
        if (tabItemTheme is not null)
        {
            element.Theme = tabItemTheme;
        }
    }
}