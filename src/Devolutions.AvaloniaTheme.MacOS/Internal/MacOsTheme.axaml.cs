namespace Devolutions.AvaloniaTheme.MacOS.Internal;

using Avalonia.Markup.Xaml;
using Avalonia.Markup.Xaml.Styling;
using Avalonia.Styling;

internal class MacOsTheme : Styles
{
    /// <summary> 
    /// Initializes a new instance of the <see cref="MacOsTheme"/> class.
    /// </summary>
    /// <param name="sp">The parent's service provider.</param>
    public MacOsTheme(IServiceProvider? sp = null)
    {
        AvaloniaXamlLoader.Load(sp, this);
#if DEBUG
        Uri themePreviewerUri = new("avares://Devolutions.AvaloniaTheme.MacOS/Design/ThemePreviewer.axaml");
        this.Resources.MergedDictionaries.Add(new ResourceInclude(themePreviewerUri) { Source = themePreviewerUri });
#endif
    }
}