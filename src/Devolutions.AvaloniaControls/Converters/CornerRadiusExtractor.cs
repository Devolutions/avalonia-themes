namespace Devolutions.AvaloniaControls.Converters;

using System.Diagnostics.CodeAnalysis;
using Avalonia;
using Avalonia.Data.Converters;

public static partial class DevoConverters
{
  public static FuncValueConverter<CornerRadius, CornerRadiusSubset, CornerRadius> CornerRadiusExtractor { get; } =
    new(static (cornerRadius, subset) => new CornerRadius(
      subset.HasFlag(CornerRadiusSubset.TopLeft) ? cornerRadius.TopLeft : 0,
      subset.HasFlag(CornerRadiusSubset.TopRight) ? cornerRadius.TopRight : 0,
      subset.HasFlag(CornerRadiusSubset.BottomRight) ? cornerRadius.BottomRight : 0,
      subset.HasFlag(CornerRadiusSubset.BottomLeft) ? cornerRadius.BottomLeft : 0));
}

[Flags]
[SuppressMessage("StyleCop.CSharp.SpacingRules",
  "SA1025:Code should not contain multiple whitespace in a row",
  Justification = "Clearer for bitflags")]
public enum CornerRadiusSubset
{
    // @formatter:off
    None = 0,
    TopLeft = 0b_0001,
    TopRight = 0b_0010,
    BottomRight = 0b_0100,
    BottomLeft = 0b_1000,

    Left = 0b_1001,
    Right = 0b_0110,
    Top = 0b_0011,
    Bottom = 0b_1100,

    AllButTopLeft = 0b_1110,
    AllButBottomLeft = 0b_0111,
    AllButTopRight = 0b_1101,
    AllButBottomRight = 0b_1011

  // @formatter:on
}