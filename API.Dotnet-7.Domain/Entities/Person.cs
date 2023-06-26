﻿using API.Dotnet_7.Domain.Validations;

namespace API.Dotnet_7.Domain.Entities
{
	public sealed class Person
	{
		public Person(string name, string document, string phone)
		{
			Validation(name, document, phone);
		}

		public Person(int id, string name, string document, string phone)
		{
			DomainValidationException.When(id < 0, "id must be greater than zero");
			Id = id;
			Validation(name, document, phone);

		}

		public int Id { get; private set; }
		public string Name { get; private set; }
		public string Document { get; private set; }
		public string Phone { get; private set; }


		private void Validation(string document, string name, string phone)
		{
			DomainValidationException.When(string.IsNullOrEmpty(name), "Name must be informed");
			DomainValidationException.When(string.IsNullOrEmpty(document), "Document must be informed");
			DomainValidationException.When(string.IsNullOrEmpty(phone), "Phone must be informed");

			Name = name;
			Document = document;
			Phone = phone;

		}
	}
}