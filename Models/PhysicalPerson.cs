using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace EF_CRUD.Models
{
    public class PhysicalPerson : Client
    {
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        
        [Required]
        [Display(Name = "First Name")]
        public string FirstMidName { get; set; }
        
        [Required]
        [RegularExpression("^\\d{3}\\.\\d{3}\\.\\d{3}\\-\\d{2}$", ErrorMessage ="Enter a value in the format 111.111.111-11")]
        public string CPF {get; set;}
        
        [Required]
        [Display(Name = "Birth Date")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime BirthDate {get; set; }
    }
}