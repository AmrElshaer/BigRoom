using BigRoom.Service.Common.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigRoom.Service.File
{
    public interface IFileService
    {
        Task<string> AddFileAsync(IFormFile file, string path);
        IList<string> ReadAnswerfile(string filename);
        Task<IEnumerable<QuestionModel>> ReaderQuestionsAsync(string quizeFile);
        void RemoveFile(string fileName, string folderName);
    }
}
