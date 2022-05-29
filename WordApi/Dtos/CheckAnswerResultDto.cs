using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordApi.Entities;

namespace WordApi.Dtos
{
    public class CheckAnswerResultDto
    {
        public bool Result { get; set; }

        public int TestCount { get; set; }
        public WordDefinition WordDef { get; set; }
    }
}
