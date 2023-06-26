using System;
using System.Windows;
using System.Windows.Controls;

namespace Gnode.UI.WPF
{
    public enum PortDirection
    {
        Input,
        Output
    }

    public partial class PortControl : UserControl
    {
        public static readonly DependencyProperty IDProperty = DependencyProperty.Register(
            "ID", typeof(Guid), typeof(PortControl), new PropertyMetadata(Guid.NewGuid()));

        public static readonly DependencyProperty NameProperty = DependencyProperty.Register(
            "Name", typeof(string), typeof(PortControl), new PropertyMetadata(string.Empty));

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

        public NodeControl Node { get; set; }

        public PortDirection Direction { get; set; }

        public PortControl()
        {
            InitializeComponent();
        }

        // Add more properties and methods for the PortControl here
    }
}
