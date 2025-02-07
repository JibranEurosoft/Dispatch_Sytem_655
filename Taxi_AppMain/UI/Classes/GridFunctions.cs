using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telerik.WinControls.UI;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.Data;

namespace UI
{
   public class GridFunctions
    {
       public static void AddDeleteColumn(RadGridView grid)
       {
           GridViewCommandColumn col=new GridViewCommandColumn();
           col.BestFit();
          // col.Width = 40;
           col.Name="ColDelete";
           col.UseDefaultText = true;
           col.ImageLayout = System.Windows.Forms.ImageLayout.Center;
           col.DefaultText = "Delete";
           col.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
      
           grid.Columns.Add(col);

           grid.CommandCellClick += new CommandCellClickEventHandler(grid_CommandCellClick);


           grid.NewRowEnterKeyMode = RadGridViewNewRowEnterKeyMode.EnterMovesToNextRow;
       
       }


       public static void AddDeleteColumnBestWidth(RadGridView grid)
       {
           GridViewCommandColumn col = new GridViewCommandColumn();

           col.Width = 70;
           col.Name = "ColDelete";
           col.UseDefaultText = true;
           col.ImageLayout = System.Windows.Forms.ImageLayout.Center;
           col.DefaultText = "Delete";
           col.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;

           grid.Columns.Add(col);

           grid.CommandCellClick += new CommandCellClickEventHandler(grid_CommandCellClick);


           grid.NewRowEnterKeyMode = RadGridViewNewRowEnterKeyMode.EnterMovesToNextRow;

       }




       static void grid_CommandCellClick(object sender, EventArgs e)
       {


           if (DialogResult.Yes == RadMessageBox.Show("Are you sure you want to delete a record ? ", "", MessageBoxButtons.YesNo, RadMessageIcon.Question))
           {

               GridCommandCellElement gridCell = (GridCommandCellElement)sender;
               RadGridView grid = gridCell.GridControl;
               grid.CurrentRow.Delete();
           }
       }



       public static void SetFilter(RadGridView grid)
       {
           try
           {
               grid.ShowGroupPanel = false;
               grid.MasterTemplate.AllowAddNewRow = false;
               grid.MasterTemplate.AllowEditRow = false;
               grid.MasterTemplate.AllowDeleteRow = false;

               if (grid.Columns.Count > 0)
               {

                   grid.EnableFiltering = true;
                   foreach (var column in grid.Columns.Where(c => c.IsVisible))
                   {


                       switch (column.GetType().Name)
                       {


                           case "GridViewCheckBoxColumn":
                               grid.Columns[column.Name].AllowFiltering = false;
                               break;


                           case "GridViewTextBoxColumn":
                               ApplyFilter(grid, column);
                               break;
                       }
                   }
               }
           }
           catch
           {


           }
       }


       private static void ApplyFilter(RadGridView grid, GridViewColumn column)
       {

           FilterDescriptor descriptor = new FilterDescriptor();
           descriptor.PropertyName = column.Name;
           descriptor.Operator = FilterOperator.StartsWith;
           descriptor.IsFilterEditor = true;

           grid.FilterDescriptors.Add(descriptor);

           //FilterExpression filter = new FilterExpression();
           //filter.Predicates.Add(FilterExpression.BinaryOperation.AND, GridKnownFunction.StartsWith, GridFilterCellElement.ParameterName);
           //filter.Parameters.Add(GridFilterCellElement.ParameterName, null);
           //grid.Columns[column.HeaderText].Filter = filter;
           //grid.Columns[column.HeaderText].AllowFiltering = true;


       }


    }
}
