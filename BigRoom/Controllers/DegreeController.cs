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

        public DegreeController(IToastNotification toastNotification, IDegreeService degreeService)
        {
            this.toastNotification = toastNotification;
            this.degreeService = degreeService;
        }

        public async Task<IActionResult> CalculateDegree(IList<string> answers, int quizeId)
        {
            await degreeService.CalCulateDegreeAsync(answers, quizeId, await GetUserProfileId());
            this.toastNotification.AddSuccessToastMessage($"Quize Send Success", new ToastrOptions() { ToastClass = "btn-success" });
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Index()
        {
           
            return View(await degreeService.GetDegreesAsync(await GetUserProfileId()));
        }
        public async Task<IActionResult> GetStudentsDegrees(int quizeId)
        {
            var degrees= await degreeService.GetQuizeDegreesAsync(quizeId);
            return View(degrees);
        }
    }
}