using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BigRoom.Models;
using Classroom.Data;

namespace BigRoom.Controllers
{
    public class UserGroupsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserGroupsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: UserGroups
        public async Task<IActionResult> Index(string CodeJoin)
        {
            return View(await _context.UserGroups.Where(a=>a.CodeJoin==CodeJoin).ToListAsync());
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
                    _context.Add(userGroups);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("GoToGroup", "Groups", new { Codejoin =userGroups.CodeJoin});
                }
                catch (Exception)
                {
                    throw new Exception(message:"You are Exiting in this group");
                }
               
            }
            return View(userGroups);
        }

      
    }
}
