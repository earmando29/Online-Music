using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyWebApp.Pages;

public class TabModel : PageModel
{
    private readonly ILogger<TabModel> _logger;

    public TabModel(ILogger<TabModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
    }
}

