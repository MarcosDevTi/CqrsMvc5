using System.Diagnostics;
using SimpleInjector;
using SimpleInjector.Lifestyles;

namespace CqrsMvc5.App.Cqrs.Query
{
    public class QueryProcessor : IQueryProcessor
    {
        private readonly Container _container;

        public QueryProcessor(Container container)
        {
            _container = container;
        }

        [DebuggerStepThrough]
        public TResult Process<TResult>(IQuery<TResult> query)
        {
            using (AsyncScopedLifestyle.BeginScope(_container))
            {
                var handlerType = typeof(IQueryHandler<,>).MakeGenericType(query.GetType(), typeof(TResult));

                dynamic handler = _container.GetInstance(handlerType);

                return handler.Handle((dynamic)query);
            }
        }
    }
}
