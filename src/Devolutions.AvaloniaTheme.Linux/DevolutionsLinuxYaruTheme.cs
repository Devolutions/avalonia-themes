namespace Devolutions.AvaloniaTheme.Linux;

using Avalonia.Markup.Xaml;
using Avalonia.Styling;

public class DevolutionsLinuxYaruTheme : Styles
{
    /// <summary> 
    /// Initializes a new instance of the <see cref="DevolutionsLinuxYaruTheme"/> class.
    /// </summary>
    /// <param name="sp">The parent's service provider.</param>
    public DevolutionsLinuxYaruTheme(IServiceProvider? sp = null)
    {
        AvaloniaXamlLoader.Load(sp, this);
    }
}