using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kirjasto.models
{
    internal class Book
    {

        [Key]
        [Column("BookID")]
        public int Id { get; set; }
#pragma warning disable 
        public string Title { get; set; }
        public string ISBN { get; set; }
        public int? PublicationYear { get; set; }
        public string AvailableCopies { get; set; }
#pragma warning enable
    }
}
