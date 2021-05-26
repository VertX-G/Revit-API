/*          Comments

Clean up code a little
maybe make sheetnumbercheck and sheetnumber increment external classes

Do unknown exception and potential bug checks wrt user input or returned results or nulls



*/
#region Namespaces
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
using TaskDialog = Autodesk.Revit.UI.TaskDialog;
using RevisionData = RevitPluginSuiteRibbon.General.RevisionData;
#endregion

namespace RevitPluginSuiteRibbon.Manage
{
    [Transaction(TransactionMode.Manual)]
    public partial class ManageRevisionsForm : System.Windows.Forms.Form
    {
        //create variables
        public UIApplication UiApp;
        public Document Doc;
        public UIDocument UiDoc;

        public List<ViewSheet> SheetsInDoc;
        //public DataTable SheetsInDoc;
        public List<Revision> RevisionsInDoc;


        //Form Initializer
        public ManageRevisionsForm(ExternalCommandData commandData)
        {
            //get the application document and objects
            UiApp = commandData.Application;
            UiDoc = UiApp.ActiveUIDocument;
            Doc = UiDoc.Document;
            InitializeComponent();
        }

        //on form load
        private void ManageRevisionsForm_Load(object sender, EventArgs e)
        {
            //populate listboxes
            lstbxSheets_Populate();
            lstbxRevisions_Populate();

            txtbSheetFilter.Select();

            chklstbxSheets.DisplayMember = "Name";
            chklstbxSheets.ValueMember = "Id";
        }

        //loop to apply revisions to sheets when apply button is clicked
        private void btnApply_Click(object sender, EventArgs e)
        {
            using (Transaction myTransaction = new Transaction(Doc, "Add additional revisions to sheets"))
            {
                myTransaction.Start();
                try
                {
                    //for each checked item in the sheets checked list box
                    foreach (object CheckedSheet in chklstbxSheets.CheckedItems)
                    {
                        ViewSheet viewSheet = CheckedSheet as ViewSheet;
                        ICollection<ElementId> AdditionalRevisions = new List<ElementId>();

                        //for each checked item in the revisions checked list box
                        foreach (object CheckedRevision in chklstbxRevisions.CheckedItems)
                        {
                            //Add the revision.id to the revisions ICollection
                            AdditionalRevisions.Add((CheckedRevision as RevisionData).Id);
                        }

                        viewSheet.SetAdditionalRevisionIds(AdditionalRevisions);

                        //
                        /*
                        if (AdditionalRevisions.Count > 0)
                        {
                            viewSheet.SetAdditionalRevisionIds(AdditionalRevisions);
                        }

                        else
                        {
                        //  Message "would you like to remove all revisions from the selected sheets?
                            viewSheet.SetAdditionalRevisionIds(AdditionalRevisions);
                        }
                        */
                    }
                    myTransaction.Commit();
                }
                catch (Exception ex)
                {
                    //show the error
                    TaskDialog.Show("Error", ex.Message);

                    //rollback the changes made during the transaction
                    myTransaction.RollBack();
                }
            }
            Close();
        }

