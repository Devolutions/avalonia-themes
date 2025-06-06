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
      new("Computer", "PDQ-VM", "PDQ-VM$", "6/26/2023"),
      new("User", "AD TEST Guy2", "ADGuysam", "5/2/2023"),
      new("User", "krbtgt", "krbtgt", "11/10/2021"),
      new("Computer", "WIN11-VM-BT", "WIN11-VM-BT$", "11/12/2021"),
      new("Computer", "RDS6", "RDS6$", "30/03/2021"),
      new("Computer", "MSSQL1", "MSSQL1$", "14/10/2024"),
      new("Computer", "ITMANGER-DRIVE", "ITMANGER-DRIVE$", "13/10/2021")
    ];
    this.Items = new DataGridCollectionView(items);
    this.Items.GroupDescriptions.Add(new DataGridPathGroupDescription("ItemType"));
  }

  public DataGridCollectionView Items { get; }
}