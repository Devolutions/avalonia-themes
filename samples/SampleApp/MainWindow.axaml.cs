using Avalonia;
using Avalonia.Controls;

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
}