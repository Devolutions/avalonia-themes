using System.Globalization;
using Avalonia.Data.Converters;

namespace MacOS.Avalonia.Theme.Converters;

public class SelectedIndexToPopupOffsetConverter : IMultiValueConverter
{
  public object Convert(IList<object?> values, Type targetType, object? parameter, CultureInfo culture)
  {
    if (values is not
          [int index, int rowHeight, int initialFirstItemDistance, double maxDropDownHeight, int popupTrimHeight]
        || index < 0) return 0d;

    var effectivePopupHeight = maxDropDownHeight - popupTrimHeight;
    double offset = (index + 1) * -rowHeight - initialFirstItemDistance;
    return -effectivePopupHeight < offset ? offset : -effectivePopupHeight;
  }

  public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
  {
    throw new NotImplementedException();
  }
}