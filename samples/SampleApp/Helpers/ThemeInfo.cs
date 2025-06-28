namespace SampleApp.Helpers;

using CommunityToolkit.Mvvm.ComponentModel;

public partial class ThemeInfo : ObservableObject
{
  [ObservableProperty] private string? currentThemeName;

  public static ThemeInfo Instance { get; } = new();
}