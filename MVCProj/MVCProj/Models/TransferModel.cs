using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCProj.Models
{
    public class TransferModel
    {

        [Display(Name = "Rachunek odbiorcy")]
        public string ReceiverAccount { get; set; }

        [Display(Name = "Tytuł przelewu")]
        public string Title { get; set; }

        [Display(Name = "Imię i nazwisko odbiorcy")]
        public string ReceiverName { get; set; }

        [Display(Name = "Adres odbiorcy")]
        public string ReceiverAddress { get; set; }

        [Display(Name = "Imię i nazwisko nadawcy")]
        public string UserName { get; set; }

        [Display(Name="Rachunek nadawcy")]
        public string AccountNumber { get; set; }

        [Display(Name = "Dostępne środki")]
        [DataType(DataType.Currency)]
        public decimal Balance { get; set; }

        [Display(Name = "Kwota przelewu")]
        public string Amount { get; set; }

    }
}