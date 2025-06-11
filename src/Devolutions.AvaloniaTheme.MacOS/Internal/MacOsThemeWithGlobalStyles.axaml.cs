namespace Devolutions.AvaloniaTheme.MacOS.Internal;

using Avalonia.Markup.Xaml;
using Avalonia.Styling;

/// <summary>
/// Includes the fluent theme in an application.
/// </summary>
internal class MacOsThemeWithGlobalStyles : Styles
{
    /// <summary> 
    /// Initializes a new instance of the <see cref="sp"/> class.
    /// </summary>
    /// <param name="sp">The parent's service provider.</param>
    public MacOsThemeWithGlobalStyles(IServiceProvider? sp = null)
    {
        AvaloniaXamlLoader.Load(sp, this);
    }
}