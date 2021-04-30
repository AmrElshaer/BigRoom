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
           
            return View( degreeService.GetDegrees(await GetUserProfileId()));
        }
        public  IActionResult GetStudentsDegrees(int quizeId)
        {
            var degrees=  degreeService.GetQuizeDegrees(quizeId);
            return View(degrees);
        }
    }
}