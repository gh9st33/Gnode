using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace Gnode.UI.WPF
{
    public partial class GraphControl : UserControl
    {
        public GraphControl()
        {
            InitializeComponent();
            Nodes = new ObservableCollection<NodeControl>();
            Connections = new ObservableCollection<ConnectionControl>();
        }

        public ObservableCollection<NodeControl> Nodes { get; }
        public ObservableCollection<ConnectionControl> Connections { get; }

        public void AddNode(NodeControl node)
        {
            Nodes.Add(node);
            Canvas.SetLeft(node, 0);
            Canvas.SetTop(node, 0);
            ((Canvas)Content).Children.Add(node);
        }

        public void RemoveNode(NodeControl node)
        {
            Nodes.Remove(node);
            ((Canvas)Content).Children.Remove(node);
        }

        public void AddConnection(ConnectionControl connection)
        {
            Connections.Add(connection);
            ((Canvas)Content).Children.Add(connection);
        }

        public void RemoveConnection(ConnectionControl connection)
        {
            Connections.Remove(connection);
            ((Canvas)Content).Children.Remove(connection);
        }
    }
}
