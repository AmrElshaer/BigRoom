using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
namespace BigRoom.Service.File
{
    public class FileService : IFileService
    {
        private readonly IHostingEnvironment ihostEnv;

        public FileService(IHostingEnvironment ihostEnv)
        {
            this.ihostEnv = ihostEnv;
        }

        public IList<string> ReadAnswerfile(string filename)
        {
            var fullpath = Path.Combine(Path.Combine(ihostEnv.WebRootPath, "answer"), filename);
            List<string> answers = new List<string>();
            using (var reader = new StreamReader(fullpath))
            {

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    if (line != null)
                    {
                        answers.Add(line);
                    }
                }

            }
            return answers;
        }
    }
}
