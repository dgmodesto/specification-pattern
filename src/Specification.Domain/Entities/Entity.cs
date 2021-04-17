using Specification.Domain.Specifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace Specification.Domain.Entities
{
    public abstract class Entity
    {
        protected CompositeSpecification<object> ValidSpecification = null;

        public bool IsValid()
        {
            return ValidSpecification?.IsSatisfiedBy(this) ?? true;
        }
    }
}
