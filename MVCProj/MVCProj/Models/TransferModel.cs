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
        [Required]
        [StringLength(10)]
        [Display(Name = "Rachunek odbiorcy")]
        [RegularExpression(@"\d{6,10}", ErrorMessage = "Numer konta # ma zawierac od 6 do 10 znakow")]
        public string ReceiverAccount { get; set; }

        [Required]
        [Display(Name = "Tytuł przelewu")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Imię i nazwisko odbiorcy")]
        public string ReceiverName { get; set; }

        [Display(Name = "Adres odbiorcy")]
        public string ReceiverAddress { get; set; }

        [Display(Name = "Dane nadawcy")]
        public string UserName { get; set; }

        [Display(Name="Rachunek nadawcy")]
        public string AccountNumber { get; set; }

        [Display(Name = "Dostępne środki")]
        [DataType(DataType.Currency)]
        public decimal Balance { get; set; }

        [Required]
        [Display(Name = "Kwota przelewu")]
        [RegularExpression(@"^\$?(?=\(.*\)|[^()]*$)\(?\d{1,3}(\.?\d{3})?(,\d\d?)?\)?$", ErrorMessage = "Podaj właściwą wartość kwoty przelewu")]       
        public string Amount { get; set; }

    }
}