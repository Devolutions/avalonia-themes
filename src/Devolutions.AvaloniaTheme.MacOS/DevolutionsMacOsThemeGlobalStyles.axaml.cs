namespace Devolutions.AvaloniaTheme.MacOS;

using Avalonia.Markup.Xaml;
using Avalonia.Styling;

public class DevolutionsMacOsThemeGlobalStyles : Styles
{
    /// <summary> 
    /// Initializes a new instance of the <see cref="DevolutionsMacOsThemeGlobalStyles"/> class.
    /// </summary>
    /// <param name="sp">The parent's service provider.</param>
    public DevolutionsMacOsThemeGlobalStyles(IServiceProvider? sp = null)
    {
        AvaloniaXamlLoader.Load(sp, this);
    }
}