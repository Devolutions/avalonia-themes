namespace Devolutions.AvaloniaControls.Converters;

using System.Globalization;
using Avalonia.Data.Converters;
using Avalonia.Media;

/// <summary>
///   Converts a Brush and CSS class(es) into a CSS string for SVG path styling.
/// </summary>
/// <param name="value">The SolidColorBrush to be converted into a CSS color.</param>
/// <param name="parameter">A string containing one or more CSS class names (starting with '.'), separated by commas.</param>
/// <returns>A string containing CSS for SVG path styling.</returns>
/// <remarks>
///   Even though we just need a colour, the input needs to be a brush, because the colour is theme-dependent
///   but theme-dependent colours can only be accessed as `DynamicResource` and Binding only allows `StaticResource`.
/// </remarks>
public class ColorToCssFillConverter : IValueConverter
{
  public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
  {
    if (value is not SolidColorBrush brush) return ".st0 {fill : #000000; }";

    string classes = parameter as string ?? ".st0, .st1, .st2, .st3";

    return $"{classes} {{fill : {RemoveAlphaChannel(brush.Color)}; }}";
  }

  public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture) =>
    throw new NotImplementedException();

  private static string RemoveAlphaChannel(Color argbColor)
  {
    string hexString = argbColor.ToString();
    if (hexString.Length != 9) return hexString;
    return "#" + hexString.Substring(3);
  }
}