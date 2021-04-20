using BigRoom.Service.DTO;
using BigRoom.Service.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BigRoom.Controllers
{
    [Authorize]
    public class UserGroupsController : BaseController
    {
        private readonly IUserGroupService userGroupService;
        private readonly IUserProfileService userProfileService;

        public UserGroupsController(IUserGroupService userGroupService, IUserProfileService userProfileService, IUserManager manager) : base(manager)
        {
            this.userGroupService = userGroupService;
            this.userProfileService = userProfileService;
        }

        // GET: UserGroups
        //public async Task<IActionResult> Index(string CodeJoin)
        //{
        //    return View(await _context.UserGroups.Where(a => a.CodeJoin == CodeJoin).ToListAsync());
        //}
        // GET: UserGroups/Create
        public async Task<IActionResult> Create()
        {
            ViewBag.userProfileId = (await userProfileService.GetUserProfileAsync(await GetCurrentUserId()))?.Id;
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
                await userGroupService.CreateUserGroup(userGroups);
                return RedirectToAction("GoToGroup", "Groups", new { codeJoin = userGroups.CodeJoin });
            }
            return View(userGroups);
        }
    }
}