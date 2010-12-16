using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BadHomburg.Models
{
    public class Person
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [StringLength(16)]
        [Required]
        [Display(ResourceType=typeof(Strings),Name="Anrede")]
        public string Anrede { get; set; }

        [StringLength(64)]
        public string Vorname { get; set; }

        [StringLength(64)]
        [Required]
        public string Nachname { get; set; }

        [Range(1970,2000)]
        public int Geburtsjahr { get; set; }

        public void CopyFrom(Person person)
        {
            Anrede = person.Anrede;
            Nachname = person.Nachname;
            Vorname = person.Vorname;
            Geburtsjahr = person.Geburtsjahr;
        }
    }
}