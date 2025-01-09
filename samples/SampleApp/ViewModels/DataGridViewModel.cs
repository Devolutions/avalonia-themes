using System.Collections.Generic;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using SampleApp.Models;

namespace SampleApp.ViewModels;

public class DataGridViewModel : ObservableObject
{
  public DataGridViewModel()
  {
    var items = new List<DataGridItem>
    {
      new("computer", "PDQ-VM", "PDQ-VM$", "6/26/2023"),
      new("user", "AD TEST Guy2", "ADGuysam", "5/2/2023"),
      new("user", "krbtgt", "krbtgt", "11/10/2021")
    };
    Items = new ObservableCollection<DataGridItem>(items);
  }

  public ObservableCollection<DataGridItem> Items { get; }
}