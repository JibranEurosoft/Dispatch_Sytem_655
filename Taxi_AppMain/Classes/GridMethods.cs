using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telerik.WinControls.UI;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.Data;

namespace Taxi_AppMain
{
   public class GridMethods
    {
    


     




      


       public static void SetFilter(RadGridView grid,FilterOperator op= FilterOperator.Contains,string exceptColumnName="")
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
                               ApplyFilter(grid, column,op, exceptColumnName);
                               break;

                                

                            //case "GridViewDecimalColumn":
                            //    ApplyFilter(grid, column,  FilterOperator.IsEqualTo);
                            //    break;
                        }
                   }
               }
           }
           catch
           {


           }
       }


       private static void ApplyFilter(RadGridView grid, GridViewColumn column,FilterOperator op, string exceptColumnName = "")
        {

        


           FilterDescriptor descriptor = new FilterDescriptor();
           descriptor.PropertyName = column.Name;

            //if (exceptColumnName == column.Name)
            //{
            //    descriptor.Operator = FilterOperator.IsEqualTo;

            //}
            //else
            //{

                descriptor.Operator = op;
        //    }
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
