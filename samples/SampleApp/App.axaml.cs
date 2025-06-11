namespace SampleApp;

using System;
using System.IO;
using System.Net;
using System.Xml;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Avalonia.Styling;
using Avalonia.Svg.Skia;
using ViewModels;

public class App : Application
{
    private readonly Styles themeStylesContainer = new();
    private Styles? devExpressStyles;
    private Styles? linuxYaruStyles;
    private Styles? macOsStyles;
    private bool devToolsAttached;
    public static Theme? CurrentTheme { get; set; }

    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);

        if (!Design.IsDesignMode)
        {
            this.Styles.Clear();
            this.Styles.Add(this.themeStylesContainer);
        }

        this.linuxYaruStyles = this.Resources["LinuxYaruStyles"] as Styles;
        this.devExpressStyles = this.Resources["DevExpressStyles"] as Styles;
        this.macOsStyles = this.Resources["MacOsStyles"] as Styles;

        GC.KeepAlive(typeof(Svg).Assembly);
        GC.KeepAlive(typeof(SvgImageExtension).Assembly);

        if (!Design.IsDesignMode)
        {
            var theme = this.DetectDesignTheme();

            if (OperatingSystem.IsWindows())
                theme ??= new DevExpressTheme();
            else if (OperatingSystem.IsMacOS())
                theme ??= new MacOsTheme();
            else if (OperatingSystem.IsLinux())
                theme ??= new LinuxYaruTheme();
            else
                theme ??= new MacOsTheme();

            SetTheme(theme);
        }
    }

    private Theme? DetectDesignTheme()
    {
        try
        {
            var doc = new XmlDocument();
            var dir = Directory.GetCurrentDirectory();
            var debug = Directory.GetParent(dir);
            var bin = Directory.GetParent(debug!.FullName);
            if (debug.Name.Equals("Debug", StringComparison.OrdinalIgnoreCase) && bin!.Name.Equals("bin", StringComparison.OrdinalIgnoreCase))
            {
                var projDir = Directory.GetParent(bin.FullName);
                doc.Load(Path.Join(projDir!.FullName, "App.axaml"));
                var styles = doc["Application"]!["Application.Styles"];
                foreach (var obj in styles!)
                    if (obj is XmlElement elem && elem.Name.Equals("StyleInclude", StringComparison.OrdinalIgnoreCase))
                    {
                        var source = elem.GetAttribute("Source");
                        return source switch
                        {
                            "avares://Devolutions.AvaloniaTheme.MacOS/MacOSTheme.axaml" => new MacOsTheme(),
                            "avares://Devolutions.AvaloniaTheme.Linux/LinuxTheme.axaml" => new LinuxYaruTheme(),
                            "avares://Devolutions.AvaloniaTheme.DevExpress/DevExpressTheme.axaml" => new DevExpressTheme(),
                            _ => null,
                        };
                    }
            }
        }
        catch (Exception)
        { /* ignore */
        }

        return null;
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
            if (app.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktopLifetime)
            {
                var oldWindow = desktopLifetime.MainWindow;
                var dataContext = oldWindow?.DataContext;
                MainWindow newWindow = new() { DataContext = dataContext };
                desktopLifetime.MainWindow = newWindow;
                newWindow.Show();
                oldWindow?.Close();
            }
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (this.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            desktop.MainWindow = new MainWindow { DataContext = new MainWindowViewModel() };

        base.OnFrameworkInitializationCompleted();
    }

    public void AttacheDevToolsOnce()
    {
        if (this.devToolsAttached) return;

        this.AttachDeveloperTools();
        this.devToolsAttached = true;
    }
}

public abstract class Theme
{
    public abstract string Name { get; }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return this.Equals((Theme)obj);
    }

    protected bool Equals(Theme other) =>
        this.Name == other.Name;

    public override int GetHashCode() =>
        this.Name.GetHashCode();
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