using ApplicationCore.Interfaces;
using System;
using System.Linq.Expressions; //Func
namespace ApplicationCore.Specifications
{
    public class Specification<T> : ISpecification<T>
    {
         public Specification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }

        public Expression<Func<T, bool>> Criteria { get; }

        public int PageSize { get; private set; }

        public int PageIndex { get; private set; }

        public bool IsPaginated { get; private set; }

        public void ApplyPaging(int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            IsPaginated = true;
        }
    }
}