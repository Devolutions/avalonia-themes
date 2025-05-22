namespace Devolutions.AvaloniaControls.MarkupExtensions;

using Avalonia.Data.Converters;

public class OrBinding : AbstractMultipleValueBinding<bool>
{
    public OrBinding(object a, object b) : base(a, b) { }

    public OrBinding(object a, object b, params object[] extraBindings) : base(a, b, extraBindings) { }

    protected override IMultiValueConverter MultiValueConverter => BoolConverters.Or;
}