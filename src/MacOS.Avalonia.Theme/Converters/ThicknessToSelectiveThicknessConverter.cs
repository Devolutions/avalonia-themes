using System.Globalization;
using Avalonia;
using Avalonia.Data.Converters;

namespace MacOS.Avalonia.Theme.Converters;

public class ThicknessToSelectiveThicknessConverter : IValueConverter
{
  public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
  {
    Console.WriteLine($"value: {value}");
    Console.WriteLine($"parameter: {parameter}");
    if (value is not Thickness thickness || parameter is not Thickness thicknessFactors)
      return AvaloniaProperty.UnsetValue;

    Console.WriteLine($"thickness: {thickness}");
    Console.WriteLine($"thicknessFactors: {thicknessFactors}");
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