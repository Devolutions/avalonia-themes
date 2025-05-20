using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Input;
using Avalonia.Styling;

namespace SampleApp;

public partial class MainWindow : Window
{
  public MainWindow()
  {
    InitializeComponent();
#if DEBUG
    bool useAccelerate = Environment.GetEnvironmentVariable("USE_AVALONIA_ACCELERATE_TOOLS")?.ToLowerInvariant() == "true";
    
    if (useAccelerate)
    {
      // Enable Accelerate dev tools (AvaloniaUI.DiagnosticsSupport) - requiring a licence to use
      (Application.Current as App)?.AttacheDevToolsOnce(); 
      // Enable original free dev tools (Avalonia.Diagnostics) as an additional option available on F10
      this.AttachDevTools(new KeyGesture(Key.F10));
    }
    else
    {
      // Enable original free dev tools (Avalonia.Diagnostics)
      this.AttachDevTools(); 
    }
#endif
  }

  private void Themes_OnSelectionChanged(object? sender, SelectionChangedEventArgs e)
  {
      var cb = sender as SelectingItemsControl;
      if (cb?.SelectedItem is Theme newTheme)
      {
          App.SetTheme(newTheme);
      }
  }

  private void ThemeVariants_OnSelectionChanged(object? sender, SelectionChangedEventArgs e)
  {
      var cb = sender as SelectingItemsControl;
      if (cb?.SelectedItem is ThemeVariant themeVariant)
      {
          Application.Current!.RequestedThemeVariant = themeVariant;
      }
  }
}