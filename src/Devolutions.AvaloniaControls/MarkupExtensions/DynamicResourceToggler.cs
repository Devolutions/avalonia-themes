namespace Devolutions.AvaloniaControls.MarkupExtensions;

using Avalonia;
using Avalonia.Controls;
using Avalonia.Data;
using Avalonia.Markup.Xaml;
using Helpers;

public class DynamicResourceTogglerExtension : MarkupExtension
{
  private BindingTogglerExtension? toggler;

  public DynamicResourceTogglerExtension(object conditionBinding, object whenTrueResourceKey, object whenFalseResourceKey)
  {
    this.ConditionBinding = conditionBinding as IBinding ?? MarkupExtensionHelpers.GetBinding<bool>(conditionBinding)!;
    this.WhenTrueResourceKey = whenTrueResourceKey;
    this.WhenFalseResourceKey = whenFalseResourceKey;
  }

  [ConstructorArgument("conditionBinding")]
  public IBinding ConditionBinding { get; init; }

  [ConstructorArgument("whenTrueResourceKey")]
  public object WhenTrueResourceKey { get; init; }

  [ConstructorArgument("whenFalseResourceKey")]
  public object WhenFalseResourceKey { get; init; }

  public override object ProvideValue(IServiceProvider serviceProvider)
  {
    this.toggler ??= new BindingTogglerExtension(
      this.ConditionBinding,
      Application.Current?.GetResourceObservable(this.WhenTrueResourceKey).ToBinding() ?? ObservableHelpers.Empty.ToBinding(),
      Application.Current?.GetResourceObservable(this.WhenFalseResourceKey).ToBinding() ?? ObservableHelpers.Empty.ToBinding()
    );

    return this.toggler.ProvideValue(serviceProvider);
  }
}