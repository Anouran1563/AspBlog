using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using WebApi.Data;
using WebApi.Models.Domain;

namespace WebApi.Pages
{
    public class AddTagPageModel(AppDbContext context) : PageModel
    {
        [BindProperty]
        [Required]
        public string? DisplayName { get; set; }
        [BindProperty]
        [Required]
        public string? Name { get; set; }
        
        public void OnGet()
        {
        }
        public IActionResult OnPost() 
        {
            if ((!ModelState.IsValid || string.IsNullOrWhiteSpace(DisplayName) || string.IsNullOrWhiteSpace(Name)))
            {
                return Page();
            }
            Tag tag = new Tag()
            {
                DisplayName = DisplayName,
                Name = Name
            };

            context.Tag.Add(tag);
            context.SaveChanges();
            return Page();
        }
    }
}
