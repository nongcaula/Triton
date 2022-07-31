using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using QRCoder;
using Triton.Pages.Helper;
using Triton.Pages.Model;

namespace Triton.Pages.WayBill
{
    public class CreateModel : PageModel
    {

        public CreateModel() { }

        public async Task<ActionResult> OnPostAsync(WayBillForm wayBill)
        {

            if (wayBill != null)
            {
                using (var httpClient = new HttpClient())
                {
                    var json = JsonConvert.SerializeObject(wayBill);
                    var stringContent = new StringContent(json, UnicodeEncoding.UTF8, StrHelper.Mediatype);
                    if (wayBill.Id == 0)
                    {
                        using (var response = await httpClient.PostAsync(StrHelper.EndPointBaseUrlWayBill, stringContent))
                        {
                            await response.Content.ReadAsStringAsync();
                            if (response.IsSuccessStatusCode)
                            {
                                string url = GetBaseUrl();
                                return Redirect(url);
                            }
                            return BadRequest();
                        }
                    }
                    else
                    {
                        using (var response = await httpClient.PutAsync(StrHelper.EndPointWayBillext + wayBill.Id, stringContent))
                        {
                            await response.Content.ReadAsStringAsync();
                            if (response.IsSuccessStatusCode)
                            {
                                string url = GetBaseUrl();
                                return Redirect(url);
                            }
                            return BadRequest();
                        }

                    }



                }

            }
            return Page();
        }

        private string GetBaseUrl()
        {
            return Request.Scheme + "://" + Request.Host.ToUriComponent() + "/waybill/WayBillDetails";
        }
        public async Task OnGet(int id)
        {
            if (id > 0)
            {
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync(StrHelper.EndPointWayBillext + id))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        WayBill = JsonConvert.DeserializeObject<WayBillForm>(apiResponse);

                    }
                }

            }
            await GetVehiclesFromApi();
        }

        private async Task GetVehiclesFromApi()
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(StrHelper.EndPointBaseUrlWayBill))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    wayBillModel = JsonConvert.DeserializeObject<WayBillsModel>(apiResponse);
                    Vehicles = wayBillModel.Vehicles;
                    wayBillModel.SelectList = CollectionList.GetVehicles(Vehicles.ToList());

                }
            }
        }

     

        [BindProperty]
        public WayBillForm? WayBill { get; set; }
        public WayBillsModel? wayBillModel { get; set; }
        public static IList<Vehicle>? Vehicles { get; set; }

    }
}
