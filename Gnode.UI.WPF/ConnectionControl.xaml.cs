using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Gnode.UI.WPF
{
    public partial class ConnectionControl : UserControl
    {
        public ConnectionControl()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty IDProperty = DependencyProperty.Register(
            "ID", typeof(Guid), typeof(ConnectionControl), new PropertyMetadata(Guid.NewGuid()));
        public static readonly DependencyProperty SelectedProperty = DependencyProperty.Register(
    "Selected", typeof(bool), typeof(ConnectionControl), new PropertyMetadata(false));

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

        public static readonly DependencyProperty SourcePortProperty = DependencyProperty.Register(
            "SourcePort", typeof(PortControl), typeof(ConnectionControl), new PropertyMetadata(null));

        public PortControl SourcePort
        {
            get { return (PortControl)GetValue(SourcePortProperty); }
            set { SetValue(SourcePortProperty, value); }
        }

        public static readonly DependencyProperty TargetPortProperty = DependencyProperty.Register(
            "TargetPort", typeof(PortControl), typeof(ConnectionControl), new PropertyMetadata(null));

        public PortControl TargetPort
        {
            get { return (PortControl)GetValue(TargetPortProperty); }
            set { SetValue(TargetPortProperty, value); }
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
        // Add more properties and methods for the ConnectionControl here
    }
}
