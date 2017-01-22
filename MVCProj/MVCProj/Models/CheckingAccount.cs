using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCProj.Models
{
    public class CheckingAccount
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(10)]
        [Column(TypeName="varchar")]
        [RegularExpression(@"\d{6,10}", ErrorMessage="Numer konta # ma zawierac od 6 do 10 znakow" )]
        [Display(Name="Numer konta")]
        public string AccountNumber { get; set; }

        [Required]
        [Display(Name = "Imie")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Nazwisko")]
        public string LastName { get; set; }

        [Display(Name = "Imię i nazwisko")]
        public string Name { get { return String.Format("{0} {1}", this.FirstName, this.LastName); } }
        
        [Display(Name = "Stan konta")]
        [DataType(DataType.Currency)]
        public decimal Balance { get; set; }

        public virtual ApplicationUser User { get; set; }

        [Required]
        public string ApplicationUserId { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}