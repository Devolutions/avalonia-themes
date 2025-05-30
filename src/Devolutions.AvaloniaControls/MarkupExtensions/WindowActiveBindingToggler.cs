namespace Devolutions.AvaloniaControls.MarkupExtensions;

using Avalonia.Markup.Xaml;

public class WindowActiveBindingTogglerExtension : MarkupExtension
{
  private BindingTogglerExtension? toggleBindingExtension;

  public WindowActiveBindingTogglerExtension(object whenActiveBinding, object whenInactiveBinding)
  {
    this.WhenActiveBinding = whenActiveBinding;
    this.WhenInactiveBinding = whenInactiveBinding;
  }

  [ConstructorArgument("whenActiveBinding")]
  public object WhenActiveBinding { get; init; }

  [ConstructorArgument("whenInactiveBinding")]
  public object WhenInactiveBinding { get; init; }

  public override object ProvideValue(IServiceProvider serviceProvider)
  {
    this.toggleBindingExtension ??= new BindingTogglerExtension(
      WindowIsActiveBindingExtension.CreateIsActiveBinding(),
      this.WhenActiveBinding,
      this.WhenInactiveBinding
    );

    return this.toggleBindingExtension.ProvideValue(serviceProvider);
  }
}