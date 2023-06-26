using Application2;
using Application2.IRepository;
using Infrastructures2;

namespace Infrastructures2
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private readonly ICarBrandRepository _carBrandRepository;
        private readonly ICarTypeRepository _carTypeRepository;

        public UnitOfWork(ApplicationDbContext context,
            ICarBrandRepository carBrandRepository, ICarTypeRepository carTypeRepository)
        {
            _context = context;
            _carBrandRepository = carBrandRepository;
            _carTypeRepository = carTypeRepository;
        }



        public ICarBrandRepository CarBrandRepository => _carBrandRepository;

        public ICarTypeRepository CarTypeRepository => _carTypeRepository;

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}


