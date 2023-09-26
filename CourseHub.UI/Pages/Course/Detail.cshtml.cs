using CourseHub.Core.Entities.CourseDomain;
using CourseHub.Core.Interfaces.Repositories.Shared;
using CourseHub.Core.Models.Course.CourseModels;
using CourseHub.Core.Models.Course.CourseReviewModels;
using CourseHub.Core.Models.Course.InstructorModels;
using CourseHub.Core.Models.User.UserModels;
using CourseHub.Core.RequestDtos.Course.CourseDtos;
using CourseHub.UI.Helpers;
using CourseHub.UI.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CourseHub.UI.Pages.Course;

public class DetailModel : PageModel
{
    private readonly ICourseApiService _courseApiService;

    public CourseModel? Course { get; set; }

    public UserModel? InstructorUser { get; set; } = new UserModel { };
    public InstructorModel? Instructor { get; set; } = new InstructorModel { };

    public List<CourseOverviewModel> MoreCourses { get; set; } = new();

    public DetailModel(ICourseApiService courseApiService)
    {
        _courseApiService = courseApiService;
    }

    public async Task<IActionResult> OnGet([FromQuery] Guid id)
    {
        if (id == default)
            return Redirect(Global.PAGE_404);

        Course = await _courseApiService.GetAsync(id);
        TempData[Global.DATA_USE_BACKGROUND] = true;

        //
        Course.Reviews = new();
        return Page();
    }
}