using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WordApi.Entities
{
    public class AnswerStastistic
    {
        public int Id { get; set; }
        public int WordDefId { get; set; }

        public string Username { get; set; }
        public int AskCount { get; set; }
        public int CorrectCount { get; set; }
    }
}
