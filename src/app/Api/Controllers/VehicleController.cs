using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using poc.src.app.Api.Dtos.http;
using poc.src.app.Infra.Persistence;
using Microsoft.AspNetCore.Mvc;
using poc.src.appApplication.Mappers;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using poc.src.app.Application.Interfaces;
using Name;

namespace poc.src.app.Api.Controllers
{
    [Route("api/vehicles")]
    [ApiController]
    public class VehicleController : ControllerBase
    {

        // private readonly ApplicationDbContext _context;
        private readonly IVehicleRepository _vehicleRepo;
        
        public VehicleController(ApplicationDbContext context, IVehicleRepository vehicleRepository)
        {
            // _context = context;
            _vehicleRepo = vehicleRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var vehicles = await _vehicleRepo.GetAllAsync();

            var vehiclesDto = vehicles.Select(v => v.ToVehicleDto());
            
            return Ok(vehiclesDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var vehicle = await _vehicleRepo.GetByIdAsync(id);
            if (vehicle == null)
            {
                return NotFound();
            }
            return Ok(vehicle);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateVehicleRequestDto create)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var vehicleModel = create.ToVehicleFromCreateDto();
            

            await _vehicleRepo.CreateAsync(vehicleModel);

            if (vehicleModel == null)
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(GetById), new { id = vehicleModel.Id }, vehicleModel.ToVehicleDto());
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateVehicleRequestDto updateVehicle){
            var vehicleModel = await _vehicleRepo.UpdateAsync(id, updateVehicle);

            if(vehicleModel == null){
                return NotFound();
            }


            return Ok(vehicleModel.ToVehicleDto());

        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id){
            var vehicleModel = await _vehicleRepo.DeleteAsync(id);

            if(vehicleModel == null){
                return NotFound();
            }
            
            return NoContent();
        }
    }
}