using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace EF_CRUD.Models
{
    public class JuridicalPerson : Client
    {
        
        // Razão social
        [Required]
        [Display(Name = "Company Name")]
        public string CompanyName {get; set;}
        
        // Nome fantasia
        [Required]
        [Display(Name = "Trade Name")]
        public string TradeName {get; set; }
        
        [Required]
        [RegularExpression("^\\d{2}\\.\\d{3}\\.\\d{3}\\/\\d{4}\\-\\d{2}$", ErrorMessage ="Enter a value in the format 11.111.111/1111-11")]
        public string CNPJ {get; set; }

    }
}