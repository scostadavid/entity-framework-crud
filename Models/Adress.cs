using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace EF_CRUD.Models
{
    public class Adress
    {

        public enum AdressType
        {
            BILLING, COMMERCIAL, MAIL, DELIVERY, RESIDENTIAL 
        }

        [Key]
        public int AdressID {get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string  Country { get; set; }
        public string  PostalCode { get; set; }
        public string  StreetName { get; set; }
        public int AddressNumber  { get; set; }
        public AdressType Type {get; set; }

        
        // Client relationship
        public int ClientID { get; set; }
        public virtual Client Client { get; set; }
    }
}