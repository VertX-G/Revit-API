/*          Comments

*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
    public class CreateSheetBatch : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            RevitPluginSuiteRibbon.CreateSheetBatchForm CSBF = new RevitPluginSuiteRibbon.CreateSheetBatchForm(commandData);

            var result = CSBF.ShowDialog();
            //if (result == DialogResult.OK)
            //{
            //
            //
            //}
            return Result.Succeeded;

        }
    }
}