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
        // GET: UserGroups/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var userGroups = await _context.UserGroups
        //        .FirstOrDefaultAsync(m => m.groupsid == id);
        //    if (userGroups == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(userGroups);
        //}

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
                                return RedirectToAction(nameof(Index));
                }
                catch (Exception)
                {
                    throw new Exception(message:"You are Exiting in this group");
                }
               
            }
            return View(userGroups);
        }

        // GET: UserGroups/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var userGroups = await _context.UserGroups.FindAsync(id);
        //    if (userGroups == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(userGroups);
        //}

        //// POST: UserGroups/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int? id, [Bind("usersid,groupsid")] UserGroups userGroups)
        //{
        //    if (id != userGroups.groupsid)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(userGroups);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!UserGroupsExists(userGroups.groupsid))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(userGroups);
        //}

        //// GET: UserGroups/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var userGroups = await _context.UserGroups
        //        .FirstOrDefaultAsync(m => m.groupsid == id);
        //    if (userGroups == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(userGroups);
        //}

        //// POST: UserGroups/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var userGroups = await _context.UserGroups.FindAsync(id);
        //    _context.UserGroups.Remove(userGroups);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool UserGroupsExists(int id)
        //{
        //    return _context.UserGroups.Any(e => e.groupsid == id);
        //}
    }
}
