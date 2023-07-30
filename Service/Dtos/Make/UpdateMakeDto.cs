using System;
namespace Service.Dtos.Make
{
	public class UpdateMakeDto
	{
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Abrv { get; set; } = string.Empty;
    }
}

