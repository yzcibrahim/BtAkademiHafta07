using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hafta07_01WordMaster.Validations
{
    public class MyRequiredAttribute: ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value.ToString().ToUpper().StartsWith("ASD"))
            {
                ErrorMessage = "gerçek bir kelime girin";
                return false;
            }
            else
                return true;
        }
    }

    
}
