using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using WebApi.Data;
using WebBlog.Models.Domain;

namespace WebApi.Pages
{
    public class CreatePostPageModel(DBContext context) : PageModel
    {
        [BindProperty]
        [Required]
        public string Author { get; set; }
        [BindProperty]
        [Required]
        public string Title { get; set; }
        [BindProperty]
        [Required]
        public string Content { get; set; }
        public string UrlHandle { get; set; }
        public DateTime DoC { get; set; } = DateTime.Today;
        [BindProperty]
        [Required]
        public bool Visible { get; set; }
        [Required]
        public SelectList Tag { get; set; }
        [BindProperty]
        [Required]
        public Guid SelectedTag { get; set; }
        public void OnGet()
        {
            List<Tag> tags = context.Tag.ToList();
            Tag = new SelectList(tags, "Id", "DisplayName");
            
        }

    
        public IActionResult OnPost()
        {
            //Validate Input
            if ((!ModelState.IsValid || string.IsNullOrWhiteSpace(Author) || string.IsNullOrWhiteSpace(Title) || string.IsNullOrWhiteSpace(Content)))
            {
                return Page();
            }
            var selectedTag = context.Tag.Find(SelectedTag);

            //create BlogPost object
            BlogPost post = new BlogPost()
            {
                Id = Guid.NewGuid(),
                Author = Author,
                Title = Title,
                Content = Content,
                Tags = new List<Tag>() { selectedTag} ,
                DoC = DoC,
                Visible = Visible
            };

            context.BlogPost.Add(post); //add to database
            context.SaveChanges(); //save
            return Page();
        }

    }
}
