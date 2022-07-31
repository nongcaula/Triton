using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Triton.Pages.Helper
{
    public static class StrHelper
    {
        public static string EndPointBaseUrl = "https://localhost:44358/Vehicles";
        public static string EndPoint = "https://localhost:44358/Vehicles/";
        public static string Mediatype = "application/json";
        public static string RedirectToHomePage = "./Index";

        public static string EndPointBaseUrlWayBill = "https://localhost:44358/api/WayBill";
        public static string EndPointWayBillext = "https://localhost:44358/api/WayBill/";
        public static string RedirectToWaybill = "/waybill/WayBillDetails";


        public static string EndPointBaseUrlParcels = "https://localhost:44358/Parcels";
        public static string EndPointParcelsext = "https://localhost:44358/Parcels/";

    }
}
