using System;
using AutoMapper;
using Azure;
using Microsoft.EntityFrameworkCore;
using Ninject.Modules;
using Service.Controllers;
using Service.Data;
using Service.Dtos.Make;
using Service.Dtos.Model;

namespace Service.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;


        public VehicleService(IMapper mapper, DataContext context) 
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<ServiceResponse<List<GetMakeDto>>> AddMake(AddMakeDto newMake)
        {
            var response = new ServiceResponse<List<GetMakeDto>>();
            try
            {
                
                var check = await _context.Makes.FirstOrDefaultAsync(m => m.Name.ToLower().Equals(newMake.Name.ToLower()));
                if(check is not null)
                {
                    throw new Exception($"manufacturer '{newMake.Name}' alredy exists");
                }
                var make = _mapper.Map<Make>(newMake);
                _context.Makes.Add(make);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<ServiceResponse<List<GetMakeDto>>> DeleteMake(int id)
        {
            var response = new ServiceResponse<List<GetMakeDto>>();
            try
            {
                var make = await _context.Makes.FirstOrDefaultAsync(c => c.Id == id);

                if (make is null)
                {
                    throw new Exception("Manufacturer not found");
                }
                _context.Makes.Remove(make);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }


        public async Task<ServiceResponse<List<GetMakeDto>>> GetAllMake(SearchMake search)
        {
            var response = new ServiceResponse<List<GetMakeDto>>();
            var dbMakes = _context.Makes.Where(m => m.Name.Contains(search.Name));
            dbMakes = search.Order == "asc" ? dbMakes.OrderBy(m=>m.Name) : dbMakes.OrderByDescending(m=>m.Name);
            response.Data = await dbMakes.Select(m => _mapper.Map<GetMakeDto>(m)).ToListAsync();
            return response;
        }

        public async Task<ServiceResponse<GetMakeDto>> GetMakeSingle(int id)
        {
            var response = new ServiceResponse<GetMakeDto>();
            try
            {
                var make = await _context.Makes
                .FirstOrDefaultAsync(m => m.Id == id);

                if (make is null)
                {
                    throw new Exception("manufacturer not found");
                }

                response.Data = _mapper.Map<GetMakeDto>(make);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<GetMakeDto>> UpdateMake(UpdateMakeDto updatedMake)
        {
            var response = new ServiceResponse<GetMakeDto>();
            try
            {
                var make = await _context.Makes
                        .FirstOrDefaultAsync(m => m.Id == updatedMake.Id);

                if (make is null)
                {
                    throw new Exception("manufacturer not found");
                }
                
                _mapper.Map<Make>(updatedMake);
                _mapper.Map(updatedMake, make);
                await _context.SaveChangesAsync();
               
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<List<GetModelDto>>> GetAllModel(SearchModel search)
        {
            var response = new ServiceResponse<List<GetModelDto>>();
            var dbModels = _context.Models.Where(m => m.Name.Contains(search.Name));
            dbModels = search.MakeId == 0 ? dbModels : dbModels.Where(m => m.MakeId == search.MakeId);
            dbModels = search.Order == "asc" ? dbModels.OrderBy(m => m.Name) : dbModels.OrderByDescending(m => m.Name);
            dbModels = dbModels.Include(m => m.Make);
            response.Data = await dbModels.Select(m => _mapper.Map<GetModelDto>(m)).ToListAsync();
            return response;
        }

        public async Task<ServiceResponse<List<GetModelDto>>> AddModel(AddModelDto newModel)
        {
            var response = new ServiceResponse<List<GetModelDto>>();
            try
            {

                var check = await _context.Models.FirstOrDefaultAsync(m => m.Name.ToLower().Equals(newModel.Name.ToLower()) && m.MakeId.Equals(newModel.MakeId));
                if (check is not null)
                {
                    throw new Exception($"Model '{newModel.Name}' alredy exists");
                }
                var model = _mapper.Map<Model>(newModel);
                _context.Models.Add(model);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<ServiceResponse<List<GetModelDto>>> DeleteModel(int id)
        {
            var response = new ServiceResponse<List<GetModelDto>> ();
            try
            {
                var model = await _context.Models.FirstOrDefaultAsync(c => c.Id == id);

                if (model is null)
                {
                    throw new Exception("Model not found");
                }
                _context.Models.Remove(model);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<GetModelDto>> UpdateModel(UpdateModelDto updatedModel)
        {
            var response = new ServiceResponse<GetModelDto>();
            try
            {
                var model = await _context.Models
                        .FirstOrDefaultAsync(m => m.Id == updatedModel.Id);

                if (model is null)
                {
                    throw new Exception("Model not found");
                }

                _mapper.Map<Model>(updatedModel);
                _mapper.Map(updatedModel, model);
                await _context.SaveChangesAsync();
                
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<GetModelDto>> GetModelSingle(int id)
        {
            var response = new ServiceResponse<GetModelDto>();
            try
            {
                var model = await _context.Models
                .FirstOrDefaultAsync(m => m.Id == id);

                if (model is null)
                {
                    throw new Exception("Model not found");
                }

                response.Data = _mapper.Map<GetModelDto>(model);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}

