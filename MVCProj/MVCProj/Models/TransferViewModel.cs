using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCProj.Models
{
    public class TransferViewModel
    {
        [Required]
        [DataType(DataType.Currency)]
        [Display(Name = "Kwota")]
        public decimal Amount { get; set; }

        [Required]
        public int CheckingAccountId { get; set; }

        [Required]
        [Display(Name = "Nr konta #")]
        public string DestinationCheckingAccountNumber { get; set; }
    }
}