using CrudUsing_EF.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CrudUsing_EF.Models
{
    public class ProductDbContext : DbContext
    {
        public DbSet<Category> categories { get; set; }
    }
}