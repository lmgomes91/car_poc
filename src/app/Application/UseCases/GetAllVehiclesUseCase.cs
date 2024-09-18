using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using poc.src.app.Application.Interfaces;
using poc.src.appApplication.Dtos;
using poc.src.appApplication.Mappers;


namespace poc.src.app.Application.UseCases{
    public class GetAllVehiclesUseCase : IGetAllVehiclesUseCase
    {
        private readonly IVehicleRepository _vehicleRepo;
        public GetAllVehiclesUseCase(IVehicleRepository vehicleRepository)
        {
            _vehicleRepo = vehicleRepository;
        }
        
        public async  Task<IEnumerable<VehicleDto>?> Execute(){
            try
            {
                var vehicles = await _vehicleRepo.GetAllAsync();

                var vehiclesDto = vehicles.Select(v => v.ToVehicleDto());
            
                return vehiclesDto;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                
                throw;
            }
            
        }
    }
}