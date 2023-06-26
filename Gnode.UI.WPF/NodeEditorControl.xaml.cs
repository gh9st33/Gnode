using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Gnode.UI.WPF
{
    public partial class NodeEditorControl : UserControl
    {
        private readonly List<NodeControl> selectedNodes = new List<NodeControl>();
        private NodeControl selectedNode;
        private PortControl selectedPort;
        private ConnectionControl selectedConnection;
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
            foreach (var port in node.Ports)
            {
                port.MouseLeftButtonDown += Port_MouseLeftButtonDown;
                port.MouseLeftButtonUp += Port_MouseLeftButtonUp;
            }
            graphControl.AddNode(node);
        }

        // Node event handlers...

        private void Port_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            selectedPort = (PortControl)sender;
            selectedConnection = new ConnectionControl
            {
                SourcePort = selectedPort,
                // Set other properties of the connection here
            };
            graphControl.AddConnection(selectedConnection);
        }

        private void Port_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (selectedConnection != null)
            {
                var port = (PortControl)sender;
                if (port != selectedPort && port.Node != selectedPort.Node && port.Direction != selectedPort.Direction)
                {
                    selectedConnection.TargetPort = port;
                }
                else
                {
                    graphControl.RemoveConnection(selectedConnection);
                }
                selectedConnection = null;
            }
            selectedPort = null;
        }

        private void Node_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var node = (NodeControl)sender;
            if ((Keyboard.Modifiers & ModifierKeys.Control) != 0)
            {
                if (selectedNodes.Contains(node))
                {
                    selectedNodes.Remove(node);
                }
                else
                {
                    selectedNodes.Add(node);
                }
            }
            else
            {
                selectedNodes.Clear();
                selectedNodes.Add(node);
            }
            lastMousePosition = e.GetPosition(graphControl);
        }

        private void Node_MouseMove(object sender, MouseEventArgs e)
        {
            if (selectedNodes.Count > 0 && e.LeftButton == MouseButtonState.Pressed)
            {
                var currentPosition = e.GetPosition(graphControl);
                var offset = currentPosition - lastMousePosition;
                foreach (var node in selectedNodes)
                {
                    Canvas.SetLeft(node, Canvas.GetLeft(node) + offset.X);
                    Canvas.SetTop(node, Canvas.GetTop(node) + offset.Y);
                }
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
