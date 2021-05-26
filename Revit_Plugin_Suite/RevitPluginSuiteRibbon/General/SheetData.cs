using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Architecture;
using Autodesk.Revit.Exceptions;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;

namespace RevitPluginSuiteRibbon.Resources
{
    class SheetData
    {
        public bool IsPlaceholder { get; set; }
        public string Name { get; set; }
        public string SheetNumber { get; set; }

        //Constructor for SheetData Class
        public SheetData(ViewSheet v)
        {
            IsPlaceholder = v.IsPlaceholder;
            Name = v.Name;
            SheetNumber = v.SheetNumber;
        }

//        public void SheetsInDocument(Document doc)
//        {
//            //set up the filter parameters for OST_Sheets
//            //in order to get all the sheets in the document
//            FilteredElementCollector FECSheets = new FilteredElementCollector(doc);
//            FECSheets.OfClass(typeof(ViewSheet));
//            FECSheets.OfCategory(BuiltInCategory.OST_Sheets);
//
//            //set up a list and fill with filtered sheets
//            List<SheetData> data = new List<SheetData>();
//
//            //populate the list with the sheet data
//            foreach (ViewSheet v in FECSheets)
//            {
//                SheetData item = new SheetData(v);
//                data.Add(item);
//            }
//        }
    }
}
