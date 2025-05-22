namespace Devolutions.AvaloniaControls.MarkupExtensions;

using Avalonia.Data.Converters;
using Converters;

public class MultiplyBinding : AbstractMultipleValueBinding<double>
{
    public MultiplyBinding(object a, object b) : base(a, b) { }

    public MultiplyBinding(object a, object b, params object[] extraBindings) : base(a, b, extraBindings) { }

    protected override IMultiValueConverter MultiValueConverter => DevoDoubleConverters.Multiply;
}