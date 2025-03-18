using System.Globalization;
using Avalonia;
using Avalonia.Data.Converters;

namespace Devolutions.AvaloniaTheme.MacOS.Converters;

/// <summary>
///   Takes a _single_ input and returns a boolean if it is unset.
/// </summary>
/// <param name="value">Any property or property source that may or may not exist</param>
/// <returns>True if the input resolves to AvaloniaProperty.UnsetValue, else False</returns>
/// <remarks>
///   This Converter can be used to check for the presence of a control or property. It needs to be a MultiValueConverter,
///   because Avalonia will not call a normal converter if the input value is `unset`.
///   Having this converter is useful, because Avalonia's AND and OR converters will return 'unset' if any of the inputs
///   are unset, even when one of the inputs is a boolean and would be sufficient to verify the conjunction!
/// </remarks>
public class IsUnsetConverter : IMultiValueConverter
{
  public object Convert(IList<object?> values, Type targetType, object? parameter, CultureInfo culture)
  {
    return values[0] == AvaloniaProperty.UnsetValue;
  }

  public object ConvertBack(IList<object?> values, Type targetType, object? parameter, CultureInfo culture)
  {
    throw new NotImplementedException();
  }
}