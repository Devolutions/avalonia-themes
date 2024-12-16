using System.Globalization;
using Avalonia.Data.Converters;

namespace Devolutions.MacOS.Avalonia.Theme.Converters;

public class SelectedIndexToPopupOffsetConverter : IMultiValueConverter
{
  public object Convert(IList<object?> values, Type targetType, object? parameter, CultureInfo culture)
  {
    if (values is not [int index, int rowHeight, int initialBottomMargin, double maxDropDownHeight, int popupTrimHeight]
        || index < 0) return 0d;

    var effectivePopupHeight = maxDropDownHeight - popupTrimHeight;
    double baseOffset = (index + 1) * -rowHeight - initialBottomMargin;
    return -effectivePopupHeight < baseOffset ? baseOffset : -effectivePopupHeight;
  }

  public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
  {
    throw new NotImplementedException();
  }
}