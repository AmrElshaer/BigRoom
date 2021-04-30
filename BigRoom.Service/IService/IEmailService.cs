using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigRoom.Service.IService
{
    public interface IEmailService
    {
        Task SendAsync(string to,string body,string subject);
    }
}
