using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace LEditor.Utils
{
    public static class DataGridHelper
    {
        public static void MouseMove(MouseEventArgs e)
        {
            if (e.Source is DataGrid dataGrid)
            {
                HitTestResult hitTestResult = VisualTreeHelper.HitTest(dataGrid, e.GetPosition(dataGrid));
                DataGridCell dataGridCell = hitTestResult?.VisualHit.GetParentOfType<DataGridCell>();

                if (dataGridCell != null)
                {
                    dataGridCell.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
                    dataGridCell.IsEditing = true;
                }
            }
        }
    }
}
