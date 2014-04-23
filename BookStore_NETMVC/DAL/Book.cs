using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookStore_NETMVC.DAL
{
    public class Book
    {
        [Key]
        [Display(Name = "Book ID")]
        public int iBookID { get; set; }

        [Required]
        [MaxLength(200)]
        [Display(Name = "Book name")]
        public string strBookName { get; set; }

        [MaxLength(100)]
        [Display(Name = "Author")]
        public string strAuthor { get; set; }

        [Display(Name = "Book content")]
        public string strBookContent { get; set; }

        public int? iCategoryID { get; set; }

        [Display(Name = "Category")]
        public virtual Category Category { get; set; }

        [Display(Name = "Image path")]
        public string strImagePath { get; set; }

        [Display(Name = "Price")]
        public int iPrice { get; set; }

    }
}