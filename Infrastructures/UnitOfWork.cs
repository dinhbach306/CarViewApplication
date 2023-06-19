using Application;
using Application.IRepository;
using Application.Repository;
using Infrastructures.Repository;

namespace Infrastructures
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context,
            ICarBrandRepository carBrandRepository /*, IFileService fileService*/,
            ICarTypeRepository carTypeRepository, ICarModelRepository carModelRepository)
        {
            _context = context;
            CarBrandRepository = carBrandRepository;
            CarTypeRepository = carTypeRepository;
            CarModelRepository = carModelRepository;
            //FileService = fileService;
        }

        public ICarBrandRepository CarBrandRepository { get; }

        public IFileService FileService { get; }

        public ICarTypeRepository CarTypeRepository { get; }

        public ICarModelRepository CarModelRepository { get; }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}


