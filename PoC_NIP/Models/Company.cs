using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PoC_NIP.Models
{
    public class Company
    {
        [Key]
        public int Id { get; set; }
        [RegularExpression(@"^\D*(?:\d\D*){10}$", ErrorMessage = "Numer NIP musi zawierać 10 cyfr."), Display(Name = "Numer NIP")]
        public string Nip { get; set; }
        [RegularExpression(@"^\d{9}$", ErrorMessage = "Numer REGON musi składać się z 9 cyfr."), Display(Name = "Numer REGON")]
        public string Regon { get; set; }
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Numer KRS musi składać się z 10 cyfr."), Display(Name = "Numer KRS")]
        public string Krs { get; set; }
        [Required, Display(Name = "Nazwa firmy")]
        public string Name { get; set; }
        [Required, Display(Name = "Ulica")]
        public string Street { get; set; }
        [RegularExpression(@".*[0-9].*", ErrorMessage = "Podaj prawidłowy numer budynku."), Display(Name = "Numer")]
        public string StreetNumber { get; set; }
        [RegularExpression(@"^\d{2}-\d{3}$", ErrorMessage = "Podaj prawidłowy kod pocztowy."), Display(Name = "Kod pocztowy")]
        public string PostalCode { get; set; }
        [Required, Display(Name = "Miasto")]
        public string City { get; set; }
        public virtual ICollection<SearchLog> SearchLog { get; set; }
    }
}