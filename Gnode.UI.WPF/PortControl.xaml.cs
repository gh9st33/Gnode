using System;
using System.Windows;
using System.Windows.Controls;

namespace Gnode.UI.WPF
{
    public partial class PortControl : UserControl
    {
        public PortControl()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty IDProperty = DependencyProperty.Register(
            "ID", typeof(Guid), typeof(PortControl), new PropertyMetadata(Guid.NewGuid()));

        public Guid ID
        {
            get { return (Guid)GetValue(IDProperty); }
            set { SetValue(IDProperty, value); }
        }

        public static readonly DependencyProperty NameProperty = DependencyProperty.Register(
            "Name", typeof(string), typeof(PortControl), new PropertyMetadata(string.Empty));

        public string Name
        {
            get { return (string)GetValue(NameProperty); }
            set { SetValue(NameProperty, value); }
        }

        // Add more properties and methods for the PortControl here
    }
}
