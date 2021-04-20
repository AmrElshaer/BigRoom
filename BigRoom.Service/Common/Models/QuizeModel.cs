using BigRoom.Service.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BigRoom.Service.Common.Models
{
    public  class QuizeModel
    {
        public QuizeModel(IEnumerable<QuestionModel> questionModels, QuizeDto quizeDto)
        {
            QuestionModels = questionModels;
            QuizeDto = quizeDto;
        }

        public IEnumerable<QuestionModel> QuestionModels { get; set; }
        public QuizeDto QuizeDto { get; set; }
    }
}
