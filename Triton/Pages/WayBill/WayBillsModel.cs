using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Triton.Pages.WayBill
{
    public class WayBillsModel
    {
        public List<WayBillForm> WayBillForms { get; set; }
        public List<Vehicle> Vehicles { get; set; }

        public SelectList SelectList { get; set; }
    }
}
