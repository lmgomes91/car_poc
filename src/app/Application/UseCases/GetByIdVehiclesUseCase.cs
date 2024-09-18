using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using poc.src.app.Application.Interfaces;
using poc.src.appApplication.Dtos;
using poc.src.appApplication.Mappers;
using poc.src.appDomain.Entities;


namespace poc.src.app.Application.UseCases
{
    public class GetByIdVehiclesUseCase : IGetByIdVehiclesUseCase
    {
        private readonly IVehicleRepository _vehicleRepo;
        public GetByIdVehiclesUseCase(IVehicleRepository vehicleRepository)
        {
            _vehicleRepo = vehicleRepository;
        }

        public async Task<Vehicle?> Execute(int id)
        {
            try
            {
                var vehicle = await _vehicleRepo.GetByIdAsync(id);

                if (vehicle == null)
                {
                    return null;
                }

                return vehicle;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");

                throw;
            }
        }
    }
}