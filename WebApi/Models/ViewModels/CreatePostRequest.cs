namespace WebApi.Models.ViewModels
{
    public class CreatePostRequest
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string UrlHandle { get; set; }
        public DateTime DoC { get; set; }
        public string Author { get; set; }
        public bool Visible { get; set; }
    }
}
