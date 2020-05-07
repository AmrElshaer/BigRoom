using BigRoom.Models;
using Classroom.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BigRoom.Controllers
{
    public class StudentController : Controller
    {
        private readonly UserManager<User> _userManager;

        public ApplicationDbContext _dbContext { get; }

        public StudentController(ApplicationDbContext dbContext, UserManager<User> userManager)
        {
            _userManager = userManager;
            this._dbContext = dbContext;
        }
        // GET: Student
        public async Task<ActionResult> Index()
        {
            var usergroups = await this._dbContext.Users.Include(a => a.GroupsThatAdmin).Include(a => a.Groups).ThenInclude(a => a.group).FirstOrDefaultAsync(a => a.UserName == this.User.Identity.Name);

            return View(usergroups);
        }
        // GET: Student/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Student/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Student/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}