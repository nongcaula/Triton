using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Triton.Pages.Helper;
using Triton.Pages.Model;

namespace Triton.Pages.WayBill
{
    public class WayBillDetailsModel : PageModel
    {
        private readonly ILogger<WayBillDetailsModel> _logger;

        public WayBillDetailsModel(ILogger<WayBillDetailsModel> logger)
        {
            _logger = logger;
        }
        public async Task OnGet()
        {

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(StrHelper.EndPointBaseUrlWayBill))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    waybillModel = JsonConvert.DeserializeObject<WayBillsModel>(apiResponse);
                    WayBills = waybillModel.WayBillForms;
                    Vehicles = waybillModel.Vehicles;
                    waybillModel.SelectList = CollectionList.GetVehicles(Vehicles.ToList());
                }
            }
            await GetParcels();
            List<WayBillForm> wayBills = new List<WayBillForm>();
            foreach (var waybill in WayBills)
            {
                var parcels = Parcels.Where(s => s.ReferenceNumber == waybill.ReferenceNumber);
                if (parcels.Any())
                {
                   
                    waybill.TotalWeight = parcels.Sum(d => Convert.ToDouble(d.Mass));
                    waybill.NoParcels = parcels.Count();
                }
                if (waybillModel.Vehicles.Where(s => s.Id == waybill.Vehicle).Any())
                {
                    if (waybill.Vehicle > 0)
                    {
                        waybill.assignedVehicle = waybillModel.SelectList.Where(s => s.Value == waybill.Vehicle.ToString()).FirstOrDefault().Text;
                    }
                    else
                    {
                        waybill.assignedVehicle = "No Vehicle Assigned";

                    }
                }
                else waybill.assignedVehicle = "No Vehicle Assigned";
                wayBills.Add(waybill);
            }
            WayBills = wayBills;


        }

        public async Task GetParcels()
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(StrHelper.EndPointBaseUrlParcels))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    Parcels = JsonConvert.DeserializeObject<List<Parcel>>(apiResponse);
                }
            }
        }
        public WayBillsModel waybillModel { get; set; }
        public IList<WayBillForm>? WayBills { get; set; }
        public static IList<Vehicle>? Vehicles { get; set; }
        public static IList<Parcel>? Parcels { get; set; }

    }
}
