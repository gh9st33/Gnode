using Gnode.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gnode.Interfaces
{
    public interface INode
    {
        Guid ID { get; }
        List<IPort> InputPorts { get; }
        List<IPort> OutputPorts { get; }

        void AddInputPort<T>(Core.Execution.Port<T> port);
        void AddOutputPort<T>(Core.Execution.Port<T> port);
        void Execute();
    }

}
