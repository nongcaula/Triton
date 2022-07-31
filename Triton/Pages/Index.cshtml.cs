using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Triton.Pages.Helper;
using Triton.Pages.Model;

namespace Triton.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public IList<Vehicle>? Vehicles { get; set; }

        public async Task OnGetAsync()
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(StrHelper.EndPointBaseUrl))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    Vehicles = JsonConvert.DeserializeObject<List<Vehicle>>(apiResponse);
                }
            }
        }

        [BindProperty]
        public Vehicle? Vehicle { get; set; }

       
        public async Task<ActionResult> OnPostAsync(Vehicle vehicle)
        {
            if (!ModelState.IsValid) { return Page(); }

            if (Vehicle != null)
            {
                using (var httpClient = new HttpClient())
                {
                    var json = JsonConvert.SerializeObject(vehicle);
                    var stringContent = new StringContent(json, UnicodeEncoding.UTF8, StrHelper.Mediatype);
                    using (var response = await httpClient.PostAsync(StrHelper.EndPointBaseUrl, stringContent))
                    {
                        await response.Content.ReadAsStringAsync();
                        if (response.IsSuccessStatusCode)
                        {
                            return RedirectToPage(StrHelper.RedirectToHomePage);
                        }
                        return BadRequest();
                    }
                }
            }
            return Page();
        }
    }

}
