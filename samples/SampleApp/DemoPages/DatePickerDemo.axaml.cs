namespace SampleApp.DemoPages;

using System;
using Avalonia.Controls;

public partial class DatePickerDemo : UserControl
{
  public DatePickerDemo()
  {
    this.InitializeComponent();
    this.DatePicker2.SelectedDate = new DateTimeOffset(new DateTime(1950, 1, 1));
  }
}