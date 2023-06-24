using Gnode.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gnode.Core.Execution
{
    public class Connection : IConnection
    {
        public Guid ID { get; private set; }
        public IPort SourcePort { get; private set; }
        public IPort TargetPort { get; private set; }

        public Connection(IPort source, IPort target)
        {
            ID = Guid.NewGuid();
            SourcePort = source;
            TargetPort = target;
        }
    }

}
