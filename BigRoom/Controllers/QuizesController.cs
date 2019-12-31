using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BigRoom.Models;
using Classroom.Data;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using BigRoom.ViewModel;
using Microsoft.AspNetCore.Authorization;

namespace BigRoom.Controllers
{
    [Authorize]
    public class QuizesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHostingEnvironment _IhostEnv;
        public QuizesController(ApplicationDbContext context,IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _IhostEnv = hostingEnvironment;
        }
       
        // GET: Quizes
        public async Task<IActionResult> Index(string Groupid)
        {
            var resuilt = await _context.Quize.Where(a => a.GroupId == Groupid).ToListAsync();
            if (resuilt ==null)
            {
                return NoContent();
            }
            return View(resuilt);
        }
        
       
        public IActionResult GoHomeofGroup(string Groupid)
        {

           

            return View("GoHomeofGroup",Groupid);
        }
        // GET: Quizes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            var quize = await _context.Quize
                .FirstOrDefaultAsync(m => m.id == id);
            if (quize == null)
            {
                return NotFound();
            }
            var path =Path.Combine(Path.Combine(_IhostEnv.WebRootPath,"quize"),quize.file);
            ViewData["filequizename"] =quize.fileanswer;
            ViewData["TimeEnd"] = quize.TimeEnd;
          
