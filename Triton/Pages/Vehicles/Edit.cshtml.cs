using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Triton.Pages.Vehicles
{
    public class EditModel : PageModel
    {
        public EditModel()
        { }
        public IActionResult OnGet(int id)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = httpClient.GetStringAsync(Helper.StrHelper.EndPoint + id))
                {
                    string apiResponse = response.Result;
                    Vehicle = JsonConvert.DeserializeObject<Vehicle>(apiResponse);
                    Vehicle.FuelType = Vehicle.FuelType.Trim();
                }
            }
            return Page();
        }
        public async Task<ActionResult> OnPostAsync(Vehicle vehicle)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (Vehicle != null)
            {
                using (var httpClient = new HttpClient())
                {
                    var json = JsonConvert.SerializeObject(vehicle);
                    var stringContent = new StringContent(json, UnicodeEncoding.UTF8, Helper.StrHelper.Mediatype);
                    using (var response = await httpClient.PutAsync(Helper.StrHelper.EndPoint + vehicle.Id, stringContent))
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
            return Request.Scheme + "://" + Request.Host.ToUriComponent();
        }

        [BindProperty]
        public Vehicle? Vehicle { get; set; }
    }
}
