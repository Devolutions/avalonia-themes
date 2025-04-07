using Avalonia;
using Avalonia.Data.Converters;

namespace Devolutions.AvaloniaTheme.Linux.Yaru.Converters;

public static class Converters
{
  public static FuncValueConverter<CornerRadius, CornerRadiusSubset, CornerRadius> CornerRadiusExtractor { get; } = new(
    static (cornerRadius, subset) =>
      subset switch
      {
        CornerRadiusSubset.Left => new CornerRadius(cornerRadius.TopLeft, 0, 0, cornerRadius.BottomLeft),
        CornerRadiusSubset.Right => new CornerRadius(0, cornerRadius.TopRight, cornerRadius.BottomRight, 0),
        CornerRadiusSubset.Top => new CornerRadius(cornerRadius.TopLeft, cornerRadius.TopRight, 0, 0),
        CornerRadiusSubset.Bottom => new CornerRadius(0, 0, cornerRadius.BottomRight, cornerRadius.BottomLeft),
        _ => cornerRadius
      });
}

public enum CornerRadiusSubset
{
  Left,
  Right,
  Top,
  Bottom
}