namespace DotNetTest.Domain.SeedWork;

public interface IFinder<T, in TKey> where T : IDto where TKey : IComparable
{
    Task<T> FindByIdAsync(TKey id);
}