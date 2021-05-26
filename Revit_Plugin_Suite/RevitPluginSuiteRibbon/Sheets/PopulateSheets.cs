using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Architecture;
using Autodesk.Revit.Exceptions;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;

namespace Sheets
{
    [Transaction(TransactionMode.Manual)]
    class PopulateSheets : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            try
            {
                //Pop-Up Message Window
                TaskDialog.Show($"{this.GetType().Name}", $"This Button is for the {this.GetType().Name} Function");

                return Result.Succeeded;
            }


            //Catch Potential errors

            // If user decides to cancel operation
            catch (Autodesk.Revit.Exceptions.OperationCanceledException)
            {
                return Result.Cancelled;
            }

            // If something goes wrong
            catch (Exception myException)
            {
                message = myException.Message;
                return Result.Failed;
            }
        }
    }
}
