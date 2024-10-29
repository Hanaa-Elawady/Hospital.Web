using Hospital.Data.Entities.HospitalData.DrugStorage;
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
		public async Task<ActionResult<Drug>> GetAllDrugsAsync()
		=> Ok(await _drugsService.GetAllDrugsAsync());

	}
}
