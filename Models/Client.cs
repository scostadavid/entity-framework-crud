using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace EF_CRUD.Models
{
    public class Client
    {
        [Key]
        public int ClientID {get; set;}

        //
        public virtual ICollection<Phone> Phones { get; set; }
        public virtual ICollection<Adress> Addresses { get; set; }
    }
}