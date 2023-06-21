using Application;
using Application.IRepository;

namespace Infrastructures
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private readonly ICarBranchRepository _carBranchRepository;

        public UnitOfWork(ApplicationDbContext context,
            ICarBranchRepository carBranchRepository)
        {
            _context = context;
            _carBranchRepository = carBranchRepository;
        }

        public ICarBranchRepository CarBranchRepository => _carBranchRepository;

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}


