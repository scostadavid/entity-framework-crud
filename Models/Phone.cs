using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace EF_CRUD.Models
{
    public enum PhoneType 
    {
        CELL_PHONE, RESIDENTIAL, COMMERCIAL
    }
    public class Phone
    {

        [Key]
        public int PhoneID {get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        public string PhoneNumber {get; set;}

        [Required]
        [Display(Name = "Phone Type")]
        public PhoneType PhoneType {get; set;}

        // Client relationship
        [Display(Name = "Client ID")]
        public int ClientID { get; set; }
        public Client Client { get; set; }
    }
}