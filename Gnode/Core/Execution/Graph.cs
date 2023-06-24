using Gnode.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gnode.Core.Execution
{
    public class Graph
    {
        public List<INode> Nodes { get; private set; }
        public List<IConnection> Connections { get; private set; }

        public Graph()
        {
            Nodes = new List<INode>();
            Connections = new List<IConnection>();
        }

        public bool AddNode(INode node)
        {
            if (!Nodes.Contains(node))
            {
                Nodes.Add(node);
                return true;
            }

            return false;
        }

        public bool RemoveNode(INode node)
        {
            return Nodes.Remove(node);
        }

        public bool AddConnection(IConnection connection)
        {
            if (!Connections.Contains(connection))
            {
                Connections.Add(connection);
                return true;
            }

            return false;
        }

        public bool RemoveConnection(IConnection connection)
        {
            return Connections.Remove(connection);
        }

        // New methods
        public INode FindNode(Guid id)
        {
            return Nodes.FirstOrDefault(node => node.ID == id);
        }

        public IConnection FindConnection(Guid id)
        {
            return Connections.FirstOrDefault(connection => connection.ID == id);
        }

        public bool NodeExists(Guid id)
        {
            return Nodes.Any(node => node.ID == id);
        }

        public bool ConnectionExists(Guid id)
        {
            return Connections.Any(connection => connection.ID == id);
        }
    }
}
