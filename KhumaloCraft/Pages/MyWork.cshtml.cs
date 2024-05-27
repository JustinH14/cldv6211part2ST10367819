using KhumaloCraft.wwwroot.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

public class PlaceOrderModel : PageModel
{
    private readonly ApplicationDbContext _context;

    [BindProperty]
    public List<int> SelectedCraftworkIds { get; set; }

    public PlaceOrderModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        // Retrieve the current user's order or create a new one
        var order = _context.Orders.FirstOrDefault(o => o.UserID == o.UserID);
        if (order == null)
        {
            order = new Order { UserID = order.UserID };
            _context.Orders.Add(order);
        }

        foreach (var id in SelectedCraftworkIds)
        {
            var product = _context.Products.Find(id);
          
            if (product != null)
            {
                 order.Products.Add(product);
            }
        }

        _context.SaveChanges();

        return RedirectToPage("./ViewOrders");
    }
}