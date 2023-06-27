using API.Dotnet_7.Domain.Validations;

namespace API.Dotnet_7.Domain.Entities
{
	public sealed class Product
	{
		public Product(string name, string codeErp, decimal price)
		{
			Validation(name, codeErp, price);
		}

		public Product(int id, string name, string codeErp, decimal price)
		{
			DomainValidationException.When(id < 0, "the id must be informed");
			Id = id;
			Validation(name, codeErp, price);
		}

		public int Id { get; private set; }
		public string Name { get; private set; }
		public string CodeErp { get; private set; }
		public decimal Price { get; private set; }
		public ICollection<Purchase> Purchases { get; set; }

		private void Validation(string name, string codeErp, decimal price)
		{
			DomainValidationException.When(string.IsNullOrEmpty(name), "Name must be informed");
			DomainValidationException.When(string.IsNullOrEmpty(codeErp), "CodeErp must be informed");
			DomainValidationException.When(price < 0, "price must be greater than zero");

			Name = name;
			CodeErp = codeErp;
			Price = price;
		}

	}
}
