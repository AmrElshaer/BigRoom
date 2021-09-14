using BigRoom.Service.Common.Models;
using BigRoom.Service.DTO;
using BigRoom.Service.File;
using BigRoom.Service.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using NToastNotify.Libraries;
using System.Threading.Tasks;

namespace BigRoom.Controllers
{
    [Authorize]
    public class QuizesController : BaseController
    {
        private readonly IDegreeService degreeService;
        private readonly IFileService fileService;
        private readonly IQuzieService quzieService;
        private readonly IToastNotification toastNotification;

        public QuizesController(IToastNotification toastNotification, IDegreeService degreeService, IQuzieService quzieService, IFileService fileService)
        {
            this.toastNotification = toastNotification;
            this.degreeService = degreeService;
            this.quzieService = quzieService;
            this.fileService = fileService;
        }

        public IActionResult Create(string groupid)
        {
            ViewData["groupid"] = groupid;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(QuizeDto quize)
        {
            if (ModelState.IsValid)
            {
                quize.UserProfileId = await GetUserProfileId();
                quize.File = await fileService.AddFileAsync(quize.FileQuestion, "quize");
                quize.Fileanswer = await fileService.AddFileAsync(quize.FileAnswerForm, "answer");
                await quzieService.AddAsync(quize);
                this.toastNotification.AddSuccessToastMessage($"Quize {quize.Description} Created Success", new ToastrOptions() { ToastClass = "btn-success" });
                return RedirectToAction(nameof(Index), new { Groupid = quize.GroupId });
            }
            return View(quize);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var quize = await quzieService.GetByIdAsync(id);
            if (quize == null) return NotFound();
            fileService.RemoveFile(quize.Fileanswer, "answer");
            fileService.RemoveFile(quize.File, "quize");
            await quzieService.DeleteAsync(id);
            this.toastNotification.AddSuccessToastMessage($"Quize {quize.Description} deleted Success", new ToastrOptions() { ToastClass = "btn-success" });
            return RedirectToAction(nameof(Index), new { Groupid = quize.GroupId });
        }

        public async Task<IActionResult> Details(int id)
        {
            var userId = await GetUserProfileId();
            if ((await degreeService.GetFirstAsync(a => a.QuizeId == id && a.UserProfileId == userId)) != null)
            {
                this.toastNotification.AddWarningToastMessage($"You Do this exam before", new ToastrOptions() { ToastClass = "btn-warning" });
                return RedirectToAction("Index", controllerName: "Degree");
            }
            var quize = await quzieService.GetByIdAsync(id);
            var questions = await fileService.ReaderQuestionsAsync(quize.File);
            return View(new QuizeModel(questions, quize));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var quize = await quzieService.GetByIdAsync(id.Value);
            if (quize == null) return NotFound();
            return View(quize);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(QuizeDto quize)
        {
            if (!ModelState.IsValid)
                return View(quize);
            if (quize.FileQuestion != null)
            {
                fileService.RemoveFile(quize.File, "quize");
                quize.File = await fileService.AddFileAsync(quize.FileQuestion, "quize");
            }
            if (quize.FileAnswerForm != null)
            {
                fileService.RemoveFile(quize.Fileanswer, "answer");
                quize.Fileanswer = await fileService.AddFileAsync(quize.FileAnswerForm, "answer");
            }
            await quzieService.UpdateAsync(quize);
            this.toastNotification.AddSuccessToastMessage($"Quize {quize.Description} edit Success", new ToastrOptions() { ToastClass = "btn-success" });
            return RedirectToAction(nameof(Index), new { Groupid = quize.GroupId });
        }

        public async Task<IActionResult> Index(int groupId)
        {
            ViewData["UserId"] = await GetUserProfileId();
            var result = quzieService.GetQuziesByGroup(groupId);
            return View(result);
        }
    }
}