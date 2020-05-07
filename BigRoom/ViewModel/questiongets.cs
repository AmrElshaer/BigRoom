using System.Collections.Generic;

namespace BigRoom.ViewModel
{
    public class questiongets
    {
        public string question { get; set; }
        public List<string> choice { get; set; }
    }
    public class answerpost
    {
        public int numberofquestion { get; set; }
        public string choice { get; set; }
    }
}
