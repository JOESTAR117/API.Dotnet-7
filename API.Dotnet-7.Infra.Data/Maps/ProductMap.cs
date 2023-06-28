using API.Dotnet_7.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Dotnet_7.Infra.Data.Maps
{
	public class ProductMap : IEntityTypeConfiguration<Product>
	{
		public void Configure(EntityTypeBuilder<Product> builder)
		{
			builder.ToTable("Produto");
			builder.HasKey(x => x.Id);

			builder.Property(x => x.Id)
				.HasColumnName("Idproduto")
				.UseIdentityColumn();

			builder.Property(x => x.CodErp)
				.HasColumnName("Coderp");

			builder.Property(x => x.Name)
				.HasColumnName("Nome");

			builder.Property(x => x.Price)
				.HasColumnName("Preco");

			builder.HasMany(x => x.Purchases)
						 .WithOne(p => p.Product)
						 .HasForeignKey(x => x.ProductId);
		}
	}
}
