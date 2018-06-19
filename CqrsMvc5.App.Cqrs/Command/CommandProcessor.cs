using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleInjector;
using SimpleInjector.Lifestyles;

namespace CqrsMvc5.App.Cqrs.Command
{
    public class CommandProcessor : ICommandProcessor
    {
        private readonly Container _container;

        public CommandProcessor(Container container)
        {
            _container = container;
        }

        public void Send<TCommand>(TCommand command) where TCommand : ICommand
        {
            using (AsyncScopedLifestyle.BeginScope(_container))
            {
                var handlerType = typeof(ICommandHandler<>).MakeGenericType(command.GetType());

                dynamic handler = _container.GetInstance(handlerType);
                handler.Handle((dynamic)command);
            }
        }
    }
}
