
using Gnode.Core.Variables;
using Gnode.Interfaces;

namespace Gnode.Core.Execution
{
    public abstract class Node : INode
    {
        public String ID { get; } = Guid.NewGuid().ToString();
        public string Name { get; set; } = string.Empty;
        public List<IPort> InputPorts { get; } = new List<IPort>();
        public List<IPort> OutputPorts { get; } = new List<IPort>();

        public abstract void Execute();


        public void AddInputPort(IPort port)
        {
            InputPorts.Add(port);
        }

        public void AddOutputPort(IPort port)
        {
            OutputPorts.Add(port);
        }
    }

}