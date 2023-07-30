using System;
using AutoMapper;
using Service.Dtos.Make;
using Service.Dtos.Model;

namespace Service
{
	public class AutoMapperProfiles : Profile
    {
		public AutoMapperProfiles()
		{
            CreateMap<Make, GetMakeDto>();
            CreateMap<AddMakeDto, Make>();
            CreateMap<UpdateMakeDto, Make>();
            CreateMap<Model, GetModelDto>();
            CreateMap<AddModelDto, Model>();
            CreateMap<UpdateModelDto, Model>();
        }

	}
}

