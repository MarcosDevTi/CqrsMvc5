using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CqrsMvc5.App.Cqrs.Command
{
    public interface ICommand
    {
        Guid Id { get; }
        DateTime Timestamp { get; }
    }
}
