using BigRoom.Helper;
using BigRoom.Service.DTO;
using BigRoom.Service.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static BigRoom.Helper.RenderRazorService;

namespace BigRoom.Controllers
{
    [Authorize]
    public class GroupPermissionController : Controller
    {
        private readonly IGroupPermissionService groupPermissionService;

        public GroupPermissionController(IGroupPermissionService groupPermissionService)
        {
            this.groupPermissionService = groupPermissionService;
        }
        public async Task<IActionResult> Index(int groupId)
        {
            return View(await groupPermissionService.GetGroupPermissions(groupId));
        }
        [NoDirectAccess]
        public async Task<IActionResult> CreateEdit(int id = 0)
        {
            if (id == 0)
                return View(new GroupPermissionDto());
            else
            {
                var groupPermission = await groupPermissionService.GetGroupPermissionById(id);
                if (groupPermission == null)
                {
                    return NotFound();
                }
                return View(groupPermission);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateEdit(GroupPermissionDto groupPermission)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    await groupPermissionService.CreateEditAsync(groupPermission);
                }
                catch (Exception)
                {
                    throw;
                }
                return Json(new
                {
                    isValid = true,
                    html = RenderRazorService.RenderRazorViewToString(this, "_ViewAll",
                    await groupPermissionService.GetGroupPermissions(groupPermission.Id)
                    )
                });
            }
            return Json(new { isValid = false, html = RenderRazorService.RenderRazorViewToString(this, "_CreateEdit", groupPermission) });


        }
    }
}
