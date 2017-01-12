using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCProj.Models
{
    public class EmailFormModel
    {
        [Required, Display(Name = "Imię")]
        public string FromName { get; set; }
        [Required, Display(Name = "Twój adres email"), EmailAddress]
        public string FromEmail { get; set; }
        [Required, Display(Name = "Treść wiadomości")]
        public string Message { get; set; }
    }
}