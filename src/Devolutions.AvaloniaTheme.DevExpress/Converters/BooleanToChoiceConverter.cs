using System.Globalization;
using Avalonia;
using Avalonia.Data.Converters;

namespace Devolutions.AvaloniaTheme.DevExpress.Converters;

public class BooleanToChoiceConverter : IMultiValueConverter
{
  public object Convert(IList<object?> values, Type targetType, object? parameter, CultureInfo culture)
  {
    var selectedChoice = values[0] is true ? values[1] : values[2];
    return selectedChoice ?? AvaloniaProperty.UnsetValue;
  }

  public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
  {
    throw new NotImplementedException();
  }
}