using System;
using Service.Dtos.Model;

namespace Service.Dtos.Make
{
	public class GetMakeDto
	{
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Abrv { get; set; } = string.Empty;

    }
}

