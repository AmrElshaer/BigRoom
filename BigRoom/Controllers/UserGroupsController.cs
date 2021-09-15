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
    public class UserGroupsController : BaseController
    {
        private readonly IUniteOfWork uniteOfWork;
        private readonly IUserGroupService userGroupService;
        private readonly IToastNotification toastNotification;

        public UserGroupsController(IUniteOfWork uniteOfWork,IUserGroupService userGroupService, IToastNotification toastNotification)
        {
            this.uniteOfWork = uniteOfWork;
            this.userGroupService = userGroupService;
            this.toastNotification = toastNotification;
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
                this.toastNotification.AddSuccessToastMessage($"Join to group is success", new ToastrOptions() { ToastClass = "btn-success" });
                return RedirectToAction("GroupYouAdmin", "Groups", new { id = userGroups.GroupId });
            }
            return View(userGroups);
        }
        [HttpPost]
        public async Task LeaveFromGroup(int id)
        {
            try
            {
                await userGroupService.DeleteAsync(id);
                await uniteOfWork.SaveChangesAsync();
            }
            catch (System.Exception)
            {

                throw;
            }
           
        }
    }
}