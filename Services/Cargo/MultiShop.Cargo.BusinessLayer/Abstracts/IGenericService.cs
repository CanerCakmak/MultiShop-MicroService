namespace MultiShop.Cargo.BusinessLayer.Abstract;

public interface IGenericService<T> where T : class
{
    Task<List<T>> TGetAllAsync();
    Task<T> TGetByIdAsync(int id);

    Task TAddAsync(T entity);
    Task TAddRangeAsync(IEnumerable<T> entities);

    Task TUpdateAsync(T entity);
    Task TUpdateRangeAsync(IEnumerable<T> entities);

    Task TDeleteByIdAsync(int id);
    Task TDeleteAsync(T entity);
    Task TDeleteRangeAsync(IEnumerable<T> entities);
}
