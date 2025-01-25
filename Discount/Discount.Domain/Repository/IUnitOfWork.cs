namespace Discount.Domain.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Entities.Discount> DiscountRepository { get; }
        void SaveChanges();
        Task SaveChangesAsync();
    }
}
