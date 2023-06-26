using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Gnode.UI.WPF
{
    public partial class NodeEditorControl : UserControl
    {
        private NodeControl selectedNode;
        private PortControl selectedPort;
        private Point lastMousePosition;

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
            node.MouseLeftButtonDown += Node_MouseLeftButtonDown;
            node.MouseMove += Node_MouseMove;
            node.MouseLeftButtonUp += Node_MouseLeftButtonUp;
            graphControl.AddNode(node);
        }

        private void Node_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            selectedNode = (NodeControl)sender;
            lastMousePosition = e.GetPosition(graphControl);
        }

        private void Node_MouseMove(object sender, MouseEventArgs e)
        {
            if (selectedNode != null && e.LeftButton == MouseButtonState.Pressed)
            {
                var currentPosition = e.GetPosition(graphControl);
                var offset = currentPosition - lastMousePosition;
                Canvas.SetLeft(selectedNode, Canvas.GetLeft(selectedNode) + offset.X);
                Canvas.SetTop(selectedNode, Canvas.GetTop(selectedNode) + offset.Y);
                lastMousePosition = currentPosition;
            }
        }

        private void Node_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            selectedNode = null;
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
