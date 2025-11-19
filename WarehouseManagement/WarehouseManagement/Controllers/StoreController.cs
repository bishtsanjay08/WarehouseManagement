using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WarehouseManagement.Services.Interfaces;

namespace WarehouseManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly IStoreService _storeService;

        public StoreController(IStoreService storeService)
        {
            _storeService = storeService;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllAsync()
        {
            var list = await _storeService.GetAllAsync();

            return Ok(list);
            
        }

        [HttpGet]
        [Route("{Id:int}")]

        public async Task<IActionResult> Get(int Id)
        {
            var list = await _storeService.GetByIdAsync(Id);

            if (list == null)
                return NotFound();

            return Ok(list);
        }
    }
}
