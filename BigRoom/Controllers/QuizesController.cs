using BigRoom.Service.DTO;
using BigRoom.Service.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using NToastNotify.Libraries;
using System.Threading.Tasks;

namespace BigRoom.Controllers
{
    [Authorize]
    public class QuizesController : BaseController
    {
        private readonly IHostingEnvironment _IhostEnv;
        private readonly IToastNotification toastNotification;
        private readonly IDegreeService degreeService;
        private readonly IQuzieService quzieService;
        private readonly IUserProfileService userProfileService;

        public QuizesController(IHostingEnvironment hostingEnvironment,IToastNotification toastNotification,IDegreeService degreeService,IQuzieService quzieService, IUserProfileService userProfileService)
        {
            _IhostEnv = hostingEnvironment;
            this.toastNotification = toastNotification;
            this.degreeService = degreeService;
            this.quzieService = quzieService;
            this.userProfileService = userProfileService;
        }

        // GET: Quizes

        public async Task<IActionResult> Index(int groupId)
        {
            ViewData["UserId"] = await GetUserProfileId();
            var result = await quzieService.GetQuziesByGroupAsync(groupId);
            return View(result);
        }

        // GET: Quizes/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var isDoExam =await degreeService.IsDoExamAsync(id, await GetUserProfileId());
            if (isDoExam)
            {
                this.toastNotification.AddWarningToastMessage($"You Do this exam before", new ToastrOptions() { ToastClass = "btn-warning" });
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
                quize.UserProfileId =await GetUserProfileId();
                await quzieService.CreateQuizeAsync(quize);
                this.toastNotification.AddSuccessToastMessage($"Quize {quize.Description} Created Success", new ToastrOptions() { ToastClass = "btn-success" });
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
                this.toastNotification.AddSuccessToastMessage($"Quize {quize.Description} edit Success", new ToastrOptions() { ToastClass = "btn-success" });
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
            this.toastNotification.AddSuccessToastMessage($"Quize {quize.Description} deleted Success", new ToastrOptions() { ToastClass = "btn-success" });
            return RedirectToAction(nameof(Index), new { Groupid = quize.GroupId });
        }
    }
}