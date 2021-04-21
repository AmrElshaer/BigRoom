using BigRoom.Service.DTO;
using BigRoom.Service.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BigRoom.Controllers
{
    [Authorize]
    public class QuizesController : BaseController
    {
        private readonly IHostingEnvironment _IhostEnv;
        private readonly IDegreeService degreeService;
        private readonly IQuzieService quzieService;
        private readonly IUserProfileService userProfileService;

        public QuizesController(IHostingEnvironment hostingEnvironment,IDegreeService degreeService,IQuzieService quzieService, IUserManager userManager, IUserProfileService userProfileService) : base(userManager)
        {
            _IhostEnv = hostingEnvironment;
            this.degreeService = degreeService;
            this.quzieService = quzieService;
            this.userProfileService = userProfileService;
        }

        // GET: Quizes

        public async Task<IActionResult> Index(int groupId)
        {
            var result = await quzieService.GetQuziesByGroupAsync(groupId);
            return View(result);
        }

        // GET: Quizes/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var userId = (await userProfileService.GetUserProfileAsync(await GetCurrentUserId())).Id;
            var isDoExam =await degreeService.IsDoExamAsync(id,userId);
            if (isDoExam)
            {
                return RedirectToAction("Index",controllerName:"Degree");
            }
            var quizeModel = await quzieService.GetQuizeDetailsAsync(id);
            return View(quizeModel);
        }
        // GET: Quizes/Create
        public IActionResult Create(string groupid)
        {
            ViewData["groupid"] = groupid;
            return View();
        }
        // POST: Quizes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(QuizeDto quize)
        {
            if (ModelState.IsValid)
            {
                quize.UserProfileId = (await userProfileService.GetUserProfileAsync(await GetCurrentUserId())).Id;
                await quzieService.CreateQuizeAsync(quize);
                return RedirectToAction(nameof(Index), new { Groupid = quize.GroupId });
            }
            return View(quize);
        }

        // GET: Quizes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var quize = await quzieService.GetQuizeByIdAsync(id.Value);
            if (quize == null) return NotFound();
            return View(quize);
        }

        // POST: Quizes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(QuizeDto quize)
        {
            if (ModelState.IsValid)
            {
                await quzieService.UpdateQuizeAsync(quize);
                return RedirectToAction(nameof(Index), new { Groupid = quize.GroupId });
            }
            return View(quize);
        }

        //// GET: Quizes/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var quize = await quzieService.GetQuizeByIdAsync(id);
            if (quize == null) return NotFound();
            await quzieService.DeleteAsync(id);
            return RedirectToAction(nameof(Index), new { Groupid = quize.GroupId });
        }
    }
}