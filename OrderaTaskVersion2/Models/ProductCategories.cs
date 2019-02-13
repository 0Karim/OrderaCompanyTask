using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace OrderaTaskVersion2.Models
{
    public class ProductCategories
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name ="Category Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name ="Description")]
        public string Description { get; set; }

        //One To Many Relationship Full Defined
        public ICollection<Product> Products { get; set; }


    }
}