        //open Manage Revisions window when button is clicked
        private void btnManageRevisions_Click(object sender, EventArgs e)
        {
            //check postcommand method for built-in manage revisions revit command
            //ID_SETTINGS_REVISIONS

            using (Transaction myTransaction = new Transaction(Doc, "Add additional revisions to sheets"))
            {

                //start the transaction
                myTransaction.Start();
                try
                {
                    RevitCommandId id
                    = RevitCommandId.LookupPostableCommandId(
                    PostableCommand.SheetIssuesOrRevisions);

                    UiApp.PostCommand(id);

                    //commit to the transaction
                    myTransaction.Commit();
                    Close();
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

        //populate Sheets listbox
        private void lstbxSheets_Populate()
        {

            //Sheet number syntax = (series)(member) i.e. a100ba (a100-ba) or 4ab21 (4ab-21)

            //collect current sheet numbers
            //set up the filter parameters for OST_Sheets
            //in order to get all the sheets in the document
            FilteredElementCollector FECSheets = new FilteredElementCollector(Doc);
            //pass filter arguments
            FECSheets.OfClass(typeof(ViewSheet));
            FECSheets.OfCategory(BuiltInCategory.OST_Sheets);

            //set up a list and fill with filtered sheets
            SheetsInDoc = (FECSheets.ToElements().ToList()).Select(x => (ViewSheet)x).ToList();

            FilterSheets();
        }

        //populate Revisions listbox
        private void lstbxRevisions_Populate()
        {
            IList<ElementId> ids
            = Revision.GetAllRevisionIds(Doc);

            int n = ids.Count;

            List<RevisionData> revision_data
              = new List<RevisionData>(n);

            foreach (ElementId id in ids)
            {
                Revision r = Doc.GetElement(id) as Revision;

                revision_data.Add(new RevisionData(r));
            }

            //include display for data//

            chklstbxRevisions.DataSource = revision_data;
            chklstbxRevisions.DisplayMember = "RevisionNumber";
            chklstbxRevisions.ValueMember = "Id";
        }

        //cannot change "revisions" for the following sheets
        private void RevisionError()
        {
            MessageBox.Show("Could not change revisions for the following sheets");
        }

        //filter sheets
        private void FilterSheets()
        {
            chklstbxSheets.Items.Clear();

            if (txtbSheetFilter.Text == null || txtbSheetFilter.Text == "")
            {
                foreach (ViewSheet v in SheetsInDoc)
                {
                    chklstbxSheets.Items.Add(v);
                }
            }
            else
            {
                foreach (ViewSheet v in SheetsInDoc)
                {
                    if ((v.SheetNumber + " - " + v.Name).ToLower().Contains(txtbSheetFilter.Text.ToLower()))
                    {
                        chklstbxSheets.Items.Add(v);
                    }
                }
            }
        }

        private void txtbFilterSheets_TextChanged(object sender, EventArgs e)
        {
            //run filter with every keypress and arrange results to be descending
            FilterSheets();
        }

        //Set the display value for CheckedListBoxSheets to Sheetnumber + Sheetname
        private void chklstbxSheets_Format(object sender, ListControlConvertEventArgs e)
        {
            string SheetNumber = ((ViewSheet)e.ListItem).SheetNumber.ToString();
            string SheetName = ((ViewSheet)e.ListItem).Name.ToString();

            e.Value = $"{SheetNumber} - {SheetName}";
        }

        private void chklstbxRevisions_Format(object sender, ListControlConvertEventArgs e)
        {
            string SequenceNumber = ((RevisionData)e.ListItem).SequenceNumber.ToString();
            string RevisionNumber = ((RevisionData)e.ListItem).RevisionNumber.ToString();
            string Description = ((RevisionData)e.ListItem).Description.ToString();
            string RevisionDate = ((RevisionData)e.ListItem).RevisionDate.ToString();
         
            e.Value = $"({RevisionNumber} - {Description} - {RevisionDate}";
        }

        #region Textbox "Search" 'select on focus' function

        /*
        Add the following to the Form.Designer.cs

         this.TextBoxName.Enter += textBox_Enter;
         this.TextBoxName.MouseUp += textBox_MouseUp;
         this.TextBoxName.Leave += textBox_Leave;
        */
        bool _focused;

        void textBox_Enter(object sender, EventArgs e)
        {
            // Select all text only if the mouse isn't down.
            // This makes tabbing to the textbox give focus.
            if (MouseButtons == MouseButtons.None)
            {
                ((System.Windows.Forms.TextBox)sender).SelectAll();
                _focused = true;
            }
        }

        void textBox_Leave(object sender, EventArgs e)
        {
            _focused = false;
        }

        void textBox_MouseUp(object sender, MouseEventArgs e)
        {
            // Web browsers like Google Chrome select the text on mouse up.
            // They only do it if the textbox isn't already focused,
            // and if the user hasn't selected all text.
            if (!_focused)
            {
                if (((System.Windows.Forms.TextBox)sender).SelectionLength == 0)
                {
                    ((System.Windows.Forms.TextBox)sender).SelectAll();
                    _focused = true;
                }
            }
        }
        #endregion

    }
}
