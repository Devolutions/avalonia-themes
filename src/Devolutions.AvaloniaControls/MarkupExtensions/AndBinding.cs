namespace Devolutions.AvaloniaControls.MarkupExtensions;

using Avalonia.Data.Converters;

public class AndBinding : AbstractMultipleValueBinding<bool>
{
  public AndBinding(object a, object b) : base(a, b) { }

  public AndBinding(object a, object b, params object[] extraBindings) : base(a, b, extraBindings) { }

  protected override IMultiValueConverter MultiValueConverter => BoolConverters.And;
}