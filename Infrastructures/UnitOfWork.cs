using Application;
using Application.Repository;

namespace Infrastructures
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context,
            ICarBrandRepository carBranchRepository /*, IFileService fileService*/)
        {
            _context = context;
            CarBrandRepository = carBranchRepository;
            //FileService = fileService;
        }

        public ICarBrandRepository CarBrandRepository { get; }
        public IFileService FileService { get; }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}


