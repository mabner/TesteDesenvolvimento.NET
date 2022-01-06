using System;
using LocaFacil.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;


namespace LocaFacil
{
	public partial class LocaFacilContext : DbContext
	{
        private const string _ConnectionString = "server=localhost;user=root;password=admin;database=locafacil";

        public DbSet<UF> UF { get; set; }
		public DbSet<Endereco> Endereco { get; set; }
		public DbSet<TipoImovel> TipoImovel { get; set; }
		public DbSet<Telefone> Telefone { get; set; }
		public DbSet<Locatario> Locatario { get; set; }
		public DbSet<Proprietario> Proprietario { get; set; }
		public DbSet<Imovel> Imovel { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseMySql(_ConnectionString, Microsoft.EntityFrameworkCore.ServerVersion.AutoDetect(_ConnectionString));
			}
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.HasCharSet("latin1").UseCollation("latin1_swedish_ci");
			OnModelCreatingPartial(modelBuilder);
		}

		partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
	}
}
