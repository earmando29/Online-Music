using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CoogMusic.Pages;

public class ReportModel : PageModel
{
    private readonly ILogger<ReportModel> _logger;

    public ReportModel(ILogger<ReportModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
    }
}

