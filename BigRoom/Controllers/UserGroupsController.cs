using BigRoom.Service.DTO;
using BigRoom.Service.IService;
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
        private readonly IUserGroupService userGroupService;
        private readonly IToastNotification toastNotification;

        public UserGroupsController(IUserGroupService userGroupService, IToastNotification toastNotification)
        {
            this.userGroupService = userGroupService;
            this.toastNotification = toastNotification;
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.UserProfielId = await GetUserProfileId();
            return View();
        }

        // POST: UserGroups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserGroupsDto userGroups)
        {
            if (ModelState.IsValid)
            {
               var groupId=  await userGroupService.AddAsync(userGroups);
                this.toastNotification.AddSuccessToastMessage($"Join to group is success", new ToastrOptions() { ToastClass = "btn-success" });
                return RedirectToAction("GroupYouAdmin", "Groups", new { id = groupId });
            }
            return View(userGroups);
        }
        [HttpPost]
        public async Task LeaveFromGroup(int id)
        {
            try
            {
                await userGroupService.DeleteAsync(id);
            }
            catch (System.Exception)
            {

                throw;
            }
           
        }
    }
}