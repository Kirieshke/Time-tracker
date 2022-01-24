using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Time_tracker.Models;

namespace Time_tracker.Contexts
{
    class TodoDbContext: DbContext
    {
        public DbSet<Todo> Todoes { get; set; }
        public TodoDbContext() : base("db_todoes")
        {

        }
    }
}
