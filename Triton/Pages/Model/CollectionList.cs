using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Triton.Pages.Model
{
    public static class CollectionList
    {
        public static List<SelectListItem> GetAllBranches()
        {
            List<SelectListItem> branches = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = "Durban",
                    Value = "Durban"
                },
                new SelectListItem
                {
                    Text = "Johannesburg",
                    Value = "Johannesburg",

                }
            };
            return branches;
        }

        public static List<SelectListItem> GetAllTransmissionTypes()
        {
            List<SelectListItem> transmissions = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = "None",
                    Value = "None"
                },
                new SelectListItem
                {
                    Text = "Manual",
                    Value = "Manual",

                },
                new SelectListItem
                {
                    Text = "Automatic",
                    Value = "Automatic",

                },
                new SelectListItem
                {
                    Text = "Semi-Automatic",
                    Value = "Semi-Automatic",

                }
            };
            return transmissions;
        }

        public static List<SelectListItem> GeAllVehicleTypes()
        {
            List<SelectListItem> vehicleTypes = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = "AirPlain",
                    Value = "AirPlain",

                },
                new SelectListItem
                {
                    Text = "Bus",
                    Value = "Bus",

                },
                new SelectListItem
                {
                    Text = "Car",
                    Value = "Car"
                },
                new SelectListItem
                {
                    Text = "Truck",
                    Value = "Truck",

                }
            };
            return vehicleTypes;
        }

        public static List<SelectListItem> GetAllFuelTypes()
        {
            List<SelectListItem> fuelTypes = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = "Petrol",
                    Value = "Petrol",

                },
                new SelectListItem
                {
                    Text = "Diesel",
                    Value = "Diesel",

                },
                new SelectListItem
                {
                    Text = "None",
                    Value = "None"
                }
            };
            return fuelTypes;
        }

        public static List<SelectListItem> GetAllServices()
        {
            List<SelectListItem> service = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = "Express",
                    Value = "Express",

                },
                new SelectListItem
                {
                    Text = "Over-night",
                    Value = "Over-night",

                },
                new SelectListItem
                {
                    Text = "Same-day",
                    Value = "Same-day"
                }
            };
            return service;
        }

        public static SelectList GetVehicles(List<Vehicle> vehicles)
        {

            var vehicleSelectList = new SelectList(vehicles.Select(item => new SelectListItem
            {
                Text = item.RegistrationNumber + " (" + item.Make + "-" + item.Model + "-" +item.Color + ")", 
                Value = item.Id.ToString()
            }).ToList(), "Value", "Text");

            return vehicleSelectList;
        }

    }
}
