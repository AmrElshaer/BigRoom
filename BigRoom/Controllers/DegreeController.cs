using BigRoom.Service.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using NToastNotify.Libraries;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BigRoom.Controllers
{
    [Authorize]
    public class DegreeController : BaseController
    {
        private readonly IToastNotification toastNotification;
        private readonly IDegreeService degreeService;
        private readonly IUserProfileService userProfileService;

        public DegreeController(IToastNotification toastNotification, IDegreeService degreeService, IUserProfileService userProfileService)
        {
            this.toastNotification = toastNotification;
            this.degreeService = degreeService;
            this.userProfileService = userProfileService;
        }

        public async Task<IActionResult> CalculateDegree(IList<string> answers, int quizeId)
        {
            var userId = (await userProfileService.GetUserProfileAsync(await GetCurrentUserId())).Id;
            await degreeService.CalCulateDegreeAsync(answers, quizeId, userId);
            this.toastNotification.AddSuccessToastMessage($"Quize Send Success", new ToastrOptions() { ToastClass = "btn-success" });
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Index()
        {
            var userId = (await userProfileService.GetUserProfileAsync(await GetCurrentUserId())).Id;
            return View(await degreeService.GetDegreesAsync(userId));
        }
        public async Task<IActionResult> GetStudentsDegrees(int quizeId)
        {
            var degrees= await degreeService.GetQuizeDegreesAsync(quizeId);
            return View(degrees);
        }
    }
}