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
    public class GroupsController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly ApplicationDbContext _context;

        public GroupsController(ApplicationDbContext context, UserManager<User> userManager)
        {
            _userManager = userManager;
            _context = context;
        }
        public async Task<IActionResult> GoToGroup(string Codejoin)
        {
            var Group = await this._context.Group.FirstOrDefaultAsync(a => a.CodeJion == Codejoin);
            if (Group != null)
            {
                return RedirectToAction(nameof(Details), new { id = Group.Id });
            }
            return RedirectToAction(nameof(Create), "UserGroups");
        }
        // GET: Groups
        public async Task<IActionResult> Index()
        {
            return View(await _context.Group.ToListAsync());
        }

        // GET: Groups/Details/5
        //Group You Join
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @group = await _context.Group
                .FirstOrDefaultAsync(m => m.Id == id);
            if (@group == null)
            {
                return NotFound();
            }

            return View(@group);
        }
        // GET: Groups/GroupYouAdmin/5
        //Group You Join
        public async Task<IActionResult> GroupYouAdmin(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @group = await _context.Group
                .FirstOrDefaultAsync(m => m.Id == id);
            if (@group == null)
            {
                return NotFound();
            }

            return View(@group);
        }
        // GET: Groups/Create
        public IActionResult Create()
        {

            ViewData["Guid"] = Guid.NewGuid().ToString();
            return View();
        }
        [AcceptVerbs("Get", "Post")]
        public async Task<JsonResult> GroupNameUNiqe(string Name)
        {
            var GroupName = await _context.Group.FirstOrDefaultAsync(a => a.Name == Name);
            if (GroupName is null)
            {
                return Json(data: true);
            }
            return Json(data: false);
        }
        // POST: Groups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CodeJion,Name")] Group @group)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(this.User.Identity.Name);
                @group.AdminId = user.Id;
                _context.Add(@group);
                await _context.SaveChangesAsync();

                var role = await _userManager.GetRolesAsync(user);

                return RedirectToAction(nameof(Index), controllerName: role.FirstOrDefault()); ;
            }
            return View(@group);
        }

        // GET: Groups/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @group = await _context.Group.FindAsync(id);
            if (@group == null)
            {
                return NotFound();
            }
            return View(@group);
        }

        // POST: Groups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CodeJion,Name")] Group @group)
        {
            var user = await _userManager.FindByNameAsync(this.User.Identity.Name);
            if (id != @group.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    @group.AdminId = user.Id;
                    _context.Update(@group);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GroupExists(@group.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                var role = await _userManager.GetRolesAsync(user);

                return RedirectToAction(nameof(Index), controllerName: role.FirstOrDefault()); ;
            }
            return View(@group);
        }

        // GET: Groups/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @group = await _context.Group
                .FirstOrDefaultAsync(m => m.Id == id);
            if (@group == null)
            {
                return NotFound();
            }

            return View(@group);
        }

        // POST: Groups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var @group = await _context.Group.FindAsync(id);
            _context.Group.Remove(@group);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GroupExists(int id)
        {
            return _context.Group.Any(e => e.Id == id);
        }
    }
}
