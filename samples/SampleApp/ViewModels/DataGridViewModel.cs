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
      new("user", "krbtgt", "krbtgt", "11/10/2021"),
      new("computer", "WIN11-VM-BT", "WIN11-VM-BT$", "11/12/2021"),
      new("computer", "RDS6", "RDS6$", "30/03/2021"),
      new("computer", "MSSQL1", "MSSQL1$", "14/10/2024"),
      new("computer", "ITMANGER-DRIVE", "ITMANGER-DRIVE$", "13/10/2021")
    };
    Items = new ObservableCollection<DataGridItem>(items);
  }

  public ObservableCollection<DataGridItem> Items { get; }
}