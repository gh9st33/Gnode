
using Gnode.Core.Variables;
using Gnode.Interfaces;

namespace Gnode.Core.Execution
{
    public abstract class Node : INode
    {
        public Guid ID { get; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public List<IPort> InputPorts { get; } = new List<IPort>();
        public List<IPort> OutputPorts { get; } = new List<IPort>();

        public abstract void Execute();


        public void AddInputPort<T>(Port<T> port)
        {
            InputPorts.Add(port);
        }

        public void AddOutputPort<T>(Port<T> port)
        {
            OutputPorts.Add(port);
        }
    }

}