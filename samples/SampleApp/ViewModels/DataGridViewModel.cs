using System.Collections.Generic;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using SampleApp.Models;

namespace SampleApp.ViewModels;

public class DataGridViewModel : ObservableObject
{
  public DataGridViewModel()
  {
    var people = new List<Person>
    {
      new("Neil", "Armstrong"),
      new("Buzz", "Lightyear"),
      new("James", "Kirk")
    };
    People = new ObservableCollection<Person>(people);
  }

  public ObservableCollection<Person> People { get; }
}