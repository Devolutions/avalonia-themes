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
        this.ConditionBinding = conditionBinding;
        this.WhenTrueBinding = whenTrueBinding;
        this.WhenFalseBinding = whenFalseBinding;
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
            this.resolvedWhenTrueBinding ??=
                MarkupExtensionHelpers.GetBinding(this.WhenTrueBinding, targetType) ?? ObservableHelpers.Empty.ToBinding();
            this.resolvedWhenFalseBinding ??=
                MarkupExtensionHelpers.GetBinding(this.WhenFalseBinding, targetType) ?? ObservableHelpers.Empty.ToBinding();
        }
        else
        {
            this.resolvedWhenTrueBinding ??=
                MarkupExtensionHelpers.GetBinding<object?>(this.WhenTrueBinding) ?? ObservableHelpers.Empty.ToBinding();
            this.resolvedWhenFalseBinding ??=
                MarkupExtensionHelpers.GetBinding<object?>(this.WhenFalseBinding) ?? ObservableHelpers.Empty.ToBinding();
        }

        return new MultiBinding
        {
            Converter = DevoMultiConverters.BooleanToChoiceConverter,
            Bindings =
            [
                this.ConditionBinding, this.resolvedWhenTrueBinding, this.resolvedWhenFalseBinding,
            ],
        };
    }
}