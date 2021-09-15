using BigRoom.Service.DTO;
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
    public class GroupsController : BaseController
    {
        private readonly IGroupService groupService;
        private readonly IUniteOfWork uniteOfWork;

        public GroupsController(IGroupService groupService,IUniteOfWork uniteOfWork)
        {
            this.groupService = groupService;
            this.uniteOfWork = uniteOfWork;
        }

       
        public async Task<IActionResult> GroupYouAdmin(int? id)
        {
            if (id == null) return NotFound();
            var group = await groupService.GroupDetailsByIdAsync(id.Value);
            if (group == null) return NotFound();
            ViewData["UserId"] = await GetUserProfileId();
            return View(group);
        }

       
        public IActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(GroupDto group)
        {
            if (!ModelState.IsValid) return View(group);
            group.AdminId = await GetUserProfileId();
            await groupService.AddAsync(group);
            await uniteOfWork.SaveChangesAsync();
            ShowSuccess($"Group {group.Name} is created success");
            return RedirectToAction("Index", controllerName: "Exam");
           
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var group = await groupService.GetByIdAsync(id.Value);
            if (group == null) return NotFound();
            return View(group);
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(GroupDto group)
        {
            if (ModelState.IsValid)
            {
                await groupService.UpdateAsync(group);
                await uniteOfWork.SaveChangesAsync();
                ShowSuccess($"Group {group.Name} is edit success");
                return RedirectToAction("Index", controllerName: "Exam");
            }
            return View(group);
        }

        
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            await groupService.DeleteAsync(id.Value);
            await uniteOfWork.SaveChangesAsync();
            ShowSuccess($"Group deleted success");
            return RedirectToAction("Index", controllerName: "Exam");
        }
    }
}