using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace EF_CRUD.Models
{

    public enum ClientType 
    {
        PF, PJ, BASE
    }
    public class Client
    {
        [Key]
        public int ClientID {get; set;}
        //
        public ICollection<Phone> Phones { get; set; }
        public ICollection<Adress> Addresses { get; set; }
    }
}