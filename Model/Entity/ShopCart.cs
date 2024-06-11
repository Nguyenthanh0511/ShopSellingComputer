using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entity
{
    public class ShopCart
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int productid { get; set; }
        public int quantiy {  get; set; }
        public decimal total {  get; set; }
        public User User { get; set; }
        public Product Products { get; set; }
    }
}