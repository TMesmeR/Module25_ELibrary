using Microsoft.EntityFrameworkCore;
using Module25_ELibrary.PreparForTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module25_ELibrary.AppContext
{
    internal class MyAppContext:DbContext
    {
        internal DbSet<Users> Users { get; set; }
        internal DbSet<Books> Books { get; set; }

        internal MyAppContext()
        {
           Database.EnsureDeleted();
           Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=.\SQLEXPRESS;Database=ELibraryDatabase;Trusted_connection=true;
        TrustServerCertificate=True;");
        }
    }
}
