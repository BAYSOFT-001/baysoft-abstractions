using System;
using System.Linq.Expressions;

namespace BAYSOFT.Abstractions.EntityFrameworkCore.Extensions
{
    public class BulkDeleteOptions<T> : BulkOptions
    {
        public Expression<Func<T, T, bool>> DeleteOnCondition { get; set; }
    }
}