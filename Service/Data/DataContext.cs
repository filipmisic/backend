using System;
using Microsoft.EntityFrameworkCore;


namespace Service.Data
{
	public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Make> Makes => Set<Make>();
        public DbSet<Model> Models => Set<Model>();

    }
}

