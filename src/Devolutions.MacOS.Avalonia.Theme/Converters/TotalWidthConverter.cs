using System.Globalization;
using Avalonia.Data.Converters;

namespace Devolutions.MacOS.Avalonia.Theme.Converters;

public class TotalWidthConverter : IMultiValueConverter
{
  public object Convert(IList<object?> values, Type targetType, object? parameter, CultureInfo culture)
  {
    const double defaultWidth = 200;
    if (values[0] is double width && values[1] is int sideMargin)
      return width + 2 * sideMargin;
    return defaultWidth;
  }

  public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
  {
    throw new NotImplementedException();
  }
}