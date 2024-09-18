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
    public class DeleteVehiclesUseCase : IDeleteVehiclesUseCase
    {
        private readonly IVehicleRepository _vehicleRepo;
        public DeleteVehiclesUseCase(IVehicleRepository vehicleRepository)
        {
            _vehicleRepo = vehicleRepository;
        }

        public async Task<bool?> Execute(int id)
        {
            try
            {
                var vehicleModel = await _vehicleRepo.DeleteAsync(id);

                if(vehicleModel == null){
                    return null;
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");

                throw;
            }
        }

        
    }
}