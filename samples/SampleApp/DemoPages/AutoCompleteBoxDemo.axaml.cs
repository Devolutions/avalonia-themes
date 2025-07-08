using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace SampleApp.DemoPages;

using System.Linq;

public partial class AutoCompleteBoxDemo : UserControl
{
  public AutoCompleteBoxDemo()
  {
    InitializeComponent();
    this.Animals.ItemsSource = new string[] 
        {"cat", "camel", "cow", "chameleon", "mouse", "lion", "zebra" }
      .OrderBy(x=>x);
  }
}