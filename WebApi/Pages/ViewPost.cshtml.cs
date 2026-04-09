using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Models.ViewModels;
using static WebApi.Data.AppDbContext;

namespace WebApi.Pages;

public class ViewPost : PageModel
{
    private readonly DbContext _context;

    public ViewPost(AppDbContext context)
    {
        _context = context;
    }
    public List<PostView> AllPosts { get; set; } = new List<PostView>();
    public void OnGet()
    {
        // Hard-coded dummy data to satisfy the UI
        AllPosts = new List<PostView>
        {
            new PostView 
            { 
                Title = "Dummy1", 
                Author = "System", 
                Content = "This is temporary content for the git push.",
                Tags = "Testing Development Dummy" 
            },
            new PostView 
            { 
                Title = "Dummy2", 
                Author = "Admin", 
                Content = "Everything is working if you can see this.",
                Tags = "CSharp Rider Git" 
            }
        };
    }
}