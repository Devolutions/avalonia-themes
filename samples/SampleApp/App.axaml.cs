using System;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Avalonia.Styling;
using Avalonia.Svg.Skia;
using SampleApp.ViewModels;

namespace SampleApp;

public class App : Application
{
  private readonly Styles themeStylesContainer = new();
  private Styles? linuxYaruStyles;
  private Styles? devExpressStyles;
  private Styles? macOsStyles;
  public static Theme? CurrentTheme { get; set; }
  
  public override void Initialize()
  {
    Styles.Add(themeStylesContainer);
    
    AvaloniaXamlLoader.Load(this);
    this.linuxYaruStyles = this.Resources["LinuxYaruStyles"] as Styles;
    this.devExpressStyles = this.Resources["DevExpressStyles"] as Styles;
    this.macOsStyles = this.Resources["MacOsStyles"] as Styles;

    GC.KeepAlive(typeof(Avalonia.Svg.Skia.Svg).Assembly);
    GC.KeepAlive(typeof(SvgImageExtension).Assembly);

    Theme theme;
    if (OperatingSystem.IsWindows())
    {
      theme = new DevExpressTheme();
    } else if (OperatingSystem.IsMacOS())
    {
      theme = new MacOsTheme();
    }
    else if (OperatingSystem.IsLinux())
    {
      theme = new LinuxYaruTheme();
    }
    else
    {
      theme = new MacOsTheme();
    }
    
    SetTheme(theme);
  }

  public static void SetTheme(Theme theme)
  {
    var app = (App)Current!;
    var previousTheme = CurrentTheme;
    CurrentTheme = theme;

    var reopenWindow = previousTheme != null && previousTheme.Name != theme.Name;
    
    var styles = theme switch
    {
      LinuxYaruTheme => app.linuxYaruStyles,
      DevExpressTheme => app.devExpressStyles,
      MacOsTheme => app.macOsStyles,
      _ => null,
    };

    app.themeStylesContainer.Clear();
    app.themeStylesContainer.AddRange(styles!);

    if (reopenWindow)
    {
      if (app.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktopLifetime)
      {
        var oldWindow = desktopLifetime.MainWindow;
        var dataContext = oldWindow?.DataContext;
        var newWindow = new MainWindow() { DataContext = dataContext };
        desktopLifetime.MainWindow = newWindow;
        newWindow.Show();
        oldWindow?.Close();
      }
    }
  }

  public override void OnFrameworkInitializationCompleted()
  {
    if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop) desktop.MainWindow = new MainWindow() { DataContext = new MainWindowViewModel() };

    base.OnFrameworkInitializationCompleted();
  }
}

public abstract class Theme
{
  public abstract string Name { get; }

  public override bool Equals(object? obj)
  {
    if (obj is null) return false;
    if (ReferenceEquals(this, obj)) return true;
    if (obj.GetType() != GetType()) return false;
    return Equals((Theme)obj);
  }

  protected bool Equals(Theme other)
  {
    return Name == other.Name;
  }

  public override int GetHashCode()
  {
    return Name.GetHashCode();
  }
}

public class LinuxYaruTheme : Theme
{
  public override string Name => "Linux - Yaru";
}

public class DevExpressTheme : Theme
{
  public override string Name => "Windows - DevExpress";
}

public class MacOsTheme : Theme
{
  public override string Name => "MacOS";
}