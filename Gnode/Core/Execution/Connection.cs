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
        public String ID { get; private set; }
        public IPort SourcePort { get; private set; }
        public IPort TargetPort { get; private set; }

        public Connection(IPort source, IPort target)
        {
            ID = Guid.NewGuid().ToString();
            SourcePort = source;
            TargetPort = target;
        }
    }

}
