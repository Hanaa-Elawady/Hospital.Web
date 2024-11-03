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
        [HttpGet]
        public async Task<ActionResult<Drug>> GetAllDrugTypesAsync()
        => Ok(await _drugsService.GetAllDrugTypesAsync());
        [HttpGet]
        public async Task<Drug> GetDrugAsync(int? id)
            => await _drugsService.GetDrugByIdAsync(id);
        [HttpGet]
        public async Task<IReadOnlyList<Order>> GetOrdersAsync()
            => await _drugsService.GetAllOrdersAsync();

    }
}
