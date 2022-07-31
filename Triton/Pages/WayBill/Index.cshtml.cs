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
using Triton.Pages.Helper;

namespace Triton.Pages.WayBill
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public IList<WayBill>? WayBills { get; set; }

        public async Task OnGetAsync()
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(StrHelper.EndPointBaseUrlWayBill))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    WayBills = JsonConvert.DeserializeObject<List<WayBill>>(apiResponse);
                }
            }
        }

        [BindProperty]
        public WayBill? WayBill { get; set; }

        public async Task<ActionResult> OnPostAsync(WayBill wayBill)
        {
            if (!ModelState.IsValid) { return Page(); }

            if (WayBill != null)
            {
                using (var httpClient = new HttpClient())
                {
                    var json = JsonConvert.SerializeObject(wayBill);
                    var stringContent = new StringContent(json, UnicodeEncoding.UTF8, StrHelper.Mediatype);
                    using (var response = await httpClient.PostAsync(StrHelper.EndPointBaseUrlWayBill, stringContent))
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
