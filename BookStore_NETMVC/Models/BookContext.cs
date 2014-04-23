using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using BookStore_NETMVC.DAL;

namespace BookStore_NETMVC.Models
{
    public class BookContext : DbContext
    {
        public BookContext() : base("DefaultConnection") { }
        public DbSet<Book> Book { get; set; }
        public DbSet<Category> Category { get; set; }
    }
}