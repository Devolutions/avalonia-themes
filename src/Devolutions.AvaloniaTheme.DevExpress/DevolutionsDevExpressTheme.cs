namespace Devolutions.AvaloniaTheme.DevExpress;

using Avalonia.Markup.Xaml;
using Avalonia.Markup.Xaml.Styling;
using Avalonia.Styling;

/// <summary>
/// Includes Devolutions's Windows theme, based on DevExpress's look, in an application.
/// </summary>
public class DevolutionsDevExpressTheme : Styles
{
    /// <summary> 
    /// Initializes a new instance of the <see cref="DevolutionsDevExpressTheme"/> class.
    /// </summary>
    /// <param name="sp">The parent's service provider.</param>
    public DevolutionsDevExpressTheme(IServiceProvider? sp = null)
    {
        AvaloniaXamlLoader.Load(sp, this);
#if DEBUG
        var themePreviewerUri = new Uri("avares://Devolutions.AvaloniaTheme.DevExpress/Design/ThemePreviewer.axaml");
        this.Resources.MergedDictionaries.Add(new ResourceInclude(themePreviewerUri) { Source = themePreviewerUri });
#endif
    }
}