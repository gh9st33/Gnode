using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace Gnode.UI.WPF
{
    public partial class GraphControl : UserControl
    {
        public ObservableCollection<NodeControl> Nodes { get; }
        public ObservableCollection<ConnectionControl> Connections { get; }

        public GraphControl()
        {
            InitializeComponent();
            Nodes = new ObservableCollection<NodeControl>();
            Connections = new ObservableCollection<ConnectionControl>();
        }

        public void AddNode(NodeControl node)
        {
            Nodes.Add(node);
            Canvas.SetLeft(node, 0);
            Canvas.SetTop(node, 0);
            canvas.Children.Add(node);
        }

        public void DeleteNode(NodeControl node)
        {
            Nodes.Remove(node);
            canvas.Children.Remove(node);
        }

        public void AddConnection(ConnectionControl connection)
        {
            Connections.Add(connection);
            canvas.Children.Add(connection);
        }

        public void RemoveConnection(ConnectionControl connection)
        {
            Connections.Remove(connection);
            ((Canvas)Content).Children.Remove(connection);
        }
    }
}
