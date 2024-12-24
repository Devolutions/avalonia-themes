using System.Collections.ObjectModel;
using AvaloniaControls.Models;

namespace SampleApp.DemoPages;

public class TreeViewDemoViewModel
{
  public TreeViewDemoViewModel()
  {
    Nodes = new ObservableCollection<TreeViewNode>
    {
      new("MacOS UI elements", new ObservableCollection<TreeViewNode>
      {
        new("Button", new ObservableCollection<TreeViewNode>
        {
          new("Button comparison"), new("default button")
        }),
        new("CheckBox", new ObservableCollection<TreeViewNode>
        {
          new("CheckBox.psd")
        })
      })
    };
  }

  public ObservableCollection<TreeViewNode> Nodes { get; }
}