using BigRoom.Service.Common.Models;
using BigRoom.Service.DTO;
using BigRoom.Service.File;
using BigRoom.Service.IService;
using BigRoom.Service.UOW;
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
        private readonly IUniteOfWork uniteOfWork;
        private readonly IQuzieService quzieService;

        public QuizesController(IDegreeService degreeService
            ,IUniteOfWork uniteOfWork,IQuzieService quzieService)
        {
            this.degreeService = degreeService;
            this.uniteOfWork = uniteOfWork;
            this.quzieService = quzieService;
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
            if (!ModelState.IsValid) return View(quize);
            quize.UserProfileId = await GetUserProfileId();
            await quzieService.AddQuzieAsync(quize);
            await uniteOfWork.SaveChangesAsync();
            ShowSuccess($"Quize {quize.Description} Created Success");
            return RedirectToAction(nameof(Index), new { Groupid = quize.GroupId });

           
        }

        public async Task<IActionResult> Delete(int id)
        {
            var quize = await quzieService.GetByIdAsync(id);
            if (quize == null) return NotFound();
            await quzieService.RemoveQuzie(id);
            await uniteOfWork.SaveChangesAsync();
            ShowSuccess($"Quize {quize.Description} deleted Success");
            return RedirectToAction(nameof(Index), new { Groupid = quize.GroupId });

           
        }

        public async Task<IActionResult> Details(int id)
        {
            if (await degreeService.IsDoExam(id, await GetUserProfileId()))
            {
                ShowWarning("You Do this exam before");
                return RedirectToAction("Index", controllerName: "Degree");
            }
            return View(await quzieService.GenerateQuzie(id));
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
            if (!ModelState.IsValid) return View(quize);
            await quzieService.UpdateQuzieAsync(quize);
            await uniteOfWork.SaveChangesAsync();
            ShowSuccess($"Quize {quize.Description} edit Success");
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