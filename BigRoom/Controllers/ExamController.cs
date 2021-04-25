using BigRoom.Service.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BigRoom.Controllers
{
    [Authorize]
    public class ExamController : BaseController
    {
        public async Task<ActionResult> Index()
        {
            var user = await UserProfileService.GetUserProfileAsync(await GetUserProfileId());
            return View(user);
        }
    }
}