namespace Devolutions.AvaloniaControls.Converters;

using Avalonia.Controls;
using Avalonia.Data.Converters;

public static partial class DevoConverters
{
  public static FuncValueConverter<Classes, string, bool> HasClass { get; } =
    new(static (classes, classToCheck) => classToCheck is not null && classes?.Contains(classToCheck) == true);
}