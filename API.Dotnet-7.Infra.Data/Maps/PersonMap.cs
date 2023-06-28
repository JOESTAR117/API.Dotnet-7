using API.Dotnet_7.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Dotnet_7.Infra.Data.Maps
{
	public class PersonMap : IEntityTypeConfiguration<Person>
	{
		public void Configure(EntityTypeBuilder<Person> builder)
		{
			builder.ToTable("Pessoa");

			builder.HasKey(x => x.Id);

			builder.Property(x => x.Id)
				.HasColumnName("Idpessoa")
				.UseIdentityColumn();

			builder.Property(x => x.Document)
				.HasColumnName("Documento");

			builder.Property(x => x.Name)
				.HasColumnName("Nome");

			builder.Property(x => x.Phone)
				.HasColumnName("Celular");

			builder.HasMany(x => x.Purchases)
				.WithOne(p => p.Person)
				.HasForeignKey(x => x.PersonId);
		}
	}
}
