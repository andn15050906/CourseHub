using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace CourseHub.UI.Areas.Admin.Pages.CreateAdmin
{
    public class IndexModel : PageModel
    {
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage = "Username is required.")]
            [StringLength(50, MinimumLength = 5, ErrorMessage = "Username must be between 5 and 50 characters.")]
            public string Username { get; set; }

            [Required(ErrorMessage = "Full Name is required.")]
            public string Fullname { get; set; }

            [Required(ErrorMessage = "Password is required.")]
            [DataType(DataType.Password)]
            [StringLength(50, MinimumLength = 8, ErrorMessage = "Password must be at least 8 characters.")]
            public string Password { get; set; }

            [Required(ErrorMessage = "Please re-enter your password.")]
            [DataType(DataType.Password)]
            [Compare("Password", ErrorMessage = "Passwords do not match.")]
            public string Repassword { get; set; }
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Handle the form submission, validate data, and save to the database.
            // You can add your business logic here.

            // Redirect to a success page or perform further actions.
            return RedirectToPage("SuccessPage");
        }
    }
}
