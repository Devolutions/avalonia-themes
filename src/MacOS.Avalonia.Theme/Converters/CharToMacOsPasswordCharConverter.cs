using System.Globalization;
using Avalonia.Data.Converters;

namespace MacOS.Avalonia.Theme.Converters;

public class CharToMacOsPasswordCharConverter : IValueConverter
{
  public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
  {
    const char blackCircleSymbol = '\u25CF';
    const char emptyCharacter = '\0';

    return value is char and not emptyCharacter ? blackCircleSymbol : emptyCharacter;
  }

  public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
  {
    throw new NotImplementedException();
  }
}