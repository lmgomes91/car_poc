using System;
using System.Linq;
using System.Threading.Tasks;

namespace poc.src.app.Api.Dtos.http
{
    public class CreateVehicleRequestDto{
        public string Make { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public int Year { get; set; }
        public float Price { get; set; }
    }
}