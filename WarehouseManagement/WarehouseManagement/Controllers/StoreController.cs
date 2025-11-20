using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WarehouseManagement.DTOs;
using WarehouseManagement.Models;
using WarehouseManagement.Services.Interfaces;

namespace WarehouseManagement.Controllers
{
    [Route("api/v{version:apiVersion}/store")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly IStoreService _storeService;
        private readonly IMapper _mapper;

        public StoreController(IStoreService storeService, IMapper mapper)
        {
            _storeService = storeService;
            _mapper = mapper;
        }

        [HttpGet]
        [ApiVersion("1.0")]
        public async Task<IActionResult> GetAllAsync()
        {
            var list = await _storeService.GetAllAsync();

            return Ok(list.Select(w => _mapper.Map<StoreDto>(w)));
            
        }

        [HttpGet]
        [Route("{Id:int}")]
        [ApiVersion("1.0")]

        public async Task<IActionResult> Get(int Id)
        {
            var w = await _storeService.GetByIdAsync(Id);

            if (w == null)
                return NotFound();

            return Ok(_mapper.Map<StoreDto>(w));
        }

        [HttpPost]
        [ApiVersion("1.0")]
        public async Task<IActionResult> Create(StoreCreateDto dto)
        {
            var store = _mapper.Map<Store>(dto);
            var created = await _storeService.AddAsync(store);
            var resultDto = _mapper.Map<StoreDto>(created);
            return CreatedAtAction(nameof(Get),new { id = created.Id, version = "1.0" }, resultDto);
        }

        [HttpPut]
        [Route("{Id:int}")]
        [ApiVersion("1.0")]
        public async Task<IActionResult> Update(int Id, StoreUpdateDto dto)
        {
            var store = await _storeService.GetByIdAsync(Id);
            if (store == null) return NotFound();
            
            _mapper.Map(dto, store);

            await _storeService.UpdateAsync(store);

            return NoContent();
            
        }

        [HttpDelete]
        [Route("{Id:int}")]
        [ApiVersion("1.0")]
        public async Task<IActionResult> Delete(int Id)
        {
            var result = await _storeService.DeleteAsync(Id);

            return result ? NoContent() : NotFound();
        }
    }
}
