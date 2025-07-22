namespace SampleApp.DemoPages;

using System;
using Avalonia.Controls;

public partial class CalendarDatePickerDemo : UserControl
{
  public CalendarDatePickerDemo()
  {
    this.InitializeComponent();
    this.DatePicker.SelectedDate = this.DatePicker2.SelectedDate = this.DatePicker3.SelectedDate = DateTime.Today;
  }
}