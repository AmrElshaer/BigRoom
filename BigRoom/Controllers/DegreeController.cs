using BigRoom.Models;
using Classroom.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace BigRoom.Controllers
{
    public class DegreeController : Controller
    {
        public readonly ApplicationDbContext context;
        public DegreeController(ApplicationDbContext Context)
        {
            context = Context;
        }

        public IActionResult Index(int? Id)
        {
            IEnumerable<Degree> degrees;
            if (Id == null)
            {
                degrees = context.Degree.ToArray();
            }
            else
            {
                degrees = context.Degree.Where(a => a.quize == Id.ToString());
            }
            return View(degrees);
        }
    }
}