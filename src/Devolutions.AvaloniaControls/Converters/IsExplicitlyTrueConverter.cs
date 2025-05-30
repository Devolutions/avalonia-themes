namespace Devolutions.AvaloniaControls.Converters;

using System.Globalization;
using Avalonia.Data.Converters;

/// <summary>
///   Takes a _single_ input and returns a boolean based on whether the input is a boolean and true.
/// </summary>
/// <param name="value">Any property that may or may not exist</param>
/// <returns>True if the input resolves to true, else False</returns>
/// <remarks>
///   This Converter can be used to check for a property when the source may not even exist. It needs to be a
///   MultiValueConverter,
///   because Avalonia will not call a normal converter if the input value is `unset`.
///   Having this converter is useful, because Avalonia's AND and OR converters will return 'unset' if any of the inputs
///   are unset, even when one of the inputs is a boolean and would be sufficient to verify the conjunction!
/// </remarks>
public class IsExplicitlyTrueConverter : IMultiValueConverter
{
  public object Convert(IList<object?> values, Type targetType, object? parameter, CultureInfo culture) =>
    values[0] is true;

  public object ConvertBack(IList<object?> values, Type targetType, object? parameter, CultureInfo culture) =>
    throw new NotImplementedException();
}