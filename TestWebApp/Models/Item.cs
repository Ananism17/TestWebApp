using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TestWebApp.Models
{
    public class Item
    {
        [Key]
        public int ItemId { get; set; }

        [Required(ErrorMessage = "Name is required!")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Price is required!")]
        [Display(Name = "Price")]
        public double Price { get; set; }

        [Required(ErrorMessage = "Amount is required!")]
        [Display(Name = "Quantity")]
        public int Amount { get; set; }

        [Required(ErrorMessage = "Stock amount is required!")]
        [Display(Name = "Stock Amount")]
        public int Stock { get; set; }

        [Required(ErrorMessage = "Sell amount is required!")]
        [Display(Name = "Sell Amount")]
        public int Sell { get; set; }

        public string ItemImageURL { get; set; }

        [NotMapped]
        /*[Required(ErrorMessage = "Profile image is required!")]*/
        [Display(Name = "Upload Image of the Product")]
        public IFormFile ImageFile { get; set; }
    }
}
