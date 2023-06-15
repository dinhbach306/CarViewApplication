using Application;
using Application.Repository;

namespace Infrastructures
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context,
            ICarBranchRepository carBranchRepository, IFileService fileService)
        {
            _context = context;
            CarBranchRepository = carBranchRepository;
            FileService = fileService;
        }

        public ICarBranchRepository CarBranchRepository { get; }
        public IFileService FileService { get; }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}


