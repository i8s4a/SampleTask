using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.Contexts
{
	public class SampleTaskContext:DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(
				@"Server=(localdb)\MSSQLLocalDB; Database=SampleTaskdb; Trusted_Connection=true");
		}

		public DbSet<Product> Products { get; set; }
	}
}
