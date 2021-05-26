//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//using Autodesk.Revit.ApplicationServices;
//using Autodesk.Revit.Attributes;
//using Autodesk.Revit.DB;
//using Autodesk.Revit.DB.Architecture;
//using Autodesk.Revit.Exceptions;
//using Autodesk.Revit.UI;
//using Autodesk.Revit.UI.Selection;


//namespace Sheets
//{
//    [Transaction(TransactionMode.Manual)]
//    public class CreateSheetBatch : IExternalCommand
//    {

//        public Result Execute(
//            ExternalCommandData commandData,
//            ref string message,
//            ElementSet elements)
//        {
//            //Get application and document objects
//            UIApplication myUiApplication = commandData.Application;
//            Document myDocument = myUiApplication.ActiveUIDocument.Document;

//            try
//            {
//                //Get an available title block from the document
//                //Set up the filter parameters for OST_TitleBlocks
//                FilteredElementCollector myCollector = new FilteredElementCollector(myDocument);
//                myCollector.OfClass(typeof(FamilySymbol));
//                myCollector.OfCategory(BuiltInCategory.OST_TitleBlocks);

//                //Return the first item in the filter
//                FamilySymbol myFamilySymbol = myCollector.FirstElement() as FamilySymbol;
//                if (myFamilySymbol != null)
//                {
//                    using (Transaction myTransaction = new Transaction(myDocument, "Create a new Viewsheet"))
//                    {
//                        myTransaction.Start();
//                        try
//                        {
//                            //create a sheet view
//                            ViewSheet myViewSheet = ViewSheet.Create(myDocument, myFamilySymbol.Id);
//                            //myViewSheet.Name = "a";
//                            //myViewSheet.SheetNumber = "1";

//                            //Pop-Up Message Window
//                            //TaskDialog.Show("Success", $"Successfully created new sheet! {myViewSheet.SheetNumber}, {myViewSheet.Name}");
                            
//                            if (null == myViewSheet)
//                            {
//                                throw new Exception("Failed to create new ViewSheet.");
//                            }
//                            myTransaction.Commit();
//                        }
//                        catch
//                        {
//                            myTransaction.RollBack();
//                        }
//                    }
//                }
//                else
//                {
//                    throw new Exception("No available Title Blocks!");
//                }

//                return Result.Succeeded;
//            }

//            //Catch Potential errors
//            catch (Autodesk.Revit.Exceptions.OperationCanceledException)
//            {
//                // If user decides to cancel operation
//                return Result.Cancelled;
//            }

//            catch (Exception myException)
//            {
//                // If something goes wrong
//                message = myException.Message;
//                return Result.Failed;
//            }

//        }

//    }

//}

