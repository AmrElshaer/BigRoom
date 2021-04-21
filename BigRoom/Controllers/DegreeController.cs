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
        private readonly IDegreeService degreeService;
        private readonly IUserProfileService userProfileService;

        public DegreeController(IUserManager userManager, IDegreeService degreeService, IUserProfileService userProfileService) : base(userManager)
        {
            this.degreeService = degreeService;
            this.userProfileService = userProfileService;
        }

        public async Task<IActionResult> CalculateDegree(IList<string> answers, int quizeId)
        {
            var userId = (await userProfileService.GetUserProfileAsync(await GetCurrentUserId())).Id;
            await degreeService.CalCulateDegreeAsync(answers, quizeId, userId);
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