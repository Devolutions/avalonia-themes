using System.Globalization;
using Avalonia.Controls;
using Avalonia.Data.Converters;

namespace DevExpress.Avalonia.Theme.Converters;

/// <summary>
///   Takes a TabItem, its parent TabControl and the name of a Border element and returns a boolean to indicate if the
///   given Border element should be visible or not
/// </summary>
/// <param name="values">TabItem, TabControl, TabControl.SelectedIndex</param>
/// <param name="parameter">the name of the Border element whose visibility is to be set</param>
/// <returns>true if the Border element should be visible</returns>
/// <remarks>
///   The 3rd element in the parameter array, TabControl.SelectedIndex, is necessary as a separate input, even though the
///   whole TabControl is also passed in. Unless this dynamically changing property is passed in, the Converter will only
///   execute once, rather than each time the selected tab changes.
/// </remarks>
public class TabBorderVisibilityConverter : IMultiValueConverter
{
  public object Convert(IList<object?> values, Type targetType, object? parameter, CultureInfo culture)
  {
    if (values[0] is not TabItem tabItem ||
        values[1] is not TabControl tabControl ||
        values[2] is not int selectedTabIndex)
      return true;

    var currentTabIndex = GetTabIndex(tabControl, tabItem);

    var isFirstTab = currentTabIndex == 0;
    var isLastTab = currentTabIndex == tabControl.Items.Count - 1;
    var isSelected = selectedTabIndex == currentTabIndex;
    var previousTabIsSelected = selectedTabIndex == currentTabIndex - 1;
    var nextTabIsSelected = selectedTabIndex == currentTabIndex + 1;
    var isLeftOfSelectedTab = currentTabIndex < selectedTabIndex;
    var isRightOfSelectedTab = currentTabIndex > selectedTabIndex;

    switch (parameter)
    {
      case "LeftBorder":
        return !isFirstTab && (isLeftOfSelectedTab || isSelected);
        break;
      case "BottomLeftCorner":
        return !isFirstTab && (isLeftOfSelectedTab || isSelected);
        break;
      case "RightBorder":
        return isLastTab || isRightOfSelectedTab || isSelected;
        break;
      case "BottomRightCorner":
        return isLastTab || isRightOfSelectedTab || isSelected;
        break;
      case "BottomLeftBorder":
        return !(previousTabIsSelected || isSelected);
        break;
      case "BottomRightBorder":
        return !(nextTabIsSelected || isSelected);
        break;
    }

    return true;
  }


  public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
  {
    throw new NotImplementedException();
  }

  private static int GetTabIndex(TabControl tabControl, TabItem tabItem)
  {
    return tabControl.Items.Cast<object>().ToList().IndexOf(tabItem);
  }
}