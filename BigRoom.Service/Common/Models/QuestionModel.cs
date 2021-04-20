using System;
using System.Collections.Generic;
using System.Text;

namespace BigRoom.Service.Common.Models
{
    public  class QuestionModel
    {
        public QuestionModel()
        {
            Choice = new List<string>();
        }

        public QuestionModel(string question, IList<string> choice)
        {
            Question = question;
            Choice = choice;
        }

        public string Question { get; set; }
        public IList<string> Choice { get; set; }
    }
}
