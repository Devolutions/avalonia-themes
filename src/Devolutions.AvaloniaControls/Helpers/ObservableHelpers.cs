namespace Devolutions.AvaloniaControls.Helpers;

public static class ObservableHelpers
{
    public static SingleValueObservable<T> SingleValue<T>(T v) => new(v);

    public static SingleValueObservable<T?> EmptyTyped<T>() where T : class? => new(null);

    public static readonly SingleValueObservable<object?> Empty = new(null);
}

public class SingleValueObservable<T>(T value) : IObservable<T>
{
    public IDisposable Subscribe(IObserver<T> observer)
    {
        observer.OnNext(value);
        observer.OnCompleted();
        return EmptyDisposable.Instance;
    }

    private sealed class EmptyDisposable : IDisposable
    {
        public static readonly EmptyDisposable Instance = new();

        private EmptyDisposable() { }

        public void Dispose() { }
    }
}