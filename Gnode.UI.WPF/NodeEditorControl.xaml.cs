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
                // Set properties of the node here based on the values in the PropertiesPanel
                Name = PropertiesPanel.NodeName,
                Position = PropertiesPanel.NodePosition,
                // ... set other properties as needed
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
            UpdatePropertiesPanel();
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
            UpdatePropertiesPanel();
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
            UpdatePropertiesPanel();
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
            UpdatePropertiesPanel();
        }

        private void DeleteNode_Click(object sender, RoutedEventArgs e)
        {
            foreach (var node in selectedNodes.ToList())
            {
                foreach (var port in node.Ports)
                {
                    var connections = graphControl.Connections.Where(c => c.SourcePort == port || c.TargetPort == port).ToList();
                    foreach (var connection in connections)
                    {
                        graphControl.Connections.Remove(connection);
                    }
                }
                graphControl.Nodes.Remove(node);
            }
            selectedNodes.Clear();
        }

        private void DeleteConnection_Click(object sender, RoutedEventArgs e)
        {
            if (selectedConnection != null)
            {
                graphControl.Connections.Remove(selectedConnection);
                selectedConnection = null;
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
        private void UpdatePropertiesPanel()
        {
            if (selectedNodes.Count == 1)
            {
                propertiesPanel.DataContext = selectedNodes.First();
            }
            else if (selectedConnection != null)
            {
                propertiesPanel.DataContext = selectedConnection;
            }
            else
            {
                propertiesPanel.DataContext = null;
            }
        }

        // Add more properties and methods for the NodeEditorControl here
    }
}
