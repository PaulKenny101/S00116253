using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RAD302CA.Models
{
    public class Trip
    {
        [Key]
        public int TripId { get; set; }
        [Required, Display(Name = "Trip Name")]
        public string TripName { get; set; }
         [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime StartDate { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime EndDate { get; set; }
        public bool TripViable { get; set; }
        public bool TripComplete { get; set; }

        public virtual ICollection<Leg> Legs { get; set; }

        public int DaysInTrip()
        {
            //how many days are planned for the trip
            return EndDate.Subtract(StartDate.Add(new TimeSpan(-1, 0, 0, 0))).Days;
        }


        public bool IsTripComplete()
        {
            if (EndDate < DateTime.Now)
            {
                return true;
            }
            return true;
        }



    }
}