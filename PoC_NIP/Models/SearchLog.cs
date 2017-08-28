using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PoC_NIP.Models
{
    public class SearchLog
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Company")]
        public int? CompanyFound { get; set; }
        [Required, Display(Name = "Utworzono")]
        public DateTime Created { get; set; }
        [Display(Name = "Wyszukiwana fraza")]
        public string Phrase { get; set; }
        [Required, Display(Name = "Znaleziono")]
        public bool Found { get; set; }
        [Required, Display(Name = "Nagłówki zapytania HTTP")]
        public string HttpRequestHeaders { get; set; }
        public virtual Company Company { get; set; }
    }
}