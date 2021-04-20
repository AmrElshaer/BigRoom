using BigRoom.Repository.Contexts;
using BigRoom.Service.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Classroom.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly IUserManager _userManager;

        public RegisterModel(IUserManager userManager)
        {
            _userManager = userManager;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public void OnGet(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = Input.Email, Email = Input.Email,Image=Input.Image };

                var userAdd = await _userManager.CreateAsync(user, Input.Password, Input.RoleId);
                if (userAdd.result.Succeeded)
                {
                    switch (userAdd.role)
                    {
                        case "Student":
                            return RedirectToAction(controllerName: "Student", actionName: "Index");

                        case "Teacher":
                            return RedirectToAction(controllerName: "Teacher", actionName: "Index");
                    }
                    return LocalRedirect(returnUrl);
                }
                userAdd.result.Errors.ToList().ForEach(error => ModelState.AddModelError(string.Empty, error.Description));
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }

        public class InputModel
        {
            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            public string Image { get; set; }

            [Required]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }
            [Required]
            [Display(Name = "RoleName")]
            public string RoleId { get; set; }
        }
    }
}