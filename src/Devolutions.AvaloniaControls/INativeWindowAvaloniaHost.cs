namespace Devolutions.AvaloniaControls;

using Avalonia;

public interface INativeWindowAvaloniaHost<out TAvaloniaObjectHost> where TAvaloniaObjectHost : AvaloniaObject
{
  public static readonly StyledProperty<bool> IsActiveProperty = AvaloniaProperty.Register<TAvaloniaObjectHost, bool>(nameof(IsActive), true);

  public TAvaloniaObjectHost Host { get; }

  public bool IsActive { get; set; }
}