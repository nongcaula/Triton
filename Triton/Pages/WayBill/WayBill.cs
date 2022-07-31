using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Triton.Pages.WayBill
{
    public class WayBill
    {
        [Key]
        public int WbId { get; set; }
        public string WbFrom { get; set; }
        public string WbFromContact { get; set; }
        public string WbFromPhone { get; set; }
        public string LineAddress1 { get; set; }
        public string LineAddress2 { get; set; }
        public string LineAdd { get; set; }
        public string Code { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string WbToContact { get; set; }
        public string WbToPhone { get; set; }
        public string Dimensions { get; set; }
        public string Mass { get; set; }
        public string Service { get; set; }
        public string SpecialInstructions { get; set; }
        public string Reference { get; set; }
    }
}
