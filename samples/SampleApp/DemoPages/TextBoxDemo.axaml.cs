using Avalonia.Controls;
using SampleApp.ViewModels;

namespace SampleApp.DemoPages;

public partial class TextBoxDemo : UserControl
{
  public TextBoxDemo()
  {
    InitializeComponent();
    DataContext = new TextBoxViewModel();
  }
}