using KhumaloCraft.wwwroot.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

public class AddProductModel : PageModel
{
    private readonly ApplicationDbContext _context;

    [BindProperty]
    public Product Product { get; set; }

    public AddProductModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Products.Add(Product);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index"); // Redirect to the index page after successful addition
    }
}
