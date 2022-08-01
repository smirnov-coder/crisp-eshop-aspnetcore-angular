using Core.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Cqrs
{
    public abstract class QueryHandlerBase<TQuery, TResult> where TQuery : IQuery
    {
        public abstract Task<Result<TResult>> HandleAsync(TQuery query);
    }
}
