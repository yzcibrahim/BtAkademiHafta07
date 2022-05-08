using DataAccessLayer.Entities;
using Hafta07_01WordMaster.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hafta07_01WordMaster.Models
{
    public class WordDefinitionViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Kelime")]
        [MaxLength(10,ErrorMessage ="en falza on haneli bir kelime olabilir")]
        [Required(ErrorMessage ="Kelime boş olamaz")]
        [MyRequired]
        public string Word { get; set; }

        public int? LanguageId { get; set; }

        public List<WordMeaningViewModel> Meanings { get; set; } = new List<WordMeaningViewModel>();

        public List<Language> Languages = new List<Language>();


        //[Range(18,28)]
        //public int Yas { get; set; }

        //[EmailAddress(ErrorMessage = "Geçerli bir e-mail adresi giriniz")]
        //public string Email { get; set; }
    }
}
