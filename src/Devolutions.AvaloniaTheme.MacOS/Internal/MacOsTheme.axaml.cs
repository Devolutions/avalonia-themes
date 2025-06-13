namespace Devolutions.AvaloniaTheme.MacOS.Internal;

using Avalonia.Markup.Xaml;
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
    }
}