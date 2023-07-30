using System;
namespace Service.Dtos.Model
{
	public class SearchModel
	{
        public string Name { get; set; } = string.Empty;
        public string Order { get; set; } = "asc";
        public int MakeId { get; set; }
    }
}

