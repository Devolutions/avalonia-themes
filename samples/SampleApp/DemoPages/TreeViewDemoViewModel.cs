using System.Collections.ObjectModel;
using AvaloniaControls.Models;

namespace SampleApp.DemoPages;

public class TreeViewDemoViewModel
{
  public TreeViewDemoViewModel()
  {
    Nodes = new ObservableCollection<TreeViewNode>
    {
      new("Animals", new ObservableCollection<TreeViewNode>
      {
        new("Mammals", new ObservableCollection<TreeViewNode>
        {
          new("Lion"), new("Cat"), new("Zebra")
        })
      })
    };
  }

  public ObservableCollection<TreeViewNode> Nodes { get; }
}