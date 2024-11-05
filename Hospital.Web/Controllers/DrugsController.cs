using Hospital.Data.Entities.HospitalData.DrugStorage;
using Hospital.Repository.Specifications.DrugSpecifications;
using Hospital.Service.Dto_s.Drugs;
using Hospital.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Web.Controllers
{
    public class DrugsController : BaseController
    {
        private readonly IDrugsService _drugsService;

		public DrugsController(IDrugsService drugsService)
		{
			_drugsService = drugsService;
		}
		[HttpGet]
		public async Task<ActionResult<IReadOnlyList<DrugDto>>> GetAllDrugsAsync([FromQuery] DrugSpecifications specs)
		=> Ok(await _drugsService.GetAllAsync(specs));

		[HttpGet]
		public async Task<ActionResult<IReadOnlyList<DrugDto>>> GetByIdAsync(int Id)
		=> Ok(await _drugsService.GetByIdAsync(Id));

		[HttpPost]
		public async Task<ActionResult<string>> ReservationDrug(string Drugname, int Quantity)
			=> Ok(await _drugsService.ReservationDrug(Drugname , Quantity));

	}
}
