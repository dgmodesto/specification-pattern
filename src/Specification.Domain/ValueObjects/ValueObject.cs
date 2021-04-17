using Specification.Domain.Specifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace Specification.Domain.ValueObjects
{
    public abstract class ValueObject
    {
        protected CompositeSpecification<object> ValidSpecification = null;

        public bool IsValid()
        {
            return ValidSpecification?.IsSatisfiedBy(this) ?? true;
        }
    }
}
