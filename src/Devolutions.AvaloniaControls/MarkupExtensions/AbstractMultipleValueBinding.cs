namespace Devolutions.AvaloniaControls.MarkupExtensions;

using Avalonia.Data;
using Avalonia.Data.Converters;
using Avalonia.Markup.Xaml;
using Helpers;

public abstract class AbstractMultipleValueBinding<TIn> : MarkupExtension
{
  protected readonly IBinding a;

  protected readonly IBinding b;

  protected readonly IBinding[] extraBindings = [];

  private MultiBinding? multiBindingInstance;

  protected AbstractMultipleValueBinding(object a, object b)
  {
    this.a = GetBinding(a)!;
    this.b = GetBinding(b)!;
  }

  protected AbstractMultipleValueBinding(object a, object b, params object[] bindings) : this(a, b)
  {
    this.extraBindings = bindings.Select(GetBinding).SkipNulls().ToArray();
  }

  protected abstract IMultiValueConverter MultiValueConverter { get; }

  public override object ProvideValue(IServiceProvider serviceProvider)
  {
    this.multiBindingInstance ??= new MultiBinding
    {
      Bindings = [this.a, this.b, ..this.extraBindings],
      Converter = this.MultiValueConverter,
    };
    return this.multiBindingInstance;
  }

  private static IBinding? GetBinding(object? v) => MarkupExtensionHelpers.GetBinding<TIn>(v);
}