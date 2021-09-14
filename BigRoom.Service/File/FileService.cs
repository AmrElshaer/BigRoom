using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BigRoom.Service.Common.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace BigRoom.Service.File
{
    public class FileService : IFileService
    {
        private readonly IHostingEnvironment ihostEnv;

        public FileService(IHostingEnvironment ihostEnv)
        {
            this.ihostEnv = ihostEnv;
        }
        public async Task<string> AddFileAsync(IFormFile file, string path)
        {
            try
            {
                string webRootPath = ihostEnv.WebRootPath;
                // Generate Random name.
                string name = Guid.NewGuid().ToString().Substring(0, 8) + file.FileName;
                // Build the full path inclunding the file name
                string questionFilePath = Path.Combine(Path.Combine(webRootPath, path), name);
                #region Copy contents to memory stream.
                Stream stream;
                stream = new MemoryStream();
                file.CopyTo(stream);
                stream.Position = 0;
                #endregion
                #region Copy contents to folder
                using (FileStream writerFileStream = System.IO.File.Create(questionFilePath))
                {
                    await stream.CopyToAsync(writerFileStream);
                    writerFileStream.Dispose();
                }
                #endregion
                return name;
            }
            catch (Exception)
            {
                throw;
            }
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

        public void RemoveFile(string fileName, string folderName)
        {
            string webRootPath = ihostEnv.WebRootPath;
            string filePath = Path.Combine(Path.Combine(webRootPath, folderName), fileName);
            System.IO.File.Delete(filePath);
        }
        public async Task<IEnumerable<QuestionModel>> ReaderQuestionsAsync(string quizeFile)
        {
            var csvFilePath = Path.Combine(Path.Combine(ihostEnv.WebRootPath, "quize"), quizeFile);
            var questions = new List<QuestionModel>();
            using (var reader = new StreamReader(csvFilePath))
            {
                while (!reader.EndOfStream)
                {
                    var resuilt = await reader.ReadLineAsync();
                    if (resuilt is null) continue;
                    var line = resuilt.Trim().Split(",");
                    var question = new QuestionModel(line[0], line.Skip(1).ToList());
                    questions.Add(question);
                }
            }
            return questions;
        }
    }
}
