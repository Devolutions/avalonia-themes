using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace SampleApp.DemoPages;

public partial class TreeViewDemo : UserControl
{
  public TreeViewDemo()
  {
    InitializeComponent();
    DataContext = new TreeViewDemoViewModel();
  }
}