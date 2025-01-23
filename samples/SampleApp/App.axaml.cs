using System;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Avalonia.Svg.Skia;

namespace SampleApp;

public class App : Application
{
  public override void Initialize()
  {
    AvaloniaXamlLoader.Load(this);

    GC.KeepAlive(typeof(Avalonia.Svg.Skia.Svg).Assembly);
    GC.KeepAlive(typeof(SvgImageExtension).Assembly);
  }

  public override void OnFrameworkInitializationCompleted()
  {
    if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop) desktop.MainWindow = new MainWindow();

    base.OnFrameworkInitializationCompleted();
  }
}