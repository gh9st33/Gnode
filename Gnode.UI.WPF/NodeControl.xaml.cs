using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace Gnode.UI.WPF
{
    public partial class NodeControl : UserControl
    {
        public NodeControl()
        {
            InitializeComponent();
            Ports = new ObservableCollection<PortControl>();
        }

        public static readonly DependencyProperty IDProperty = DependencyProperty.Register(
            "ID", typeof(Guid), typeof(NodeControl), new PropertyMetadata(Guid.NewGuid()));

        public Guid ID
        {
            get { return (Guid)GetValue(IDProperty); }
            set { SetValue(IDProperty, value); }
        }

        public static readonly DependencyProperty NameProperty = DependencyProperty.Register(
            "Name", typeof(string), typeof(NodeControl), new PropertyMetadata(string.Empty));

        public string Name
        {
            get { return (string)GetValue(NameProperty); }
            set { SetValue(NameProperty, value); }
        }

        public ObservableCollection<PortControl> Ports { get; }

        public void AddPort(PortControl port)
        {
            Ports.Add(port);
        }

        public void RemovePort(PortControl port)
        {
            Ports.Remove(port);
        }
    }
}
