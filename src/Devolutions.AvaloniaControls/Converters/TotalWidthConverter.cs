namespace Devolutions.AvaloniaControls.Converters;

using System.Globalization;
using Avalonia.Data.Converters;

public class TotalWidthConverter : IMultiValueConverter
{
  public object Convert(IList<object?> values, Type targetType, object? parameter, CultureInfo culture)
  {
    if (values[0] is not double width || values[1] is not int sideMargin) return 200d;

    return width + 2 * sideMargin;
  }

  public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) =>
    throw new NotImplementedException();
}