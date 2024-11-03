using Hospital.Data.Entities.HospitalData.DrugStorage;
using Hospital.Repository.Interfaces;
using Hospital.Service.Interfaces;

namespace Hospital.Service.Services
{
    public class DrugService : IDrugsService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DrugService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IReadOnlyList<Drug>> GetAllDrugsAsync()
        => await _unitOfWork.Repository<Drug>().GetAllAsync();

        public async Task<IReadOnlyList<DrugType>> GetAllDrugTypesAsync()
        => await _unitOfWork.Repository<DrugType>().GetAllAsync();


        public async Task<IReadOnlyList<Order>> GetAllOrdersAsync()
        => await _unitOfWork.Repository<Order>().GetAllAsync();

        public async Task<Drug> GetDrugByIdAsync(int? productId)
        {
            if (productId == null)
                throw new Exception("id can not be null");

            return await _unitOfWork.Repository<Drug>().GetByIdAsync(productId);
        }
    }
}
