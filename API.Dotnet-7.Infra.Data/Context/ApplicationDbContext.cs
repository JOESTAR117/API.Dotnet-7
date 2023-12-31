﻿using API.Dotnet_7.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Dotnet_7.Infra.Data.Context
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{ }

		public DbSet<Person> People { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<Purchase> Purchases { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
		}
	}
}
