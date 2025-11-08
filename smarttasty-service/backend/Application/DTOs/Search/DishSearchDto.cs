namespace backend.Application.DTOs.Search
{
    public class DishSearchDto
    {
        public string Name { get; set; } = string.Empty;
        public string NameNoAccent { get; set; } = string.Empty;
        public int Popularity { get; set; }
        public int Frequency { get; set; }
    }
}
