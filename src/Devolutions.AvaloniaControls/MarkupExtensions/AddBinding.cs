namespace Devolutions.AvaloniaControls.MarkupExtensions;

using Avalonia.Data.Converters;
using Converters;

public class AddBinding : AbstractMultipleValueBinding<double>
{
    public AddBinding(object a, object b) : base(a, b) { }

    public AddBinding(object a, object b, params object[] extraBindings) : base(a, b, extraBindings) { }

    protected override IMultiValueConverter MultiValueConverter => DevoDoubleConverters.Add;
}