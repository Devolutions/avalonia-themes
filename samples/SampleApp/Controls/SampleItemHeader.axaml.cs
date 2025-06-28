namespace SampleApp.Controls;

using System;
using System.ComponentModel;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Helpers;

public partial class SampleItemHeader : UserControl, INotifyPropertyChanged
{
  public new event PropertyChangedEventHandler? PropertyChanged;

  private void OnPropertyChanged(string name) =>
    this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

  public static readonly StyledProperty<string?> TitleProperty =
    AvaloniaProperty.Register<SampleItemHeader, string?>(nameof(Title));

  public static readonly StyledProperty<string> ApplicableToProperty =
    AvaloniaProperty.Register<SampleItemHeader, string>(nameof(ApplicableTo), "MacOS");

  public string? Title
  {
    get => this.GetValue(TitleProperty);
    set => this.SetValue(TitleProperty, value);
  }

  public string ApplicableTo
  {
    get => this.GetValue(ApplicableToProperty);
    set => this.SetValue(ApplicableToProperty, value);
  }

  private bool IsApplicable =>
    this.ApplicableTo.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).Any(theme =>
      string.Equals(theme, ThemeInfo.Instance.CurrentThemeName, StringComparison.OrdinalIgnoreCase));

  public string? Status => this.IsApplicable ? "🟢" : "🔴";


  public SampleItemHeader()
  {
    this.InitializeComponent();
  }

  protected override void OnInitialized()
  {
    base.OnInitialized();
    this.OnPropertyChanged(nameof(this.Status)); // let Avalonia know to re-evaluate the Status binding
  }
}