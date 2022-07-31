using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Triton.Pages.WayBill
{
    public class WayBillForm
    {
        [Key]
        public int Id { get; set; }
        public string ReferenceNumber { get; set; }
        public DateTime ShipDate { get; set; }
        public DateTime ShipmentDate { get; set; }
        public int Vehicle { get; set; }
        public string Company { get; set; }
        public string FromContactName { get; set; }
        public string FromPhoneNumber { get; set; }
        public string ToLastName { get; set; }
        public string ToFirstName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public double TotalWeight { get; set; }
        public int NoParcels { get; set; }
        public string assignedVehicle { get; set; }

    }
}
