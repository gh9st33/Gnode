using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gnode.Interfaces
{
    public interface IConnection
    {
        Guid ID { get; }
        IPort SourcePort { get; }
        IPort TargetPort { get; }
    }

}
