using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace EF_CRUD.Models
{
    public class PhysicalPerson : Client
    {
        [Key]
        public int PhysicalPersonId {get; set;}
        public string LastName { get; set; }
        public string FirstMidName { get; set; }

        public string CPF {get; set;}

        public DateTime BirthDate {get; set; }
    }
}