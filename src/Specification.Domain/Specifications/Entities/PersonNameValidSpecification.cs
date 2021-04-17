using Specification.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Specification.Domain.Specifications.Entities
{
    public class PersonNameValidSpecification<T> : CompositeSpecification<T>
    {
        private readonly bool _required;

        public PersonNameValidSpecification(bool required = false)
        {
            _required = required;
        }

        public override bool IsSatisfiedBy(T candidate)
        {
            var person = candidate as Person;

            if (string.IsNullOrEmpty(person?.Name) && !_required)
                return true;

            if ((person?.Name ?? "").Length < Person.NameMinLength)
                return false;

            if ((person?.Name ?? "").Length > Person.NameMaxLength)
                return false;

            return true;
        }
    }
}
