namespace Devolutions.AvaloniaControls.Converters;

using System.Globalization;
using Avalonia;
using Avalonia.Data.Converters;
using Avalonia.Styling;

public class BooleanAndThemeToChoiceConverter : IMultiValueConverter
{
    public object Convert(IList<object?> values, Type targetType, object? parameter, CultureInfo culture)
    {
        object? selectedChoice;
        if (Application.Current?.ActualThemeVariant == ThemeVariant.Dark)
            selectedChoice = values[0] is true ? values[2] : values[4];
        else
            selectedChoice = values[0] is true ? values[1] : values[3];

        return selectedChoice ?? AvaloniaProperty.UnsetValue;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) =>
        throw new NotImplementedException();
}