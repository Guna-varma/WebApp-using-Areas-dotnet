using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.Model.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string ISBN { get; set; }

        [Required]
        [Display(Name ="List Price")]
        public double ListPrice { get; set; }

        [Required]
        [Display(Name ="Price from 1 to 50")]
        public double Price { get; set; }

        [Required]
        [Display(Name = "Price for 50+")]
        public double Price50 { get; set; }

        [Required]
        [Display(Name = "Price for 100+")]
        public double Price100 { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        [ValidateNever]
        public Category Category { get; set; }

        [Required]
        [ValidateNever]
        public string ImageURL { get; set; }
    }
}