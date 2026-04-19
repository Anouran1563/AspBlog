using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Models.ViewModels;

namespace WebApi.Pages;

public class ViewPost : PageModel
{
    private readonly AppDbContext _context;

    public ViewPost(AppDbContext context)
    {
        _context = context;
    }
    public List<PostView> AllPosts { get; set; } = new List<PostView>();
    public async Task OnGetAsync()
    {
        var postsFromDb = await _context.BlogPost
            .Include(p => p.BlogpostTags)
            .ThenInclude(bt => bt.Tag)
            .ToListAsync();

        AllPosts = postsFromDb.Select(p => new PostView
        {
            Title = p.Title,
            Author = p.Author,
            Content = p.Content,
            Tags = p.BlogpostTags.Any()
                ? string.Join(" ",
                    p.BlogpostTags
                        .Where(bt => bt.Tag != null)
                        .Select(bt => bt.Tag!.Name))
                : string.Empty
        }).ToList(); 
    }
}