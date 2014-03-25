using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RAD302CA.Models
{
    public class Leg
    {
        [Key]
        public int LegId { get; set; }
        [Required, Display(Name = "Start Location")]
        public string StartLocation { get; set; }
        [Required, Display(Name = "End Location")]
        public string EndLocation { get; set; }
       [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime StartDate { get; set; }
       [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime EndDate { get; set; }
        public int TripId { get; set; }

        public virtual Trip Trip { get; set; }

        public virtual ICollection<Guest> Guests { get; set; }

        public bool CheckLeg()
        {
            //first step is to provide a series of check to make sure leg is in line with others in trip
            if (this.EndDate < this.StartDate)
            {
                return false;
            }
            if (this.Trip.TripComplete == true)
            {
                return false;
            }
            if (this.StartDate < this.Trip.StartDate)
            {
               return false;
            }
            if (this.Trip.EndDate < this.EndDate)
            {
                return false;
            }

            //add other legs in trip to list
           List<Leg> tripLegs = new List<Leg>();
            tripLegs = this.Trip.Legs.ToList();
            if (tripLegs.Count == 0)
            {
                return true;
            }

            //check against other legs
            foreach (var leg in tripLegs)
            {
                if (leg.StartDate <= this.StartDate && leg.EndDate >= this.StartDate)
                    return false; 
                if (leg.StartDate <= this.EndDate && leg.EndDate >= this.EndDate)
                    return false;
            }

            //return that leg is ok
            return true;
        }
    }
}