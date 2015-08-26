using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.Spatial;

namespace WebInterface.Models
{
    public class Station
    {
        [Key]
        public long StationId { get; set; }

        [Display(Name = "Station Name")]
        public String Name { get; set; }

        [Display(Name = "Station Location")]
        public DbGeography Location { get; set; }

        public virtual List<Sample> Samples { get; set; }
    }

    public class Sample
    {
        [Key]        
        public long SampleId { get; set; }

        [Required]
        [Display(Name = "Time Stamp")]
        public DateTime DateTime { get; set; }

        [Required]
        [Display(Name = "Temperature")]
        public Double Temperature { get; set; }

        [Required]
        [Display(Name = "Specific Conductivity")]
        public Double SC { get; set; }

        [Required]
        [Display(Name = "Acidity (PH)")]
        public Double PH { get; set; }

        [Required]
        [Display(Name = "Turbidity")]
        public Double Turbidity { get; set; }

        [Required]
        [Display(Name = "Dissolved Oxygen")]
        public Double Oxygen { get; set; }

        [Required]
        public virtual Station Station { get; set; }
    }
}