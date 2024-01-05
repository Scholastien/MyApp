namespace MyApp.Application.Extensions;

public static class EnumerableExtensions
{
    public static IEnumerable<(T item, int index)> WithIndex<T>(this IEnumerable<T> self)
        => self.Select((item, index) => (item, index));

    public static uint Sum(this IEnumerable<uint> self)
        => self.Aggregate<uint, uint>(0, (current, u) => current + u);
}