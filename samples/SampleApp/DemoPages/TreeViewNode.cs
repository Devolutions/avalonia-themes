using System.Collections.ObjectModel;

namespace AvaloniaControls.Models;

public class TreeViewNode
{
  public TreeViewNode(string title)
  {
    Title = title;
  }

  public TreeViewNode(string title, ObservableCollection<TreeViewNode> subNodes)
  {
    Title = title;
    SubNodes = subNodes;
  }

  public ObservableCollection<TreeViewNode>? SubNodes { get; }
  public string Title { get; }
}