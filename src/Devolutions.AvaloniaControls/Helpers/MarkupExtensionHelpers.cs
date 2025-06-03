namespace Devolutions.AvaloniaControls.Helpers;

using System.ComponentModel;
using System.Globalization;
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

        if (v is TIn t) return SingleValueObservable(t).ToBinding();

        return TypeDescriptor.GetConverter(v.GetType()).ConvertTo(v, typeof(TIn)) is TIn t2
            ? SingleValueObservable(t2).ToBinding()
            : null;
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
                    var parseMethod = type.GetMethod("Parse", [typeof(string), typeof(IFormatProvider)]);
                    return SingleValueObservable(parseMethod?.Invoke(type, [str, CultureInfo.InvariantCulture])).ToBinding();
                }

                break;
            }
        }

        var t = TypeDescriptor.GetConverter(v.GetType()).ConvertTo(v, type);
        return t is not null
            ? SingleValueObservable(t).ToBinding()
            : null;
    }

    private static T Parse<T>(string stringValue, T _) where T : IParsable<T> =>
        T.Parse(stringValue, CultureInfo.InvariantCulture);

    private static SingleValueObservable<T> SingleValueObservable<T>(T v) => new(v);
}