namespace Devolutions.AvaloniaTheme.MacOS;

using Avalonia.Markup.Xaml;
using Avalonia.Styling;

/// <summary>
/// Include Devolution's MacOs theme's optional global styles in an application.
/// </summary>
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