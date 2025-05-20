using System.Globalization;
using Avalonia;
using Avalonia.Data.Converters;

namespace Devolutions.AvaloniaTheme.MacOS.Converters;

public class ThicknessToSelectiveThicknessConverter : IValueConverter
{
  public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
  {
    Console.WriteLine($"thickness: {value}, parameter {parameter}");
    if (value is not Thickness thickness || parameter is not Thickness thicknessFactors)
      return AvaloniaProperty.UnsetValue;
    Console.WriteLine($"thickness.Top {thickness.Top}, thicknessFactors.Top {thicknessFactors.Top}");
    return new Thickness(
      thickness.Left * thicknessFactors.Left,
      thickness.Top * thicknessFactors.Top,
      thickness.Right * thicknessFactors.Right,
      thickness.Bottom * thicknessFactors.Bottom
    );
  }

  public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
  {
    throw new NotImplementedException();
  }
}