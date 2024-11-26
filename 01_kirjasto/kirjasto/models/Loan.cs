using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kirjasto.models
{
    internal class Loan
    {

        [Key]
        [Column("LoanID")]
        public int Id { get; set; }
        public string? BookId { get; set; }
        public string? MemberId { get; set; }
        public string? LoanDate { get; set; }
        public string? DueDate { get; set; }
        public string? ReturnDate { get; set; }
        public DateTime? RegistrationDate { get; set; }

    }
}
