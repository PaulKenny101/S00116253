using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RAD302CA.Models
{
    public class Guest
    {
        [Key]
        public int GuestId { get; set; }
        public string GuestName { get; set; }

    }
}