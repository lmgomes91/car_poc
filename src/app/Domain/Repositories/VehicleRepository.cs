using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using poc.src.app.Api.Dtos.http;
using poc.src.app.Application.Interfaces;
using poc.src.app.Infra.Persistence;
using poc.src.appDomain.Entities;

namespace Name
{
    public class VehicleRepository : IVehicleRepository
    {

        private readonly ApplicationDbContext _context;

        public VehicleRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Vehicle?> CreateAsync(Vehicle vehicleModel)
        {
            await _context.Vehicle.AddAsync(vehicleModel);
            await _context.SaveChangesAsync();
            return vehicleModel;
        }

        public async Task<Vehicle?> DeleteAsync(int id)
        {
            var vehicleModel = await _context.Vehicle.FirstOrDefaultAsync(v => v.Id == id);

            if(vehicleModel == null){
                return null;
            }

            _context.Vehicle.Remove(vehicleModel);
            await _context.SaveChangesAsync();

            return vehicleModel;
        }

        public async Task<List<Vehicle>> GetAllAsync()
        {
            return await _context.Vehicle.ToListAsync();
        }

        public async Task<Vehicle?> GetByIdAsync(int id)
        {
            return await _context.Vehicle.FindAsync(id);
        }

        public async Task<Vehicle?> UpdateAsync(int id, UpdateVehicleRequestDto vehicle)
        {
            var vehicleModel = await _context.Vehicle.FirstOrDefaultAsync(v => v.Id == id);

            if(vehicleModel == null){
                return null;
            }

            vehicleModel.Make = vehicle.Make;
            vehicleModel.Model = vehicle.Model;
            vehicleModel.Price = vehicle.Price;
            vehicleModel.Year = vehicle.Year;
            
            await _context.SaveChangesAsync();

            return vehicleModel;

        }
    }

}