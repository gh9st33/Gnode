using Gnode.Core.Execution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gnode.Interfaces
{
    public interface IPort
    {
        string ID { get; }
        Node ParentNode { get; }
        List<IConnection> Connections { get; }
        Type DataType { get; }

        void Connect(IConnection connection);
        void Disconnect(IConnection connection);
        T GetData<T>();
    }


}
