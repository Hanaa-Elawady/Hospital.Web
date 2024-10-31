using AutoMapper;
using Hospital.Data.Entities.HospitalData.DrugStorage;
using Hospital.Repository.Interfaces;
using Hospital.Repository.Specifications.DrugSpecifications;
using Hospital.Service.Dto_s.Drugs;
using Hospital.Service.Interfaces;

namespace Hospital.Service.Services
{
	public class DrugService : IDrugsService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public DrugService(IUnitOfWork unitOfWork , IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public async Task<IReadOnlyList<DrugDto>> GetAllAsync(DrugSpecifications input)
		{
			var specs = new DrugWithSpecifications(input);
			var Drugs =await _unitOfWork.Repository<Drug>().GetAllWithSpecificationsAsync(specs);
			if (Drugs is null)
				return null;

			var drugsDto = _mapper.Map<IReadOnlyList<DrugDto>>(Drugs);
			return drugsDto; 
		}

		public async Task<DrugDto> GetByIdAsync(int? Id)
		{
			var specs = new DrugWithSpecifications(Id);

			var Drug = await _unitOfWork.Repository<Drug>().GetByIdWithSpecificationsAsync(specs);
			if (Drug is null)
				return null;

			var drugDto = _mapper.Map<DrugDto>(Drug);
			return drugDto;
		}
	}
}
