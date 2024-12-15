using System.Globalization;
using Avalonia.Data.Converters;

namespace Devolutions.MacOS.Avalonia.Theme.Converters;

public class SelectedIndexToPopupOffsetConverter : IMultiValueConverter
{
  public object Convert(IList<object?> values, Type targetType, object? parameter, CultureInfo culture)
  {
    double offset = 0;

    if (values is [int index, int rowHeight, int initialBottomMargin, double maxDropDownHeight, int popupTrimHeight] &&
        index >= 0)
    {
      var effectivePopupHeight = maxDropDownHeight - popupTrimHeight;
      var baseOffset = (index + 1) * -rowHeight - initialBottomMargin;
      offset = -effectivePopupHeight < baseOffset ? baseOffset : -effectivePopupHeight;
    }

    return offset;
  }

  public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
  {
    throw new NotImplementedException();
  }
}