                ViewData["Timerspan"] = quize.TimeSpan;
            
            
            List<questiongets> questiongets = new List<questiongets>();
            using (var reader=new StreamReader(path))
            {
                while (!reader.EndOfStream)
                {
                   var resuilt=await reader.ReadLineAsync();
                    if (resuilt!=null)
                    {
                      var line=resuilt.Split(",");
                        var question = new questiongets {choice=new List<string>() };
                        for (int i=0;i<line.Length;i++)
                        {
                            if (i == 0)
                            {
                              question.question = line[i];
                            }
                            else
                            {
                                question.choice.Add(line[i]);
                            }
                        }
                        questiongets.Add(question);
                    }
                }

            }
            if (questiongets.Count()==0)
            {
                return NotFound();
            }
            return View(questiongets);
        }
        [HttpGet]
        public IActionResult GetAnswerfile(string filename)
        {
            if (filename !=null)
            {
                            var path = Path.Combine(_IhostEnv.WebRootPath, "answer");
                            var fullpath = Path.Combine(path,filename);
                             var answers= ReadAnswerfile(fullpath);
               
                           
                                return new JsonResult(answers);
                            
            }
            return NotFound();
        }
        public  IList<string> ReadAnswerfile(string fullpath)
        {
            List<string> answers = new List<string>();
            using (var reader = new StreamReader(fullpath))
            {
                
                while (!reader.EndOfStream)
                {
                    var line =  reader.ReadLine();
                    if (line != null)
                    {
                        answers.Add(line);
                    }
                }
                
            }
            return answers;
        }
        [HttpPost]
        public async Task<IActionResult> Adddegree( [Bind("id,degree", "quize", "user")] Degree userquize)
        {
            if (userquize != null)
            {
                try
                {
                    var resuilt = await _context.Degree.AddAsync(userquize);
                    _context.SaveChanges();
                    return Ok();
                }
                catch (Exception ex)
                {
                    return NotFound();
                }


               
            }
            return NotFound();
        }
        // GET: Quizes/Create
        public IActionResult Create(string groupid)
        {
            ViewData["groupid"] = groupid;
            return View();
        }
        [AcceptVerbs("GET","POST")]
        public IActionResult filequestion(string file)
        {
            if (file.EndsWith(".csv"))
            {
                return Json(data: true);
            }
            return Json(data: false);
        }
        [AcceptVerbs("GET", "POST")]
        public IActionResult filequestionanswer(string fileanswer)
        {
            if (fileanswer!=null)
            {
                    if (fileanswer.EndsWith(".txt"))
                                {
                                    return Json(data: true);
                                }
            } 
           
            return Json(data: false);
        }
        // POST: Quizes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,file,fileanswer,TimeStart,TimeEnd,Groupid,TimeSpan")] quizeview quize)
        {
            if (ModelState.IsValid)
            {
                if (quize.file != null)
                {
                    var theFile = quize.file;

                    // Get the server path, wwwroot
                    string webRootPath = _IhostEnv.WebRootPath;

                    // Building the path to the uploads directory
                    var fileRoute = Path.Combine(webRootPath, "quize");

                    // Get the mime type
                    var mimeType = theFile.ContentType;

                    // Get File Extension
                    string extension = System.IO.Path.GetExtension(theFile.FileName);

                    // Generate Random name.
                    string name = Guid.NewGuid().ToString().Substring(0, 8) + extension;

                    // Build the full path inclunding the file name
                    string link = Path.Combine(fileRoute, name);

                    // Create directory if it does not exist.
                    FileInfo dir = new FileInfo(fileRoute);
                    dir.Directory.Create();

                    // Basic validation on mime types and file extension
                    string[] fileMimetypes = { "application/vnd.ms-excel" };
                    string[] fileExt = { ".csv" };
                    string fileanswerroot = Path.Combine(Path.Combine(webRootPath, "answer"), name.Replace(".csv", ".txt"));

                    try
                    {
                       
                            // Copy contents to memory stream.
                            Stream stream;
                            stream = new MemoryStream();
                            theFile.CopyTo(stream);
                            stream.Position = 0;
                            String serverPath = link;
                        Stream stream1answer = new MemoryStream();
                        quize.fileanswer.CopyTo(stream1answer);
                       
                        stream1answer.Position = 0;
                        using (FileStream fileStream = System.IO.File.Create(fileanswerroot))
                        {
                          await  stream1answer.CopyToAsync(fileStream);
                            fileStream.Dispose();
                        }
                            using (FileStream writerFileStream = System.IO.File.Create(serverPath))
                            {
                                await stream.CopyToAsync(writerFileStream);
                                writerFileStream.Dispose();
                            }

                            // Return the file path as json
                           
                        
                        
                    }

                    catch (ArgumentException ex)
                    {
                       // return Json(ex.Message);
                    }
                    //string path = Path.Combine(_IhostEnv.WebRootPath, "quize");
                    //string uniquename = Guid.NewGuid() + "_" + quize.file.FileName;
                    //string realpath = Path.Combine(path, uniquename);
                    //quize.file.CopyTo(new FileStream(realpath, FileMode.Create));

                    Quize quize1 = new Quize { id = 0,file= name,GroupId=quize.Groupid,fileanswer= name.Replace(".csv", ".txt"), TimeStart= quize.TimeStart,TimeEnd=quize.TimeEnd,TimeSpan=quize.TimeEnd-quize.TimeStart};

                _context.Add(quize1);
                await _context.SaveChangesAsync();
                }
               
                return RedirectToAction(nameof(Index),new { Groupid =quize.Groupid});
            }
            return View(quize);
        }

        // GET: Quizes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quize = await _context.Quize.FindAsync(id);
            if (quize == null)
            {
                return NotFound();
            }
            return View(quize);
        }

        // POST: Quizes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,file,fileanswer,TimeStart,TimeEnd,GroupId,TimeSpan")] Quize quize)
        {
            if (id != quize.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    quize.TimeSpan = quize.TimeEnd - quize.TimeStart;
                    _context.Update(quize);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuizeExists(quize.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index),new { Groupid =quize.GroupId});
            }
            return View(quize);
        }

        // GET: Quizes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quize = await _context.Quize
                .FirstOrDefaultAsync(m => m.id == id);
            if (quize == null)
            {
                return NotFound();
            }

            return View(quize);
        }

        // POST: Quizes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var quize = await _context.Quize.FindAsync(id);
            _context.Quize.Remove(quize);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuizeExists(int id)
        {
            return _context.Quize.Any(e => e.id == id);
        }
    }
}
