using BigRoom.Service.DTO;
using BigRoom.Service.IService;
using BigRoom.Service.UOW;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BigRoom.Controllers
{
    [Authorize]
    public class UserGroupsController : BaseController
    {
        private readonly IUniteOfWork uniteOfWork;
        private readonly IUserGroupService userGroupService;

        public UserGroupsController(IUniteOfWork uniteOfWork, IUserGroupService userGroupService)
        {
            this.uniteOfWork = uniteOfWork;
            this.userGroupService = userGroupService;
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.UserProfielId = await GetUserProfileId();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserGroupsDto userGroups)
        {
            if (ModelState.IsValid)
            {
                await userGroupService.AddAsync(userGroups);
                await uniteOfWork.SaveChangesAsync();
                ShowSuccess("Join to group is success");
                return RedirectToAction("GroupYouAdmin", "Groups", new { id = userGroups.GroupId });
            }
            return View(userGroups);
        }

        [HttpPost]
        public async Task<IActionResult> LeaveFromGroup(int id)
        {
            await userGroupService.DeleteAsync(id);
            await uniteOfWork.SaveChangesAsync();
            ShowSuccess("Leave Group Sucess");
            return RedirectToAction("Index","Exam");
        }
    }
}