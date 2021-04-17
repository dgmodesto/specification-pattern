using Specification.Domain.Specifications.Entities;
using Specification.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Specification.Domain.Entities
{
    public class Person : Entity
    {
        public const int NameMinLength = 2;
        public const int NameMaxLength = 50;

        public Person(Guid personId, string name, Email email, Category category)
        {
            PersonId = personId;
            Name = name;
            Email = email;
            Category = category;
            ValidSpecification = new PersonValidSpecification<object>();
        }

        public Guid PersonId { get; }
        public string Name { get; }
        public Email Email { get; }
        public Category Category { get; }
    }
}
