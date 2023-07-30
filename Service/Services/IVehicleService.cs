using System;
using Service.Controllers;
using Service.Dtos.Make;
using Service.Dtos.Model;

namespace Service.Services
{
	public interface IVehicleService
	{

		Task<ServiceResponse<List<GetMakeDto>>> GetAllMake(SearchMake search);
        Task<ServiceResponse<List<GetMakeDto>>> AddMake(AddMakeDto newMake);
        Task<ServiceResponse<List<GetMakeDto>>> DeleteMake(int id);
        Task<ServiceResponse<GetMakeDto>> UpdateMake(UpdateMakeDto updatedMake);
        Task<ServiceResponse<GetMakeDto>> GetMakeSingle(int id);
        Task<ServiceResponse<List<GetModelDto>>> GetAllModel(SearchModel search);
        Task<ServiceResponse<List<GetModelDto>>> AddModel(AddModelDto newModel);
        Task<ServiceResponse<List<GetModelDto>>> DeleteModel(int id);
        Task<ServiceResponse<GetModelDto>> UpdateModel(UpdateModelDto updatedModel);
        Task<ServiceResponse<GetModelDto>> GetModelSingle(int id);
    }
}

