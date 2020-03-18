using MediatR;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Mediador.Pipelines
{
    public class LoggerRequestsBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            Debug.WriteLine("Log  - Starts");
            var result= next();
            Debug.WriteLine("Log  - Ends");
            return result;
        }
    }
}
