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
        private readonly IToastNotification toastNotification;
        private readonly IUniteOfWork uniteOfWork;

        public GroupsController(IGroupService groupService, IToastNotification toastNotification
            ,IUniteOfWork uniteOfWork)
        {
            this.groupService = groupService;
            this.toastNotification = toastNotification;
            this.uniteOfWork = uniteOfWork;
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
            if (!ModelState.IsValid) return View(group);
            group.AdminId = await GetUserProfileId();
            await groupService.AddAsync(group);
            await uniteOfWork.SaveChangesAsync();
            this.toastNotification.AddSuccessToastMessage($"Group {group.Name} is created success",
                new ToastrOptions() { ToastClass = "btn-success" });
            return RedirectToAction("Index", controllerName: "Exam");
           
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
                await groupService.UpdateAsync(group);
                await uniteOfWork.SaveChangesAsync();
                this.toastNotification.AddSuccessToastMessage($"Group {group.Name} is edit success", new ToastrOptions() { ToastClass = "btn-success" });
                return RedirectToAction("Index", controllerName: "Exam");
            }
            return View(group);
        }

        // GET: Groups/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            await groupService.DeleteAsync(id.Value);
            await uniteOfWork.SaveChangesAsync();
            this.toastNotification.AddSuccessToastMessage($"Group deleted success", new ToastrOptions() { ToastClass = "btn-success" });
            return RedirectToAction("Index", controllerName: "Exam");
        }
    }
}