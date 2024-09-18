using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using poc.src.app.Api.Dtos.http;
using poc.src.app.Application.Dtos.http;
using poc.src.app.Application.Interfaces;
using poc.src.appApplication.Dtos;
using poc.src.appApplication.Mappers;
using poc.src.appDomain.Entities;


namespace poc.src.app.Application.UseCases{
    public class UptadeVehiclesUseCase : IUptadeVehiclesUseCase
    {
        private readonly IVehicleRepository _vehicleRepo;
        public UptadeVehiclesUseCase(IVehicleRepository vehicleRepository)
        {
            _vehicleRepo = vehicleRepository;
        }

        public async Task<VehicleDto?> Execute(int id, UpdateVehicleRequestDto updateVehicle)
        {
            try
            {
                var vehicleModel = await _vehicleRepo.UpdateAsync(id, updateVehicle);

                if(vehicleModel == null){
                    return null;
                }

                return vehicleModel.ToVehicleDto();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");

                throw;
            }
        }
        
    }
}