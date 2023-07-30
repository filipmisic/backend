using System;
namespace Service.Dtos.Model
{
	public class AddModelDto
	{
        public string Name { get; set; } = string.Empty;
        public string Abrv { get; set; } = string.Empty;
        public int MakeId { get; set; }
    }
}

