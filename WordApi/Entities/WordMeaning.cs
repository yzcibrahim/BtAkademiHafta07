using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WordApi.Entities
{
    public class WordMeaning
    {
        public int Id { get; set; }
        public string Meaning { get; set; }
        public int? LangId { get; set; }

        public int? WordDefinitionId { get; set; }

        [NotMapped]
        public bool Deleted { get; set; }

        [JsonIgnore]
        [ForeignKey("WordDefinitionId")]
        public virtual WordDefinition WordDef { get; set; }

    }
}
