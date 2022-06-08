using Microsoft.EntityFrameworkCore;
using System;

namespace ManyToManyEF
{
    public class FilesDbContext : DbContext
    {
        public DbSet<File> Files { get; set; }
        public DbSet<Folder> Folders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=ManyToManyEFFiles;Trusted_Connection=True;")
                ;//.LogTo(Console.WriteLine);
        }
    }
}
