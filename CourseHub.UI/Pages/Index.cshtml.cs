﻿using CourseHub.Core.Services.Domain.UserServices.TempModels;
using CourseHub.UI.Helpers.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CourseHub.UI.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
    }
}