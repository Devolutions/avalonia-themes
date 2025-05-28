namespace SampleApp.DemoPages;

using Avalonia.Controls;
using ViewModels;

public partial class TextBoxDemo : UserControl
{
  public TextBoxDemo()
  {
    this.InitializeComponent();
    this.DataContext = new TextBoxViewModel();
  }
}