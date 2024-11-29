using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;

namespace SampleApp.Experiments;

public partial class ToggleButtonExperiments : UserControl
{
  public ToggleButtonExperiments()
  {
    InitializeComponent();
    ToggleButton.Cursor = new Cursor(StandardCursorType.Cross);
  }

  private void Button_OnClickHandler(object? sender, RoutedEventArgs e)
  {
    ToggleButton.Content = ToggleButton.Content?.ToString() == "On" ? "Off" : "On";
  }
}