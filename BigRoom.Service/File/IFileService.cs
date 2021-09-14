using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigRoom.Service.File
{
    public interface IFileService
    {
        IList<string> ReadAnswerfile(string filename);
    }
}
