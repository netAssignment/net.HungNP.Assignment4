using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookStore_NETMVC.DAL
{
    public class Category
    {
        [Key]
        [Display(Name = "Category ID")]
        public int? iCategoryID { get; set; }

        [Required]
        [Display(Name = "Category name")]
        public string strCategoryName { get; set; }

        public Category()
        {
            ListBooks = new HashSet<Book>();
        }

        public virtual ICollection<Book> ListBooks { get; set; }
    }
}