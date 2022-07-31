using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Triton.Pages.Model;

namespace Triton.Pages.WayBill
{
    public class Parcel
    {
        [Key]
        public int Id { get; set; }
        public string ReferenceNumber { get; set; }
        public string Dimensions { get; set; }
        public string Mass { get; set; }
        public string Service { get; set; }

        public static string RefNumber { get; set; }
        public static List<SelectListItem> ServiceList = CollectionList.GetAllServices();

    }
}
