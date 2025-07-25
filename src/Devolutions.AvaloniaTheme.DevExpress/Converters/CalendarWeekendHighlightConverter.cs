namespace Devolutions.AvaloniaTheme.DevExpress.Converters;

using System.Globalization;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Data.Converters;
using Avalonia.Media;

public class CalendarWeekendHighlightConverter : IMultiValueConverter
{
    public object Convert(IList<object?> values, Type targetType, object? parameter, CultureInfo culture)
    {
        if (values is not [Control calendarDayButton, Brush weekdayBrush, Brush weekendBrush, _]) return AvaloniaProperty.UnsetValue;

        if (values[3] is not DayOfWeek firstDayOfWeek) firstDayOfWeek = DayOfWeek.Sunday;

        int column = Grid.GetColumn(calendarDayButton);

        int saturdayColumn = 6 - (int)firstDayOfWeek;
        int sundayColumn = (saturdayColumn + 1) % 7;

        return column == saturdayColumn || column == sundayColumn ? weekendBrush : weekdayBrush;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) =>
        throw new NotImplementedException();
}