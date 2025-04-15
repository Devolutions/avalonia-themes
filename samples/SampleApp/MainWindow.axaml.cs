using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Styling;

namespace SampleApp;

public partial class MainWindow : Window
{
  public MainWindow()
  {
    InitializeComponent();
#if DEBUG
    this.AttachDevTools();
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