using Application;
using Application.IRepository;

namespace Infrastructures
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private readonly ICarBrandRepository _carBrandRepository;

        public UnitOfWork(ApplicationDbContext context,
            ICarBrandRepository carBrandRepository)
        {
            _context = context;
            _carBrandRepository = carBrandRepository;
        }

        public ICarBrandRepository CarBrandRepository => _carBrandRepository;

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}


