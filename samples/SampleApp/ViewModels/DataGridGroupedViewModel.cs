namespace SampleApp.ViewModels;

using System.Collections.Generic;
using Avalonia.Collections;
using CommunityToolkit.Mvvm.ComponentModel;
using Models;

public class DataGridGroupedViewModel : ObservableObject
{
  public DataGridGroupedViewModel()
  {
    List<DataGridItem> items =
    [
      new("computer", "PDQ-VM", "PDQ-VM$", "6/26/2023"),
      new("user", "AD TEST Guy2", "ADGuysam", "5/2/2023"),
      new("user", "krbtgt", "krbtgt", "11/10/2021"),
      new("computer", "WIN11-VM-BT", "WIN11-VM-BT$", "11/12/2021"),
      new("computer", "RDS6", "RDS6$", "30/03/2021"),
      new("computer", "MSSQL1", "MSSQL1$", "14/10/2024"),
      new("computer", "ITMANGER-DRIVE", "ITMANGER-DRIVE$", "13/10/2021")
    ];
    this.Items = new DataGridCollectionView(items);
    this.Items.GroupDescriptions.Add(new DataGridPathGroupDescription("ItemType"));
  }

  public DataGridCollectionView Items { get; }
}