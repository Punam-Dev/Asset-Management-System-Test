using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asset_Management_System.API.Dtos
{
    public class AssetSummaryDto
    {
        public string Id { get; set; }
        public string CustomerName { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string Vendor { get; set; }
        public DateTime DeliveryDate { get; set; }
    }
}
