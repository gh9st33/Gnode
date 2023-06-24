using Gnode.Core.Execution;
using Gnode.Core.Variables;
using Gnode.Interfaces;

namespace Gnode.Core.Execution
{
    public class Port<T> : IPort
    {
        public string ID { get; }
        public Node ParentNode { get; }
        public List<IConnection> Connections { get; }
        public Variable<T> Data;

        public Port(string id, Node parentNode)
        {
            ID = id;
            ParentNode = parentNode;
            Connections = new List<IConnection>();
            Data = new Variable<T>(default!);
        }

        public void Connect(IConnection connection)
        {
            Connections.Add(connection);
        }

        public void Disconnect(IConnection connection)
        {
            Connections.Remove(connection);
        }

        public TData GetData<TData>()
        {
            return (TData)(object)Data.Value;
        }
    }
}
