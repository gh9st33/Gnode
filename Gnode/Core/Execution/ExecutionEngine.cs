using Gnode.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gnode.Core.Execution
{
    public class ExecutionEngine
    {
        private Graph _graph;
        private List<INode> _executionOrder;
        private HashSet<INode> _visitedNodes;

        public ExecutionEngine(Graph graph)
        {
            _graph = graph;
            _executionOrder = new List<INode>();
            _visitedNodes = new HashSet<INode>();
        }

        public virtual void ExecuteGraph()
        {
            _executionOrder.Clear();
            _visitedNodes.Clear();

            try
            {
                // Sort nodes based on their dependencies
                var sortedNodes = _graph.Nodes
                    .OrderByDescending(node => node.InputPorts.Count(port => port.Connections.Any()))
                    .ToList();

                foreach (var node in sortedNodes)
                {
                    if (!_visitedNodes.Contains(node))
                    {
                        ComputeExecutionOrder(node);
                    }
                }

                foreach (var node in _executionOrder)
                {
                    node.Execute();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during execution: {ex.Message}");
            }
        }


        protected virtual void ComputeExecutionOrder(INode node)
        {
            if (_visitedNodes.Contains(node))
            {
                throw new InvalidOperationException("Cyclic dependency detected in graph.");
            }

            _visitedNodes.Add(node);

            foreach (var port in node.OutputPorts)
            {
                foreach (var connection in port.Connections)
                {
                    var targetNode = connection.TargetPort.ParentNode;
                    ComputeExecutionOrder(targetNode);
                }
            }

            _executionOrder.Add(node);
        }
    }

}
