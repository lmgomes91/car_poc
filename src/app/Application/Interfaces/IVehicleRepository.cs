using System;
using System.Linq;
using System.Threading.Tasks;
using poc.src.app.Api.Dtos.http;
using poc.src.appDomain.Entities;


namespace poc.src.app.Application.Interfaces
{
    
    public interface IVehicleRepository
    {
        Task<List<Vehicle>> GetAllAsync();
        Task<Vehicle?> GetByIdAsync(int id);
        Task<Vehicle?> CreateAsync(Vehicle vehicleModel);
        Task<Vehicle?> UpdateAsync(int id, UpdateVehicleRequestDto vehicle);
        Task<Vehicle?> DeleteAsync(int id);
    }
}