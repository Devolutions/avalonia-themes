namespace Devolutions.AvaloniaControls.MarkupExtensions;

using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Helpers;

public class WindowActiveResourceTogglerExtension : MarkupExtension
{
    private WindowActiveBindingTogglerExtension? toggler;

    public WindowActiveResourceTogglerExtension(object activeResourceKey, object inactiveResourceKey)
    {
        this.ActiveResourceKey = activeResourceKey;
        this.InactiveResourceKey = inactiveResourceKey;
    }

    [ConstructorArgument("activeResourceKey")]
    public object ActiveResourceKey { get; init; }

    [ConstructorArgument("inactiveResourceKey")]
    public object InactiveResourceKey { get; init; }

    public override object ProvideValue(IServiceProvider serviceProvider)
    {
        if (Design.IsDesignMode)
        {
            return Application.Current?.GetResourceObservable(this.ActiveResourceKey).ToBinding() ?? ObservableHelpers.Empty.ToBinding();
        }

        this.toggler ??= new WindowActiveBindingTogglerExtension(
            Application.Current?.GetResourceObservable(this.ActiveResourceKey).ToBinding() ?? ObservableHelpers.Empty.ToBinding(),
            Application.Current?.GetResourceObservable(this.InactiveResourceKey).ToBinding() ?? ObservableHelpers.Empty.ToBinding()
        );

        return this.toggler.ProvideValue(serviceProvider);
    }
}