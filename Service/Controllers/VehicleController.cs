using System;
using Azure;
using Microsoft.AspNetCore.Mvc;
using Service.Dtos.Make;
using Service.Dtos.Model;
using Service.Services;

namespace Service.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehicleController : ControllerBase
	{
        private readonly IVehicleService _vehicleService;
        public VehicleController(IVehicleService vehicleService)
		{
            _vehicleService = vehicleService;

        }

        [HttpPost("GetMake")]

        public async Task<ActionResult<ServiceResponse<List<GetMakeDto>>>> GetMake(SearchMake search)
        {
            return Ok(await _vehicleService.GetAllMake(search));
        }

        [HttpPost]

        public async Task<ActionResult<ServiceResponse<List<GetMakeDto>>>> AddMake(AddMakeDto newMake)
        {
            var response = await _vehicleService.AddMake(newMake);
            return Ok(response);
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<ServiceResponse<GetMakeDto>>> DeleteMake(int id)
        {
            var response = await _vehicleService.DeleteMake(id);
            return Ok(response);
        }

        [HttpPut]

        public async Task<ActionResult<ServiceResponse<List<GetMakeDto>>>> UpdateMake(UpdateMakeDto updateMake)
        {
            var response = await _vehicleService.UpdateMake(updateMake);
            return Ok(response);
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<ServiceResponse<GetMakeDto>>> GetMakeSingle(int id)
        {
            var response = await _vehicleService.GetMakeSingle(id);
            if (response.Data is null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpPost("Model/GetAll")]

        public async Task<ActionResult<ServiceResponse<List<GetModelDto>>>> GetAllModels(SearchModel search)
        {
            return Ok(await _vehicleService.GetAllModel(search));
        }

        [HttpPost("Model")]

        public async Task<ActionResult<ServiceResponse<List<GetModelDto>>>> AddModel(AddModelDto newModel)
        {
            var response = await _vehicleService.AddModel(newModel);
            return Ok(response);
        }
        [HttpDelete("Model/{id}")]

        public async Task<ActionResult<ServiceResponse<GetModelDto>>> DeleteModel(int id)
        {
            var response = await _vehicleService.DeleteModel(id);
            return Ok(response);
        }

        [HttpPut("Model")]

        public async Task<ActionResult<ServiceResponse<List<GetModelDto>>>> UpdateMake(UpdateModelDto updateModel)
        {
            var response = await _vehicleService.UpdateModel(updateModel);
            return Ok(response);
        }

        [HttpGet("Model/{id}")]

        public async Task<ActionResult<ServiceResponse<GetMakeDto>>> GetModelSingle(int id)
        {
            var response = await _vehicleService.GetModelSingle(id);
            if (response.Data is null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }


    }
}

