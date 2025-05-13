namespace Devolutions.AvaloniaControls.MarkupExtensions;

using Converters;
using Avalonia;
using Avalonia.Data;
using Avalonia.Markup.Xaml;
using Avalonia.Styling;
using Helpers;
using Microsoft.Extensions.DependencyInjection;

public class BindingTogglerExtension : MarkupExtension
{
    private IBinding? resolvedWhenTrueBinding;

    private IBinding? resolvedWhenFalseBinding;

    public BindingTogglerExtension(IBinding conditionBinding, object whenTrueBinding, object whenFalseBinding)
    {
        ConditionBinding = conditionBinding;
        WhenTrueBinding = whenTrueBinding;
        WhenFalseBinding = whenFalseBinding;
    }

    [ConstructorArgument("conditionBinding")]
    public IBinding ConditionBinding { get; init; }

    [ConstructorArgument("whenTrueBinding")]
    public object WhenTrueBinding { get; init; }

    [ConstructorArgument("whenFalseBinding")]
    public object WhenFalseBinding { get; init; }

    public override object ProvideValue(IServiceProvider serviceProvider)
    {
        var provideTarget = serviceProvider.GetService<IProvideValueTarget>();
        var setter = provideTarget?.TargetObject as Setter;
        var targetType = setter?.Property?.PropertyType;

        if (targetType is not null)
        {
            resolvedWhenTrueBinding ??= MarkupExtensionHelpers.GetBinding(WhenTrueBinding, targetType) ?? ObservableHelpers.Empty.ToBinding();
            resolvedWhenFalseBinding ??= MarkupExtensionHelpers.GetBinding(WhenFalseBinding, targetType) ?? ObservableHelpers.Empty.ToBinding();
        }
        else
        {
            resolvedWhenTrueBinding ??= MarkupExtensionHelpers.GetBinding<object?>(WhenTrueBinding) ?? ObservableHelpers.Empty.ToBinding();
            resolvedWhenFalseBinding ??= MarkupExtensionHelpers.GetBinding<object?>(WhenFalseBinding) ?? ObservableHelpers.Empty.ToBinding();
        }

        return new MultiBinding
        {
            Converter = MultiConverters.BooleanToChoiceConverter,
            Bindings =
            [
                ConditionBinding,
                resolvedWhenTrueBinding,
                resolvedWhenFalseBinding,
            ],
        };
    }
}