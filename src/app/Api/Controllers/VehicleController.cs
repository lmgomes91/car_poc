using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using poc.src.app.Infra.Persistence;
using Microsoft.AspNetCore.Mvc;
using poc.src.appApplication.Mappers;
using Microsoft.EntityFrameworkCore;
using poc.src.app.Application.Interfaces;
using poc.src.app.Application.Dtos.http;
using poc.src.app.Api.Dtos.http;

namespace poc.src.app.Api.Controllers
{
    [Route("api/vehicles")]
    [ApiController]
    public class VehicleController : ControllerBase
    {

        private readonly ICreateVehiclesUseCase _createVehicles;
        private readonly IDeleteVehiclesUseCase _deleteVehicles;
        private readonly IGetAllVehiclesUseCase _getAllVehicles;
        private readonly IGetByIdVehiclesUseCase _getByIdVehicles;
        private readonly IUptadeVehiclesUseCase _uptadeVehicles;


        public VehicleController(
            ICreateVehiclesUseCase createVehiclesUseCase, 
            IDeleteVehiclesUseCase deleteVehiclesUseCase, 
            IGetAllVehiclesUseCase getAllVehiclesUseCase, 
            IGetByIdVehiclesUseCase getByIdVehiclesUseCase, 
            IUptadeVehiclesUseCase uptadeVehiclesUseCase
        )
        {
            _createVehicles = createVehiclesUseCase;
            _deleteVehicles = deleteVehiclesUseCase;
            _getAllVehicles = getAllVehiclesUseCase;
            _getByIdVehicles = getByIdVehiclesUseCase;
            _uptadeVehicles = uptadeVehiclesUseCase;

        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var vehicles = await _getAllVehicles.Execute();

            return Ok(vehicles);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var vehicle = await _getByIdVehicles.Execute(id);
            
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

            var vehicle = await _createVehicles.Execute(create);

            if (vehicle == null)
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(GetById), new { id = vehicle.Id }, vehicle.ToVehicleDto());
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateVehicleRequestDto updateVehicle)
        {
            var vehicle = await _uptadeVehicles.Execute(id, updateVehicle);

            if (vehicle == null)
            {
                return NotFound();
            }


            return Ok(vehicle);

        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var vehicleModel = await _deleteVehicles.Execute(id);

            if (vehicleModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}