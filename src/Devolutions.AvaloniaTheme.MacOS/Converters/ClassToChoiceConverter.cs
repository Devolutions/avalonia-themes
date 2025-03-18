using System.Globalization;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Data.Converters;

namespace Devolutions.AvaloniaTheme.MacOS.Converters;

public class ClassToChoiceConverter : IMultiValueConverter
{
  public object Convert(IList<object?> values, Type targetType, object? parameter, CultureInfo culture)
  {
    var secondOption = values.Count >= 3 ? values[2] : AvaloniaProperty.UnsetValue;

    var selectedChoice = values[0] is Classes classes && parameter is string className && classes.Contains(className)
      ? values[1]
      : secondOption;
    return selectedChoice ?? AvaloniaProperty.UnsetValue;
  }

  public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
  {
    throw new NotImplementedException();
  }
}