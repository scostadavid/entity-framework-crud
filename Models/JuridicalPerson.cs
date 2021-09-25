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
        public string CNPJ {get; set; }

    }
}