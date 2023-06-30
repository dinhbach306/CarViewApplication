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
        private readonly ICarModelRepository _carModelRepository;

        public UnitOfWork(ApplicationDbContext context,
            ICarBrandRepository carBrandRepository, ICarTypeRepository carTypeRepository,
            ICarModelRepository carModelRepository)
        {
            _context = context;
            _carBrandRepository = carBrandRepository;
            _carTypeRepository = carTypeRepository;
            _carModelRepository = carModelRepository;
        }



        public ICarBrandRepository CarBrandRepository => _carBrandRepository;

        public ICarTypeRepository CarTypeRepository => _carTypeRepository;
        public ICarModelRepository CarModelRepository => _carModelRepository;

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}


