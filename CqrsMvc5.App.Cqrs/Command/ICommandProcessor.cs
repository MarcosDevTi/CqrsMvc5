using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CqrsMvc5.App.Cqrs.Command
{
    public interface ICommandProcessor
    {
        void Send<TCommand>(TCommand command) where TCommand : ICommand;
    }
}
