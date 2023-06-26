using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Gnode.UI.WPF
{
    public partial class NodeControl : UserControl
    {
        public static readonly DependencyProperty IDProperty = DependencyProperty.Register(
            "ID", typeof(Guid), typeof(NodeControl), new PropertyMetadata(Guid.NewGuid()));

        public static readonly DependencyProperty NameProperty = DependencyProperty.Register(
            "Name", typeof(string), typeof(NodeControl), new PropertyMetadata(string.Empty));

        public static readonly DependencyProperty SelectedProperty = DependencyProperty.Register("Selected", typeof(bool), 
            typeof(NodeControl), new PropertyMetadata(false));

        public bool Selected
        {
            get { return (bool)GetValue(SelectedProperty); }
            set { SetValue(SelectedProperty, value); }
        }

        public Guid ID
        {
            get { return (Guid)GetValue(IDProperty); }
            set { SetValue(IDProperty, value); }
        }

        public string Name
        {
            get { return (string)GetValue(NameProperty); }
            set { SetValue(NameProperty, value); }
        }

        public ObservableCollection<PortControl> Ports { get; }

        public NodeControl()
        {
            InitializeComponent();
            Ports = new ObservableCollection<PortControl>();
        }

        public void AddPort(PortControl port)
        {
            Ports.Add(port);
        }

        public void RemovePort(PortControl port)
        {
            Ports.Remove(port);
        }
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            Selected = true;
        }

        protected override void OnMouseRightButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseRightButtonDown(e);
            Selected = false;
        }
        // Add more properties and methods for the NodeControl here
    }
}
