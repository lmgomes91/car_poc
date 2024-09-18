using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using poc.src.app.Application.Dtos.http;
using poc.src.app.Application.Interfaces;
using poc.src.appApplication.Dtos;
using poc.src.appApplication.Mappers;
using poc.src.appDomain.Entities;


namespace poc.src.app.Application.UseCases
{
    public class CreateVehiclesUseCase : ICreateVehiclesUseCase
    {
        private readonly IVehicleRepository _vehicleRepo;
        public CreateVehiclesUseCase(IVehicleRepository vehicleRepository)
        {
            _vehicleRepo = vehicleRepository;
        }

        public async Task<Vehicle?> Execute(CreateVehicleRequestDto create)
        {
            try
            {
                var vehicleModel = create.ToVehicleFromCreateDto();
            

                await _vehicleRepo.CreateAsync(vehicleModel);

                if (vehicleModel == null)
                {
                    return null;
                }

                return vehicleModel;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");

                throw;
            }
        }
    }
}