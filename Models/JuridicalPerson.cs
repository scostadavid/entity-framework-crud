using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace EF_CRUD.Models
{
    public class JuridicalPerson : Client
    {
        // Razão social
        public string CompanyName {get; set;}
        // Nome fantasia
        public string TradeName {get; set; }
        public string CNPJ {get; set; }

    }
}