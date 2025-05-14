namespace Devolutions.AvaloniaControls.MarkupExtensions;

using Avalonia;
using Avalonia.Controls;
using Avalonia.Data;
using Avalonia.Data.Converters;
using Avalonia.Markup.Xaml;
using Converters;

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
            new MultiBinding
            {
                Converter = DevoMultiConverters.FirstNonNullValueMultiConverter,
                Bindings =
                [
                    new Binding
                    {
                        Path = "IsActive",
                        Converter = BoolConverters.Not,
                        RelativeSource = new RelativeSource
                        {
                            Mode = RelativeSourceMode.FindAncestor,
                            AncestorType = typeof(INativeWindowAvaloniaHost<AvaloniaObject>),
                        },
                        Source = new Binding
                        {
                            RelativeSource = new RelativeSource
                            {
                                Mode = RelativeSourceMode.TemplatedParent,
                            },
                        },
                    },
                    new Binding
                    {
                        Path = "IsActive",
                        Converter = BoolConverters.Not,
                        RelativeSource = new RelativeSource
                        {
                            Mode = RelativeSourceMode.FindAncestor,
                            AncestorType = typeof(INativeWindowAvaloniaHost<AvaloniaObject>),
                        },
                    },
                    new Binding
                    {
                        Path = "IsActive",
                        Converter = BoolConverters.Not,
                        RelativeSource = new RelativeSource
                        {
                            Mode = RelativeSourceMode.FindAncestor,
                            AncestorType = typeof(Window),
                        },
                        Source = new Binding
                        {
                            RelativeSource = new RelativeSource
                            {
                                Mode = RelativeSourceMode.TemplatedParent,
                            },
                        },
                    },
                    new Binding
                    {
                        Path = "IsActive",
                        Converter = BoolConverters.Not,
                        RelativeSource = new RelativeSource
                        {
                            Mode = RelativeSourceMode.FindAncestor,
                            AncestorType = typeof(Window),
                        },
                    },
                ],
            },
            this.WhenActiveBinding,
            this.WhenInactiveBinding
        );

        return this.toggleBindingExtension.ProvideValue(serviceProvider);
    }
}