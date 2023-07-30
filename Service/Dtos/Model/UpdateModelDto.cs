using System;
using Service.Dtos.Make;

namespace Service.Dtos.Model
{
	public class UpdateModelDto
	{
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Abrv { get; set; } = string.Empty;
        public int MakeId { get; set; }
    }
}

