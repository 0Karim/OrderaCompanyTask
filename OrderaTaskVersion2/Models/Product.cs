using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace OrderaTaskVersion2.Models
{
    public class Product
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name ="Product Name")]
        public string ProductName { get; set; }

        [Required]
        [RegularExpression("^[1-9]\\d*$" , ErrorMessage ="The number should be positive number")]
        [Display(Name = "Number In Stock")]
        public int NumberInStock { get; set; }

        [Required]
        [Display(Name ="Description")]
        public string ProductDescription { get; set; }


        //One To Many Relationship Full Defined
        [Display(Name = "Category Name")]
        [Required]
        public int CategoryID { get; set; }
        public virtual ProductCategories Category { get; set;}
    }
}