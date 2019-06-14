namespace ControlWorkSystem
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class BookContext : DbContext
    {
        public BookContext()
            : base("name=BookContext")
        {
        }

        public DbSet<Author> Authors { get; set; } 

    }
}