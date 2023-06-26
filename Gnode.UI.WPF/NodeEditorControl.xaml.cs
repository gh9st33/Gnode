using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Gnode.UI.WPF
{
    public partial class NodeEditorControl : UserControl
    {
        private NodeControl selectedNode;
        private PortControl selectedPort;

        public NodeEditorControl()
        {
            InitializeComponent();
        }

        private void CreateNode_Click(object sender, RoutedEventArgs e)
        {
            var node = new NodeControl
            {
                Name = "New Node",
                // Set other properties of the node here
            };
            node.MouseLeftButtonDown += (s, e) => selectedNode = (NodeControl)s;
            graphControl.AddNode(node);
        }

        private void DeleteNode_Click(object sender, RoutedEventArgs e)
        {
            if (selectedNode != null)
            {
                graphControl.RemoveNode(selectedNode);
                selectedNode = null;
            }
        }

        private void CreateConnection_Click(object sender, RoutedEventArgs e)
        {
            if (selectedPort != null)
            {
                var connection = new ConnectionControl
                {
                    SourcePort = selectedPort,
                    // Set other properties of the connection here
                };
                graphControl.AddConnection(connection);
                selectedPort = null;
            }
        }

        private void DeleteConnection_Click(object sender, RoutedEventArgs e)
        {
            if (selectedPort != null)
            {
                var connection = graphControl.Connections.FirstOrDefault(c => c.SourcePort == selectedPort || c.TargetPort == selectedPort);
                if (connection != null)
                {
                    graphControl.RemoveConnection(connection);
                }
                selectedPort = null;
            }
        }

        // Add more properties and methods for the NodeEditorControl here
    }
}
