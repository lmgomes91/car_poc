using System;
using System.Linq;
using System.Threading.Tasks;
using poc.src.app.Api.Dtos.http;
using poc.src.app.Application.Dtos.http;
using poc.src.appDomain.Entities;


namespace poc.src.app.Application.Interfaces
{
    public interface IDeleteVehiclesUseCase {
        Task<bool?> Execute(int id);
    }
}