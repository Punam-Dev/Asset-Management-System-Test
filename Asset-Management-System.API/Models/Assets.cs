using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Asset_Management_System.API.Models
{
    public class Assets
    {
        [Key]
        public string Id { get; set; }

        [Required]
        public string CustomerName { get; set; }

        [Required]
        public string CompanyName { get; set; }

        [Required]
        public string Address1 { get; set; }

        public string Address2 { get; set; }

        [Required]
        public string VendorId { get; set; }

        [Required]
        public string HardwareId { get; set; }

        [Required]
        public DateTime DeliveryDate { get; set; }

        [Required]
        [Range(1,  int.MaxValue, ErrorMessage = "Quantity should be greater than zero")]
        public int Quantity { get; set; }

        [Required]
        [Range(double.Epsilon, double.MaxValue, ErrorMessage = "Price should be greater than zero")]
        public decimal Price { get; set; }

        [Required]
        public decimal TotalAmount { get; set; }
    }
}
