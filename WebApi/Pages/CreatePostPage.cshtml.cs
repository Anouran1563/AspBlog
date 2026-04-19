using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using System.Linq;
using WebApi.Data;
using WebApi.Models.Domain;

namespace WebApi.Pages
{
    public class CreatePostPageModel(AppDbContext context) : PageModel
    {
        [BindProperty]
        [Required]
        public string? Author { get; set; }
        [BindProperty]
        [Required]
        public string? Title { get; set; }
        [BindProperty]
        [Required]
        public string Content { get; set; }
        public string? UrlHandle { get; set; }
        public DateTime DoC { get; set; } = DateTime.Today;
        [BindProperty]
        [Required]
        public bool Visible { get; set; }
        [Required]
        public SelectList? Tag { get; set; }
        [BindProperty]
        [Required]
        public Guid SelectedTag { get; set; }

        public void OnGet()
        {
            List<Tag> tags = context.Tag.ToList();
            Tag = new SelectList(tags, "Id", "DisplayName");
            
        }

        public static string Slug(string inputString, Regex UrlSlugRegex)
        {
            return Regex
                .Replace(inputString.ToLower().Trim(), @"[^a-z0-9\s-]", "")
                .Replace(" ", "-")
                .Replace("--", "-")
                .Replace("�", "ae")
                .Replace("�", "ue")
                .Replace("�", "oe");
        }
    
        public IActionResult OnPost()
        {
            // Validate input
            if (!ModelState.IsValid
                        || string.IsNullOrWhiteSpace(Author)
                        || string.IsNullOrWhiteSpace(Title)
                        || string.IsNullOrWhiteSpace(Content)
                        || SelectedTag == Guid.Empty)
            {
                return Page();
            }

            var selectedTag = context.Tag.Find(SelectedTag);
            if (selectedTag == null)
            {
                ModelState.AddModelError("", "Selected tag does not exist.");
                return Page();
            }

            // Create BlogPost object
            var post = new BlogPost
            {
                Id = Guid.NewGuid(),
                Author = Author,
                Title = Title,
                Content = Content,
                DoC = DoC,
                Visible = Visible
            };

            context.BlogPost.Add(post);

            // Link tag via join table
            var blogpostTag = new BlogpostTag
            {
                BlogpostId = post.Id,
                TagId = selectedTag.Id
            };
            context.BlogPostTags.Add(blogpostTag);

            context.SaveChanges();

            return Page();
        }
    }
}
