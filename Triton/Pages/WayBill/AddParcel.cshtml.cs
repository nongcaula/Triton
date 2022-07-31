using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace Triton.Pages.WayBill
{
    public class AddParcelModel : PageModel
    {
        public AddParcelModel() { }
        public void OnGet(string id)
        {
            if (!string.IsNullOrEmpty(id))
            Parcel.RefNumber = id;
        }

        public async Task<ActionResult> OnPostAsync(Parcel parcel)
        {
            parcel.ReferenceNumber = Parcel.RefNumber;

            if (parcel != null)
            {
                parcel.ReferenceNumber = Parcel.RefNumber;
                using (var httpClient = new HttpClient())
                {
                    var json = JsonConvert.SerializeObject(parcel);
                    var stringContent = new StringContent(json, UnicodeEncoding.UTF8, Helper.StrHelper.Mediatype);
                    using (var response = await httpClient.PostAsync(Helper.StrHelper.EndPointBaseUrlParcels, stringContent))
                    {
                        await response.Content.ReadAsStringAsync();
                        if (response.IsSuccessStatusCode)
                        {
                            string baseUrl = GetBaseUrl();
                            return Redirect(baseUrl);
                        }
                        else return BadRequest();
                    }
                }
            }
            return Page();
        }
        private string GetBaseUrl()
        {
            return Request.Scheme + "://" + Request.Host.ToUriComponent() + "/waybill/WayBillDetails";
        }
        [BindProperty]
        public Parcel? Parcel { get; set; }
    }
}
