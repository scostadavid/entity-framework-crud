using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace EF_CRUD.Models
{
    public enum AdressType
    {
        BILLING, COMMERCIAL, MAIL, DELIVERY, RESIDENTIAL 
    }

    public class Adress
    {

        [Key]
        public int AdressID {get; set; }
        
        [Required]
        public string City { get; set; }
        
        [Required]
        public string State { get; set; }
        
        [Required]
        public string  Country { get; set; }
        
        [Required]
        [Display(Name = "Postal Code")]
        public string  PostalCode { get; set; }
        
        [Required]
        [Display(Name = "Street Name")]
        public string  StreetName { get; set; }

        [Required]
        [Display(Name = "Address Number")]
        public int AddressNumber  { get; set; }
        
        [Required]
        [Display(Name = "Address Type")]
        public AdressType AdressType {get; set; }
        
        // Client relationship
        public int ClientID { get; set; }
        public Client Client { get; set; }
    }
}