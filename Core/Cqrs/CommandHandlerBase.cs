using Core.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Cqrs
{
    public abstract class CommandHandlerBase<T> where T : ICommand
    {
        public abstract Task<Result> HandleAsync(T command);
    }
}
