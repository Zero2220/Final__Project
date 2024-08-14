namespace UI.Models.Categories
{
    public class CategoryEditRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<IFormFile>? ImageFiles { get; set; }
    }
}
