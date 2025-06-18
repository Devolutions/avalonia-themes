namespace Devolutions.AvaloniaTheme.MacOS.Internal;

using Avalonia.Markup.Xaml;
using Avalonia.Markup.Xaml.Styling;
using Avalonia.Styling;

internal class MacOsThemeWithGlobalStyles : Styles
{
    public MacOsThemeWithGlobalStyles(IServiceProvider? sp = null)
    {
        AvaloniaXamlLoader.Load(sp, this);
#if DEBUG
        Uri themePreviewerUri = new("avares://Devolutions.AvaloniaTheme.MacOS/Design/ThemePreviewer.axaml");
        this.Resources.MergedDictionaries.Add(new ResourceInclude(themePreviewerUri) { Source = themePreviewerUri });
#endif
    }
}