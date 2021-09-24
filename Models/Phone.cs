using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace EF_CRUD.Models
{
    public class Phone
    {
        public enum PhoneType 
        {
            CELL_PHONE, RESIDENTIAL, COMMERCIAL
        }

        [Key]
        public int PhoneID {get; set; }
        public string PhoneNumber {get; set;}
        public PhoneType Type {get; set;}


        // Client relationship
        public int ClientID { get; set; }
        public virtual Client Client { get; set; }
    }
}