using BigRoom.Models;
using Classroom.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BigRoom.Controllers
{
    [Authorize]
    public class UserGroupsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserManager<User> _userManager { get; }

        public UserGroupsController(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: UserGroups
        public async Task<IActionResult> Index(string CodeJoin)
        {
            return View(await _context.UserGroups.Where(a => a.CodeJoin == CodeJoin).ToListAsync());
        }
        [AcceptVerbs("Get", "Post")]
        public async Task<JsonResult> GroupJoinUniqe(string CodeJoin)
        {
            var GroupName = await _context.Group.FirstOrDefaultAsync(a => a.CodeJion == CodeJoin);
            if (GroupName is null)
            {
                return Json(data: false);
            }
            return Json(data: true);
        }


        // GET: UserGroups/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserGroups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserName,CodeJoin")] UserGroups userGroups)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var group = await _context.Group.FirstOrDefaultAsync(a => a.CodeJion == userGroups.CodeJoin);
                    var user = await _userManager.FindByNameAsync(this.User.Identity.Name);
                    userGroups.user = user;
                    userGroups.group = group;
                    _context.Add(userGroups);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("GoToGroup", "Groups", new { Codejoin = userGroups.CodeJoin });
                }
                catch (Exception ex)
                {

                    throw new Exception(message: "You are Exiting in this group");
                }

            }
            return View(userGroups);
        }


    }
}
