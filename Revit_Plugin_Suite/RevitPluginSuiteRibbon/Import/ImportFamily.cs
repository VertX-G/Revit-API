/*          Comments

*/
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

namespace RevitPluginSuiteRibbon.Import
{
    class ImportFamily
    {
        //declare variables for the load family dialog
        OpenFileDialog ofd = new OpenFileDialog();
        public string[] FileName;
        public string InitialDirectory;
        public void ImportFamilyDialog(Document document, UIApplication uIApplication)
        {
            //set some parameters of the open dialog form
            ofd.Title = "Load Families";
            ofd.Filter = "All Supported Files|*.rfa;*.adsk";
            ofd.InitialDirectory = InitialDirectory;
            ofd.Multiselect = true;

            //get the initial directory
            var x = uIApplication.Application.GetLibraryPaths();
            uIApplication.Application.GetLibraryPaths().TryGetValue("Metric Library", out InitialDirectory);
            if (String.IsNullOrEmpty(InitialDirectory))
            {
                InitialDirectory = "c:\\";
            }

            //when the 'open' button is clicked...
            if (ofd.ShowDialog() == DialogResult.OK)
            {

                //write the filenames to string
                FileName = ofd.FileNames;

                //write the filenames to a message
                foreach (string s in FileName)
                {
                    using (Transaction myTransaction = new Transaction(document, "Import Family"))
                    {
                        //start the transaction
                        myTransaction.Start();
                        try
                        {

                            //messagetext += $"Filepath = {s}" + Environment.NewLine + Environment.NewLine;

                            Family family = null;
                            if (!document.LoadFamily(s, out family))
                            {
                                TaskDialog.Show("Revit", $"Can't load the family file {new System.IO.FileInfo(s).Name}");
                            }
                            
                            //commit to the transaction
                            myTransaction.Commit();
                        }
                        //catch any errors
                        catch (Exception ex)
                        {
                            //show the error
                            TaskDialog.Show("Error", ex.Message);

                            //rollback the changes made during the transaction
                            myTransaction.RollBack();
                        }
                    }


                }
                //MessageBox.Show(messagetext);
            }
        }
    }
}
