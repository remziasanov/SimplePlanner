using Planner.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Planner.DataBaseManager
{
    public class DataBaseContext:DbContext
    {
        public DataBaseContext() : base("ConnectionString") { }
        public DbSet<TaskItem> Items { get; set; }
    }
}