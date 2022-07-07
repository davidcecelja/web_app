using System;
using MySql.Data.EntityFramework;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace web_app.Models
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class BazaDbContext : DbContext
    {
        public DbSet<Student> PopisStudenata { get; set; }
    }
}