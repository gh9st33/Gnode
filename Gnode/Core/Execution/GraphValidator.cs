using Gnode.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gnode.Core.Execution
{
    public class GraphValidator
    {
        private Graph _graph;
        private HashSet<INode> _visitedNodes;
        private HashSet<INode> _recursionStack;

        public GraphValidator(Graph graph)
        {
            _graph = graph;
            _visitedNodes = new HashSet<INode>();
            _recursionStack = new HashSet<INode>();
        }

        public bool Validate()
        {
            return NodesAreConnected() && NoCycles() && DataTypesMatch();
        }

        private bool NodesAreConnected()
        {
            // All nodes should have at least one connection
            return _graph.Nodes.All(node => node.InputPorts.Any(port => port.Connections.Any()) &&
                                            node.OutputPorts.Any(port => port.Connections.Any()));
        }

        private bool NoCycles()
        {
            foreach (var node in _graph.Nodes)
            {
                if (IsCyclic(node))
                {
                    return false;
                }
            }
            return true;
        }

        private bool IsCyclic(INode node)
        {
            if (!_visitedNodes.Contains(node))
            {
                _visitedNodes.Add(node);
                _recursionStack.Add(node);

                foreach (var port in node.OutputPorts)
                {
                    foreach (var connection in port.Connections)
                    {
                        var targetNode = connection.TargetPort.ParentNode;
                        if (!_visitedNodes.Contains(targetNode) && IsCyclic(targetNode))
                        {
                            return true;
                        }
                        else if (_recursionStack.Contains(targetNode))
                        {
                            return true;
                        }
                    }
                }
            }

            _recursionStack.Remove(node);
            return false;
        }

        private bool DataTypesMatch()
        {
            // The data types of connected ports should match
            return _graph.Connections.All(connection => connection.SourcePort.GetType() == connection.TargetPort.GetType());
        }
    }
}
