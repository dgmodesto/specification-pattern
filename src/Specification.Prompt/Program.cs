using Specification.Domain.Entities;
using Specification.Domain.Interfaces;
using Specification.Domain.Specifications;
using Specification.Domain.Specifications.Entities;
using Specification.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Specification.Prompt
{
    class Program
    {
        static void Main(string[] args)
        {
            // Person list
            var people = new List<Person> {
                new Person(Guid.NewGuid(), "Douglas 1", new Email("douglas1@gmail.com"), new Category(2, "Partner")),
                new Person(Guid.NewGuid(), "Douglas 2", new Email("douglas2@gmail.com"), new Category(1, "Customer")),
                new Person(Guid.NewGuid(), "Douglas 3", new Email("douglas3@gmail.com"), new Category(2, "Partner")),
                new Person(Guid.NewGuid(), "Douglas 4", new Email("douglas4_gmail.com"), new Category(1, "Customer")),
                new Person(Guid.NewGuid(), "Douglas 5", new Email("douglas5@gmail.com"), new Category(1, "Customer")),
                new Person(Guid.NewGuid(), "Douglas 6", new Email("douglas6@gmail.com"), new Category(1, "Customer")),
                new Person(Guid.NewGuid(), "Douglas 7", new Email("douglas7@gmail.com"), null) };

            Console.WriteLine(":: ALL PEOPLE ::");

            foreach (var item in people)
            {
                Console.WriteLine(item.PersonId + " | " + item.Name + " | " + item?.Email?.Address + " | " + item.Category?.Description);
            }

            // Specifications usages

            Console.WriteLine("");
            Console.WriteLine(":: CUSTOMER ::");

            ISpecification<Person> personCustomersSpecification = new PersonCustomerSpecification<Person>();

            var customer = people.FindAll(x => personCustomersSpecification.IsSatisfiedBy(x));

            foreach (var item in customer)
            {
                Console.WriteLine(item.PersonId + " | " + item.Name + " | " + item.Email.Address + " | " + item.Category?.Description);
            }

            Console.WriteLine("");
            Console.WriteLine(":: PARTNER ::");

            ISpecification<Person> partnerSpecification = new ExpressionSpecification<Person>(x => x.Category?.CategoryId == 2);

            var partners = people.FindAll(x => partnerSpecification.IsSatisfiedBy(x));

            foreach (var item in partners)
            {
                Console.WriteLine(item.PersonId + " | " + item.Name + " | " + item.Email.Address + " | " + item.Category?.Description);
            }

            Console.WriteLine("");
            Console.WriteLine(":: WITHOUT CATEGORY ::");

            ISpecification<Person> nullSpecification = new ExpressionSpecification<Person>(x => x.Category == null);

            var nullCategory = people.FindAll(x => nullSpecification.IsSatisfiedBy(x));

            foreach (var item in nullCategory)
            {
                Console.WriteLine(item.PersonId + " | " + item.Name + " | " + item.Email.Address + " | " + item.Category?.Description);
            }

            Console.WriteLine("");
            Console.WriteLine(":: WITH AND WITHOUT CATEGORY ::");

            ISpecification<Person> customersSpecification = new ExpressionSpecification<Person>(x => x.Category?.CategoryId == 1);
            var allWithCategorySpecification = customersSpecification.Or(partnerSpecification);
            var includeNull = allWithCategorySpecification.Or(nullSpecification);

            var allAndNullCategory = people.FindAll(x => includeNull.IsSatisfiedBy(x));

            foreach (var item in allAndNullCategory)
            {
                Console.WriteLine(item.PersonId + " | " + item.Name + " | " + item.Email.Address + " | " + item.Category?.Description);
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("");
            Console.WriteLine(":: ALL VALID ::");

            ISpecification<Person> validSpecification = new PersonValidSpecification<Person>();

            var validPeople = people.Where(x => validSpecification.IsSatisfiedBy(x));

            foreach (var item in validPeople)
            {
                Console.WriteLine(item.PersonId + " | " + item.Name + " | " + item.Email.Address + " | " + item.Category?.Description);
            }

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("");
            Console.WriteLine(":: VALID CUSTOMERS ::");

            var validCustomers = people.Where(x => validSpecification.IsSatisfiedBy(x) && customersSpecification.IsSatisfiedBy(x));

            foreach (var item in validCustomers)
            {
                Console.WriteLine(item.PersonId + " | " + item.Name + " | " + item.Email.Address + " | " + item.Category?.Description);
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("");
            Console.WriteLine(":: VALID PARTNERS ::");

            var validPartners = people.Where(x => validSpecification.IsSatisfiedBy(x) && partnerSpecification.IsSatisfiedBy(x));

            foreach (var item in validPartners)
            {
                Console.WriteLine(item.PersonId + " | " + item.Name + " | " + item.Email.Address + " | " + item.Category?.Description);
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("");
            Console.WriteLine(":: INVALID ::");

            var invalidPeople = people.Where(x => !validSpecification.IsSatisfiedBy(x));

            foreach (var item in invalidPeople)
            {
                Console.WriteLine(item.PersonId + " | " + item.Name + " | " + item.Email.Address + " | " + item.Category?.Description);
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("");
            Console.WriteLine(":: ISVALID ::");

            var isvalidPeople = people.Where(x => x.IsValid());

            foreach (var item in isvalidPeople)
            {
                Console.WriteLine(item.PersonId + " | " + item.Name + " | " + item.Email.Address + " | " + item.Category?.Description);
            }

            Console.ReadKey();
        }
    }
}
