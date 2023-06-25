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
        string ID { get; }
        List<IPort> InputPorts { get; }
        List<IPort> OutputPorts { get; }

        void AddInputPort(IPort port);
        void AddOutputPort(IPort port);
        void Execute();
    }

}
