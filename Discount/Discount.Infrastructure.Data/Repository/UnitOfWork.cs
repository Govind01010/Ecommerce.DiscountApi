using Discount.Domain.Repository;

namespace Discount.Infrastructure.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private IGenericRepository<Domain.Entities.Discount> _discountRepository;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public IGenericRepository<Domain.Entities.Discount> DiscountRepository
        {
            get
            {
                if (_discountRepository == null)
                {
                    _discountRepository = new GenericRepository<Domain.Entities.Discount>(_context);
                }
                return _discountRepository;
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
