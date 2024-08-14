namespace UI.Models.Categories
{
    public class CategoryCreateRequest
    {
        public string Name { get; set; }
        public List<IFormFile> ImageFiles { get; set; }
    }

    
}
