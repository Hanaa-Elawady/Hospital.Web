using AutoMapper;
using Hospital.Data.Contexts;
using Hospital.Data.Entities.HospitalData.DrugStorage;
using Hospital.Repository.Interfaces;
using Hospital.Repository.Specifications.DrugSpecifications;
using Hospital.Repository.Specifications.InventorySpecifications;
using Hospital.Service.Dto_s.Drugs;
using Hospital.Service.Interfaces;

namespace Hospital.Service.Services
{
	public class DrugService : IDrugsService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public DrugService(IUnitOfWork unitOfWork , IMapper mapper , HospitalDbContext context)
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

		public async Task<string> ReservationDrug(string name, int quantityNeeded)
		{
			var drugspecs = new DrugWithSpecifications(name);
			var DrugCheck = await _unitOfWork.Repository<Drug>().GetByNameWithSpecificationsAsync(drugspecs);
			if (DrugCheck is null)
				return "No Drug With this name";

			var drugDto = _mapper.Map<DrugDto>(DrugCheck);

			if (drugDto.AvailableQuantityInStock < quantityNeeded)
				return "No Enough Quantity ";

			var inventorySpecification = new InventorySpecification { DrugID = drugDto.DrugID, Sort ="ExpireDateAsc" };
			var inventorySpecs = new InventoryWithSpecification(inventorySpecification);
			var invenroties = await _unitOfWork.Repository<Inventory>().GetAllWithSpecificationsAsync(inventorySpecs);

			int quantity = quantityNeeded;

			for (var i = 0; i < invenroties.Count; i++)
			{
				var quantityInStock = invenroties[i].AvailableQuantityInStock;
				if (quantityInStock >= quantity)
				{
					updateInventory(invenroties[i], quantityInStock - quantity);
					await _unitOfWork.CompleteAsync();
					return "Done";
				}

				quantity -= quantityInStock;
				updateInventory(invenroties[i], 0);

			}
			return "Problem Found";
		}


		private async void updateInventory(Inventory inventory , int newQuantity)
		{
			var newInventory = _mapper.Map<Inventory>(inventory);
			newInventory.AvailableQuantityInStock = newQuantity;
			_unitOfWork.Repository<Inventory>().Update(inventory);
		}
	}
}
