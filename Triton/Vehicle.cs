using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Triton.Pages.Model;

namespace Triton
{
    public class Vehicle
    {
        [Key]
        public int Id { get; set; }
        public string Branch { get; set; }
        public string FuelType { get; set; }
        public int Year { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public string Type { get; set; }
        public string Transmission { get; set; }
        public string RegistrationNumber { get; set; }
        public decimal Capacity { get; set; }

        public static List<SelectListItem> BranchSelectList = CollectionList.GetAllBranches();
        public static List<SelectListItem> TransmissionSelectList = CollectionList.GetAllTransmissionTypes();
        public static List<SelectListItem> VehicleTypeSelectList = CollectionList.GeAllVehicleTypes();
        public static List<SelectListItem> FuelTypeSelectList = CollectionList.GetAllFuelTypes();
    }
}
