using System;
using System.Linq;
using System.Threading.Tasks;
using poc.src.app.Api.Dtos.http;
using poc.src.appApplication.Dtos;
using poc.src.appDomain.Entities;

namespace poc.src.appApplication.Mappers{
    public static class VehicleMapper{

        public static VehicleDto ToVehicleDto(this Vehicle vehicle){
            return new VehicleDto{
                Model = vehicle.Model,
                Year = vehicle.Year,
                Id = vehicle.Id
            };
        }

        public static Vehicle ToVehicleFromCreateDto(this CreateVehicleRequestDto createVehicle){
            return new Vehicle{
                Make = createVehicle.Make,
                Model = createVehicle.Model,
                Price = createVehicle.Price,
                Year = createVehicle.Year 
            };
        }

    }
}