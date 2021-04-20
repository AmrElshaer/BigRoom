using BigRoom.Service.DTO;
using BigRoom.Service.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BigRoom.Controllers
{
    [Authorize]
    public class GroupsController : BaseController
    {
        private readonly IGroupService groupService;

        public GroupsController(IUserManager userManager, IGroupService groupService) : base(userManager)
        {
            this.groupService = groupService;
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
            var group = await groupService.GetByIdAsync(id.Value);
            if (group == null) return NotFound();
            return View(group);
        }

        // GET: Groups/Create
        public IActionResult Create()
        {
            ViewData["Guid"] = Guid.NewGuid().ToString();
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
                await groupService.CreateGroup(group, (await GetCurrentUserId()));
                return RedirectToAction("Index", controllerName: (await GetRoleAsync())); ;
            }
            ViewData["Guid"] = Guid.NewGuid().ToString();
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
                return RedirectToAction("Index", controllerName: (await GetRoleAsync()));
            }
            return View(group);
        }

        // GET: Groups/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            await groupService.DeleteGroup(id.Value);
            return RedirectToAction("Index", controllerName: (await GetRoleAsync()));
        }
    }
}