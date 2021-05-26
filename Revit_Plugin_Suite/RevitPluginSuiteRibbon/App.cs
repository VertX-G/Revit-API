using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System.Windows.Media.Imaging;

namespace RevitPluginSuiteRibbon
{
    public class App : IExternalApplication
    {
        // Define a method that will create our tab and button
        static void AddRibbonPanel(UIControlledApplication myApplication)
        {
            //Get dll assembly path
            string thisAssemblyPath = Assembly.GetExecutingAssembly().Location;

            
            //Create a custom ribbon tab
            String tabName = "Revit Plug-In Suite";
            myApplication.CreateRibbonTab(tabName);

            
            //Add a new ribbon panel "Sheets"
            String panelName = "Sheets";
            RibbonPanel rpSheets = myApplication.CreateRibbonPanel(tabName, panelName);

            //Create push button for "Sheet Batch"
            PushButtonData pbdSheetBatch = new PushButtonData(
                "CreateSheetBatch",
                "Create" + System.Environment.NewLine + "Sheets",
                thisAssemblyPath,
                "Sheets.CreateSheetBatch");

            PushButton pbSheetBatch = rpSheets.AddItem(pbdSheetBatch) as PushButton;
            pbSheetBatch.ToolTip = "Create a New Sheet Batch";
            BitmapImage SheetBatchIcon = new BitmapImage(
                new Uri("pack://application:,,,/RevitPluginSuiteRibbon;component/Resources/Plug-in.png"));
            pbSheetBatch.LargeImage = SheetBatchIcon;


            /*            //Create push button for "Test Sheet Batch 2"
                        PushButtonData pbdSheetBatch = new PushButtonData(
                            "CreateSheetBatch",
                            "Sheet" + System.Environment.NewLine + "Batch",
                            thisAssemblyPath,
                            "RevitPluginSuiteRibbon.Sheets.CreateSheetBatch2");

                        PushButton pbSheetBatch = rpSheets.AddItem(pbdSheetBatch) as PushButton;
                        pbSheetBatch.ToolTip = "Create a New Sheet Batch";
                        BitmapImage SheetBatchIcon = new BitmapImage(
                            new Uri("pack://application:,,,/RevitPluginSuiteRibbon;component/Resources/Plug-in.png"));
                        pbSheetBatch.LargeImage = SheetBatchIcon;
            */


            //Create push button for "Populate Sheets"
            PushButtonData pbdPopulateSheets = new PushButtonData(
            "PopulateSheets",
            "Populate" + System.Environment.NewLine + "Sheets",
            thisAssemblyPath,
            "Sheets.PopulateSheets");

            PushButton pbPopulateSheets = rpSheets.AddItem(pbdPopulateSheets) as PushButton;
            pbPopulateSheets.ToolTip = "Populate Sheets with Views";
            BitmapImage PopulateSheetsIcon = new BitmapImage(
                new Uri("pack://application:,,,/RevitPluginSuiteRibbon;component/Resources/Plug-in.png"));
            pbPopulateSheets.LargeImage = PopulateSheetsIcon;


            
            //Add a new ribbon panel "Revisions"
            panelName = "Revisions";
            RibbonPanel rpRevisions = myApplication.CreateRibbonPanel(tabName, panelName);

            //Create push button for "Manage Revisions"

            //string ManageRevisionsPath = typeof(Manage.ManageRevisionsForm /*Manage.ManageRevisions*/).FullName;

            PushButtonData pbdManageRevisions = new PushButtonData(
                "ManageRevisions",
                "Manage" + System.Environment.NewLine + "Revisions",
                thisAssemblyPath,
                "Manage.ManageRevisions");

            PushButton pbManageRevisions = rpRevisions.AddItem(pbdManageRevisions) as PushButton;
            pbManageRevisions.ToolTip = "Manage Revisions";
            BitmapImage ManageRevisionsIcon = new BitmapImage(
                new Uri("pack://application:,,,/RevitPluginSuiteRibbon;component/Resources/Plug-in.png"));
            pbManageRevisions.LargeImage = ManageRevisionsIcon;


        }

        public Result OnShutdown(UIControlledApplication application)
        {
            // Do nothing

            return Result.Succeeded;
        }

        public Result OnStartup(UIControlledApplication application)
        {
            // call our method that will load up our toolbar

            AddRibbonPanel(application);
            return Result.Succeeded;
        }
    }
}
