namespace Devolutions.AvaloniaControls.Converters;

using System.Globalization;
using Avalonia;
using Avalonia.Data.Converters;

/// <summary>
///   Allows to provide different choices for each of the given options.
/// </summary>
/// <param name="values[0]">The input that the choice depends on (e.g. 'Horizontal').</param>
/// <param name="values[1..]">The choices (AvaloniaProperty values).</param>
/// <param name="parameter">
///   A string containing two or more options that determine the choice, separated by commas (e.g.
///   'None,Horizontal,Vertical,All').
/// </param>
/// <returns>An AvaloniaProperty value.</returns>
/// <remarks>
///   Given choices are mapped to the list of possible options - if there are less choices than options, the last choice is
///   used as default.
/// </remarks>
public class OptionsToChoiceConverter : IMultiValueConverter
{
  public object Convert(IList<object?> values, Type targetType, object? parameter, CultureInfo culture)
  {
    string option = values[0]?.ToString() ?? string.Empty;
    string[] options = (parameter as string)?.Split(',') ?? [];
    int optionsIndex = Array.IndexOf(options, option);

    object? selectedChoice = optionsIndex + 1 < values.Count ? values[optionsIndex + 1] : values[^1];
    return selectedChoice ?? AvaloniaProperty.UnsetValue;
  }

  public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) =>
    throw new NotImplementedException();
}