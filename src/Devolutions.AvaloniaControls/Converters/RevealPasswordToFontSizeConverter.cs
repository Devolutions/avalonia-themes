namespace Devolutions.AvaloniaControls.Converters;

using System.Globalization;
using Avalonia.Data.Converters;

public class RevealPasswordToFontSizeConverter : IMultiValueConverter
{
  public object Convert(IList<object?> values, Type targetType, object? parameter, CultureInfo culture)
  {
    if (values is not
        [char passwordChar, bool revealPassword, double defaultFontSize, double hiddenPasswordBulletFontSize])
      return double.NaN;

    bool isPasswordInput = passwordChar != '\0';

    return !isPasswordInput || revealPassword ? defaultFontSize : hiddenPasswordBulletFontSize;
  }

  public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture) =>
    throw new NotImplementedException();
}