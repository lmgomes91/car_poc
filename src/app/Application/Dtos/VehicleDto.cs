using System;
using System.Linq;
using System.Threading.Tasks;

namespace poc.src.appApplication.Dtos
{
    public class VehicleDto{
        public string Model { get; set; } = string.Empty;
        public int Year { get; set; }

        public int Id { get; set; }
    }
}