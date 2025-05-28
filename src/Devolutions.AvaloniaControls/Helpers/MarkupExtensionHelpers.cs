namespace Devolutions.AvaloniaControls.Helpers;

using System.ComponentModel;
using Avalonia;
using Avalonia.Data;

public static class MarkupExtensionHelpers
{
  // Dynamic approach is slightly faster than using reflection, see: https://stackoverflow.com/a/78582306
  public static IBinding? GetBinding<TIn>(object? v)
  {
    switch (v)
    {
      case null:
        return null;
      case IBinding binding:
        return binding;
      case string str:
      {
        var isParsable = typeof(TIn).GetInterfaces()
          .Any(static c => c.IsGenericType && c.GetGenericTypeDefinition() == typeof(IParsable<>));
        if (isParsable)
        {
          TIn value = Parse(str, (dynamic)default(TIn)!);
          return SingleValueObservable(value).ToBinding();
        }

        break;
      }
    }

    if (typeof(TIn) == typeof(object)) return SingleValueObservable(v).ToBinding();

    return typeof(TIn) == typeof(object)
      ? SingleValueObservable(v).ToBinding()
      : SingleValueObservable(TypeDescriptor.GetConverter(v.GetType()).ConvertTo(v, typeof(TIn))).ToBinding();
  }

  public static IBinding? GetBinding(object? v, Type type)
  {
    switch (v)
    {
      case null:
        return null;
      case IBinding binding:
        return binding;
      case string str:
      {
        var isParsable = type.GetInterfaces().Any(static c => c.IsGenericType && c.GetGenericTypeDefinition() == typeof(IParsable<>));
        if (isParsable)
        {
          var parseMethod = type.GetMethod("Parse", [typeof(string)]);
          return SingleValueObservable(parseMethod?.Invoke(type, [str])).ToBinding();
        }

        break;
      }
    }

    return SingleValueObservable(TypeDescriptor.GetConverter(v.GetType()).ConvertTo(v, type)).ToBinding();
  }

  private static T Parse<T>(string stringValue, T _) where T : IParsable<T> =>
    T.Parse(stringValue, null);

  private static SingleValueObservable<T> SingleValueObservable<T>(T v) => new(v);
}