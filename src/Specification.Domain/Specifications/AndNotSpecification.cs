using Specification.Domain.Interfaces;
namespace Specification.Domain.Specifications
{
    public class AndNotSpecification<T> : CompositeSpecification<T>
    {

        /*
         The And method itself is called from another specification, hence we take advantage of it and use the calling specification as one of the parameter in creating AndSpecification. 
        It also gives more readability then to have something like this.
         
         */
        private readonly ISpecification<T> _leftSpecification;
        private readonly ISpecification<T> _rightSpecification;

        public AndNotSpecification(ISpecification<T> left,
            ISpecification<T> right)
        {
            _leftSpecification = left;
            _rightSpecification = right;
        }

        public override bool IsSatisfiedBy(T candidate) =>
            (_leftSpecification.IsSatisfiedBy(candidate) &&
             _rightSpecification.IsSatisfiedBy(candidate)) != true;
    }
}