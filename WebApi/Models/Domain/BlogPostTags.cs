using WebBlog.Models.Domain;

public class BlogpostTag
{
    public Guid BlogpostId { get; set; }  // FK to BlogPost
    public BlogPost? Blogpost { get; set; } // Navigation property

    public Guid TagId { get; set; }       // FK to Tag
    public Tag? Tag { get; set; }          // Navigation property
}