using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Gnode.UI.WPF
{
    public partial class PropertiesPanel : UserControl
    {
        public PropertiesPanel()
        {
            InitializeComponent();
        }

        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);

            if (e.Property == DataContextProperty)
            {
                UpdatePropertiesDataGrid();
            }
        }

        private void UpdatePropertiesDataGrid()
        {
            if (DataContext is NodeControl node)
            {
                propertiesDataGrid.ItemsSource = new List<NodeControl> { node };
            }
            else if (DataContext is ConnectionControl connection)
            {
                propertiesDataGrid.ItemsSource = new List<ConnectionControl> { connection };
            }
            else
            {
                propertiesDataGrid.ItemsSource = null;
            }
        }
    }

