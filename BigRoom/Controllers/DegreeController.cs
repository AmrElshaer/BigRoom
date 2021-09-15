using BigRoom.Service.File;
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
        private readonly IFileService fileService;
        private readonly IDegreeService degreeService;
        private readonly IQuzieService quzieService;
        public DegreeController(IToastNotification toastNotification, IFileService fileService
            ,IDegreeService degreeService, IQuzieService quzieService)
        {
            this.toastNotification = toastNotification;
            this.fileService = fileService;
            this.degreeService = degreeService;
            this.quzieService = quzieService;
        }

        public async Task<IActionResult> CalculateDegree(IList<string> answers, int quizeId)
        {
            var answerData = fileService.ReadAnswerfile((await quzieService.GetByIdAsync(quizeId)).Fileanswer);
            await degreeService.CalCulateDegreeAsync(answers, answerData, quizeId, await GetUserProfileId());
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