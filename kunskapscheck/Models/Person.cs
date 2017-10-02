using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace kunskapscheck
    {
    public class Person
        {

            public Guid id { get; set; }
            [Required]
            public string Namn { get; set; }
            [Required]
            [Display(Name = "Telefon Nummer")]
            public string Telefon { get; set; }
            [Required]
            public string Adress { get; set; }

            public DateTime Uppdaterad { get; set; }



        }
    }