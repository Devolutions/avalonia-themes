namespace SampleApp.Experiments;

using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;

public partial class ToggleButtonExperiments : UserControl
{
  public ToggleButtonExperiments()
  {
    this.InitializeComponent();
    this.ToggleButton.Cursor = new Cursor(StandardCursorType.Cross);
  }

  private void Button_OnClickHandler(object? sender, RoutedEventArgs e)
  {
    this.ToggleButton.Content = this.ToggleButton.Content?.ToString() == "On" ? "Off" : "On";
  }
}