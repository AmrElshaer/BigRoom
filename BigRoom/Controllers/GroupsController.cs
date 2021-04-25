using BigRoom.Service.DTO;
using BigRoom.Service.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using NToastNotify.Libraries;
using System;
using System.Threading.Tasks;

namespace BigRoom.Controllers
{
    [Authorize]
    public class GroupsController : BaseController
    {
        private readonly IGroupService groupService;
        private readonly IToastNotification toastNotification;

        public GroupsController(IGroupService groupService,IToastNotification toastNotification)
        {
            this.groupService = groupService;
            this.toastNotification = toastNotification;
        }

        public async Task<IActionResult> GoToGroup(string codeJoin)
        {
            var group = await groupService.GetGroupByCodeAsync(codeJoin);
            return RedirectToAction(nameof(Details), new { id = group.Id });
        }

        //Group You Join
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var group = await groupService.GetByIdAsync(id.Value);
            if (group == null) return NotFound();
            return View(group);
        }

        // GET: Groups/GroupYouAdmin/5
        //Group You Join
        public async Task<IActionResult> GroupYouAdmin(int? id)
        {
            if (id == null) return NotFound();
            var group = await groupService.GroupDetailsByIdAsync(id.Value);
            if (group == null) return NotFound();
            ViewData["UserId"] = await GetUserProfileId();
            return View(group);
        }

        // GET: Groups/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Groups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(GroupDto group)
        {
            if (ModelState.IsValid)
            {
                group.AdminId = await GetUserProfileId();
                await groupService.CreateGroup(group);
                this.toastNotification.AddSuccessToastMessage($"Group {group.Name} is created success",new ToastrOptions() { ToastClass= "btn-success" });
                return RedirectToAction("Index", controllerName: "Exam"); 
            }
            return View(group);
        }

        // GET: Groups/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var group = await groupService.GetByIdAsync(id.Value);
            if (group == null) return NotFound();
            return View(group);
        }

        // POST: Groups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(GroupDto group)
        {
            if (ModelState.IsValid)
            {
                await groupService.UpdateGroup(group);
                this.toastNotification.AddSuccessToastMessage($"Group {group.Name} is edit success", new ToastrOptions() { ToastClass = "btn-success" });
                return RedirectToAction("Index", controllerName: "Exam");
            }
            return View(group);
        }

        // GET: Groups/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            await groupService.DeleteGroup(id.Value);
            this.toastNotification.AddSuccessToastMessage($"Group deleted success", new ToastrOptions() { ToastClass = "btn-success" });
            return RedirectToAction("Index", controllerName: "Exam");
        }
    }
}