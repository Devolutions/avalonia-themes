using System.Globalization;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Data.Converters;

namespace MacOS.Avalonia.Theme.Converters;

public class ClassToChoiceConverter : IMultiValueConverter
{
  public object Convert(IList<object?> values, Type targetType, object? parameter, CultureInfo culture)
  {
    var selectedChoice = values[0] is Classes classes && parameter is string className && classes.Contains(className)
      ? values[1]
      : values[2];
    return selectedChoice ?? AvaloniaProperty.UnsetValue;
  }

  public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
  {
    throw new NotImplementedException();
  }
}