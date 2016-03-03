using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCMock.Models
{
    public class Ship
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public int ShipTypeID { get; set; }
        public virtual ShipType ShipType { get; set; }

        public int ShippingCompanyID { get; set; }
        public virtual ShippingCompany ShippingCompany { get; set; }
    }

    public class ShippingCompany
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
    }

    public class ShipType
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }

        //public virtual IQueryable<Ship> Ships { get; set; } 
    }
}