namespace Devolutions.AvaloniaTheme.DevExpress.Internal;

using Avalonia.Markup.Xaml;
using Avalonia.Markup.Xaml.Styling;
using Avalonia.Styling;

internal class DevExpressTheme : Styles
{
    /// <summary> 
    /// Initializes a new instance of the <see cref="DevExpressTheme"/> class.
    /// </summary>
    /// <param name="sp">The parent's service provider.</param>
    public DevExpressTheme(IServiceProvider? sp = null)
    {
        AvaloniaXamlLoader.Load(sp, this);
#if DEBUG
        Uri themePreviewerUri = new("avares://Devolutions.AvaloniaTheme.DevExpress/Design/ThemePreviewer.axaml");
        this.Resources.MergedDictionaries.Add(new ResourceInclude(themePreviewerUri) { Source = themePreviewerUri });
#endif
    }
}