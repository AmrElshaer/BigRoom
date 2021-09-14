using BigRoom.Helper;
using BigRoom.Service.Common.Behavoir;
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
        private readonly IQuzieService quzieService;
        private readonly IUserGroupService userGroupService;

        public GroupPermissionController(IGroupPermissionService groupPermissionService, IQuzieService quzieService,IUserGroupService userGroupService)
        {
            this.groupPermissionService = groupPermissionService;
            this.quzieService = quzieService;
            this.userGroupService = userGroupService;
        }
        public  IActionResult Index(int groupId)
        {
            if (groupId==0)
            {
                return NotFound();
            }
            ViewBag.GroupId = groupId;
            return View( groupPermissionService.GetGroupPermissions(groupId));
        }
        [NoDirectAccess]
        public async Task<IActionResult> CreateEdit(int groupId,int id = 0)
        {
            GroupPermissionDto groupPermissionDto;
            if (id == 0)
            {
                groupPermissionDto=new GroupPermissionDto();
                groupPermissionDto.GroupId = groupId;
            }
            else
            {
                var groupPermission = await groupPermissionService.GetByIdAsync(id);
                if (groupPermission == null) return NotFound();
                groupPermissionDto = groupPermission;
            }
            groupPermissionDto.Quizes = quzieService.GetQuziesByGroup(groupId);
            groupPermissionDto.UserProfiles =  userGroupService.GetUserInGroup(groupId).Select(a=> new
            { Id = a.UserProfileId, Name = a.UserProfile.ApplicationUser.Email.GetNameFromEmail() });
            return View(groupPermissionDto);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateEdit([Bind("Id,QuizeId,GroupId,Edit,Create,Delete,UserProfileId")] GroupPermissionDto groupPermission)
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
                     groupPermissionService.GetGroupPermissions(groupPermission.GroupId)
                    )
                });
            }
            return Json(new { isValid = false, html = RenderRazorService.RenderRazorViewToString(this, "_CreateEdit", groupPermission) });


        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id,int groupId) {
            try
            {
                await groupPermissionService.DeleteAsync(id);
            }
            catch (Exception)
            {

                throw;
            }
            return Json(new
            {
                isValid = true,
                html = RenderRazorService.RenderRazorViewToString(this, "_ViewAll",
                    groupPermissionService.GetGroupPermissions(groupId)
                   )
            });
        }
    }
}
