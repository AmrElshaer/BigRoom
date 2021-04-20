using System;
using System.Collections.Generic;
using System.Text;

namespace BigRoom.Service.Common.Behavoir
{
    public static class ExtractNameFromEmailExtention
    {
        public static string GetNameFromEmail(this string email)
        {
            if (string.IsNullOrEmpty(email)) return email;
            return  email.Contains('@')? email.Split('@')[0]:email;
        }
    }
}
