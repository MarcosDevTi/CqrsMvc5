using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CqrsMvc5.App.Cqrs;
using CqrsMvc5.App.Cqrs.Command;
using CqrsMvc5.App.Cqrs.Command.Handlers;
using CqrsMvc5.App.Cqrs.Query;
using CqrsMvc5.App.Cqrs.Query.Handlers;
using CqrsMvc5.Domain;
using CqrsMvc5.Infra.Data;
using SimpleInjector;

namespace CqrsMvc5.Infra.IoC
{
    public class CqrsMvc5Bootstrapper
    {
        public static Container MyContainer { get; set; }
        public static void Register(Container container)
        {
            // Lifestyle.Transient => Uma instancia para cada solicitacao;
            // Lifestyle.Singleton => Uma instancia unica para a classe;
            // Lifestyle.Scoped => Uma instancia unica para o request;
            MyContainer = container;
            // APP

            container.Register<ICustomerRespository, CustomerRepository>();
            container.Register(typeof(IRepository<>),typeof(Repository<>));

            container.RegisterSingleton<CqrsMvc5Context>();

            container.Register<IQueryProcessor, QueryProcessor>(Lifestyle.Transient);
            container.Register<ICommandProcessor, CommandProcessor>(Lifestyle.Transient);

            container.Register(typeof(IQueryHandler<,>), new[]
            {
                typeof(IQueryHandler<,>).Assembly,
                typeof(CustomerQueryHandler).Assembly,
            }, Lifestyle.Transient);

            container.Register(typeof(ICommandHandler<>), new[]
            {
                typeof(ICommandHandler<>).Assembly,
                typeof(CustomerCommandHandler).Assembly,
            }, Lifestyle.Transient);
        }
    }
}
