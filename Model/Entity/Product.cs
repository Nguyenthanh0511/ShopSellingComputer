using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Model.Entity
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Range(0.01, 10000)]
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int? VendorId {  get; set; }
        public Vendor Vendor { get; set; }
        public List<Image> Images { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}