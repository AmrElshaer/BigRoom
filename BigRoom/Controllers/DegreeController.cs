using BigRoom.Service.File;
using BigRoom.Service.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BigRoom.Controllers
{
    [Authorize]
    public class DegreeController : BaseController
    {
        private readonly IFileService fileService;
        private readonly IDegreeService degreeService;

        public DegreeController(IFileService fileService
            , IDegreeService degreeService)
        {
            this.fileService = fileService;
            this.degreeService = degreeService;
        }

        public async Task<IActionResult> CalculateDegree(IList<string> answers, int quizeId)
        {
            await degreeService.CalCulateDegreeAsync(answers, quizeId, await GetUserProfileId());
            ShowSuccess("Quize Send Success");
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Index()
        {
            return View(degreeService.GetDegrees(await GetUserProfileId()));
        }

        public IActionResult GetStudentsDegrees(int quizeId)
        {
            var degrees = degreeService.GetQuizeDegrees(quizeId);
            return View(degrees);
        }
    }
}