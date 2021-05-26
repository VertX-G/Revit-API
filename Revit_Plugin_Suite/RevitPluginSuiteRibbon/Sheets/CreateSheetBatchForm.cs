/*            Comments
Clean up code a little
maybe make sheetnumbercheck and sheetnumber increment external classes

Do unknown exception and potential bug checks wrt user input or returned results or nulls

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

namespace RevitPluginSuiteRibbon
{
    [Transaction(TransactionMode.Manual)]
    public partial class CreateSheetBatchForm : System.Windows.Forms.Form
    {
        //create variables
        public UIApplication UiApp;
        public Document Doc;
        public UIDocument UiDoc;

        private List<Element> AvailableTitleBlockList = new List<Element>();

        public ElementId Selection;
        public int SheetQty;
        public string SheetName;
        public string SheetNumPrefix;
        public string SheetNumber;
        public string FullSheetNumber;

        public int SheetNumInt;
        public string SheetNumLetter;

        public bool SheetNumberIsNumbers = false;
        public bool SheetNumberIsLetters = false;

        List<ViewSheet> SheetsInDoc = new List<ViewSheet>();

        //declare string for initial directory of load family class
        public string InitialDirectory;

        //Form Initializer
        public CreateSheetBatchForm(ExternalCommandData commandData)
        {
            //get the application document and objects
            UiApp = commandData.Application;
            UiDoc = UiApp.ActiveUIDocument;
            Doc = UiDoc.Document;
            InitializeComponent();
        }

        //on form load
        private void CreateSheetBatchForm_Load(object sender, EventArgs e)
        {
            //set the text to show in sheetnumber
            txtbSheetNumPrefix.Text = "Prefix";
            txtbSheetNumber.Text = "Number";
            //set the default selected textbox when the form loads
            txtbSheetQty.Select();

            //call the methods to find the current titleblocks in the document and then populat the listbox
            CurrentTitleBlocks();
            lstbxTitleblock_Populate();
        }

        //get current titleblocks in document
        private void CurrentTitleBlocks()
        {
            //set up a filter to find all the titleblocks in the project
            FilteredElementCollector FECTitleblocks = new FilteredElementCollector(Doc);
            FECTitleblocks.OfClass(typeof(FamilySymbol));
            FECTitleblocks.OfCategory(BuiltInCategory.OST_TitleBlocks);
            //Set up list and fill with filtered titleblocks
            AvailableTitleBlockList = (List<Element>)FECTitleblocks.ToElements().ToList();
        }

        //populate listbox with titleblocks
        private void lstbxTitleblock_Populate()
        {
            //if the titleblock list has titleblocks in it
            if (AvailableTitleBlockList.Count != 0)
            {
                //fill the listbox with the titleblock list
                lstbxTitleblock.DataSource = AvailableTitleBlockList;
                //and set the display member and value member properly
                lstbxTitleblock.DisplayMember = "Name";
                lstbxTitleblock.ValueMember = "Id";
            }

            //else, if it is empty
            else
            {
                //if the user clicks yes to the message
                if (MessageBox.Show("This project has no titleblocks loaded"
                                    + Environment.NewLine +
                                    "Would you like to load new titleblocks now?",
                                    "Warning!",
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Question)
                                    == DialogResult.Yes)
                {
                    //the import titleblocks dialog is opened
                    ImportTitleblocks();
                }
            }
        }

        //When the 'Generate' button is pressed, check content of textboxes and pass data back to CreateSheetBatch function
        private void btnGenerateSheet_Click(object sender, EventArgs e)
        {
            //if the text in the quantity textbox is a number and between 1 and 200
            //set the sheet quantity variable
            if (int.TryParse(txtbSheetQty.Text, out SheetQty) && SheetQty <= 200 && SheetQty >= 1)
            {
                //if there is anything entered into the sheet num prefix textbox
                if (txtbSheetNumPrefix.Text != "")
                {
                    //check that user input sheet number is letters or numbers & not empty
                    if (General.StringCheck.IsAllLettersOrDigits(txtbSheetNumber.Text) == true && txtbSheetNumber.Text != "")
                    {
                        //if there is anything entered into the sheet name textbox
                        if (txtbSheetName.Text != "")
                        {
                            //if the user has selected a titleblock in the listbox
                            if (lstbxTitleblock.SelectedValue != null)
                            {

                                //set the sheet name and number variables
                                SheetName = txtbSheetName.Text;

                                SheetNumPrefix = txtbSheetNumPrefix.Text;
                                SheetNumber = txtbSheetNumber.Text;
                                FullSheetNumber = SheetNumPrefix + SheetNumber;

                                if (General.StringCheck.IsAllLetters(SheetNumber) == true)
                                {
                                    SheetNumberIsLetters = true;
                                    SheetNumLetter = SheetNumber;
                                }

                                else if (General.StringCheck.IsAllDigits(SheetNumber) == true)
                                {
                                    SheetNumberIsNumbers = true;
                                    SheetNumInt = int.Parse(SheetNumber);
                                }

                                //return the selected titleblock
                                Selection = lstbxTitleblock.SelectedValue as ElementId;

                                //check if sheet number already exists
                                if (SheetNumberCheck())
                                {
                                    CreateSheets();
                                    Close();
                                }
                                else
                                {
                                    return;
                                }
                            }
                            //message if the user has not selected a titleblock in the listbox
                            else
                            {
                                MessageBox.Show("Please select a titleblock.");
                            }
                        }
                        //message if the sheet name textbox is empty
                        else
                        {
                            MessageBox.Show("Plese enter a sheet name.");
                            txtbSheetName.SelectAll();
                        }
                    }
                    //message if the user has not selected a titleblock in the listbox
                    else
                    {
                        MessageBox.Show("Please enter a sheet number consisting of either letters or numbers.");
                        txtbSheetNumber.SelectAll();
                    }
                }
                //message if the sheet number textbox is empty
                else
                {
                    MessageBox.Show("Plese enter a sheet number prefix.");
                    txtbSheetNumPrefix.SelectAll();
                }
            }
            //message if the sheet quantity is not a number between 1 and 200
            else
            {
                MessageBox.Show("Plese enter a sheet quantity between 1 and 200.");
                txtbSheetQty.SelectAll();
            }
        }

        //create sheets
        private void CreateSheets()
        {
            using (Transaction myTransaction = new Transaction(Doc, "Create a new Viewsheet"))
            {
                //start the transaction
                myTransaction.Start();
                try
                {
                    //creates the quantity of sheets the user requested
                    int i = 1;
                    while (i <= SheetQty)
                    {
                        //create a sheet view
                        ViewSheet myViewSheet = ViewSheet.Create(Doc, Selection as ElementId);

                        //set the sheet number of each sheet

                        //if the sheetnumber is numbers
                        if (SheetNumberIsNumbers == true)
                        {
                            while (SheetsInDoc.FindIndex(x => x.SheetNumber.Equals(SheetNumPrefix + SheetNumInt, StringComparison.OrdinalIgnoreCase)) != -1)
                            {
                                //increment sheet number
                                SheetNumInt++;
                                //re-check if sheet exists
                            }

                            myViewSheet.SheetNumber = SheetNumPrefix + SheetNumInt;
                            SheetNumInt++;
                        }

                        //if the sheetnumber is letters
                        if (SheetNumberIsLetters == true)
                        {
                            while (SheetsInDoc.FindIndex(x => x.SheetNumber.Equals(SheetNumPrefix + SheetNumLetter, StringComparison.OrdinalIgnoreCase)) != -1)
                            {
                                //increment sheet number
                                SheetNumLetter = General.IncrementLetters.Increment(SheetNumLetter);
                                //re-check if sheet exists
                            }

                            myViewSheet.SheetNumber = SheetNumPrefix + SheetNumLetter;
                            SheetNumLetter = General.IncrementLetters.Increment(SheetNumLetter);
                        }

                        //set the name prefix of the sheets
                        myViewSheet.Name = SheetName;

                        i++;
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

        //When the 'Load' button is pressed, call load family class
        private void btnLoadTitleblock_Click(object sender, EventArgs e)
        {
            //Call the Load file dialog window to import the titleblocks
            ImportTitleblocks();

        }

        //Call the Load file dialog window to import the titleblocks
        private void ImportTitleblocks()
        {
            //create new instance of import family class
            RevitPluginSuiteRibbon.Import.ImportFamily ImportFamily = new Import.ImportFamily();

            //pass the initial directory to the class
            ImportFamily.ImportFamilyDialog(Doc, UiApp);//(InitialDirectory, Doc);

            //get new current titleblocks
            CurrentTitleBlocks();
            //populate the listbox
            lstbxTitleblock_Populate();
        }

        //check user input sheet number against existing
        private bool SheetNumberCheck()
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
            //because .ToElement does not work for ViewSheets class
            //we had to use Hennie fancy .Select type foreach loop to cast the "Elements" to "ViewSheets"            
            //in order to get access to the ViewSheets properties.

            //check if user input sheet number already exists
            string NextSheetNumber = SheetNumPrefix + SheetNumber;

            //if the user entered sheet number exists in the document
            if (SheetsInDoc.FindIndex(x => x.SheetNumber.Equals(NextSheetNumber, StringComparison.OrdinalIgnoreCase)) != -1)
            {
                //if sheetnumber = numbers then run int increment loop
                if (SheetNumberIsNumbers == true)
                {
                    //.FindIndex is used because it exits when the first instance is matched.
                    //.Exists or .Contains checks the entire list before exiting.
                    //While user input sheet number exists in document
                    while (SheetsInDoc.FindIndex(x => x.SheetNumber.Equals(NextSheetNumber, StringComparison.OrdinalIgnoreCase)) != -1)
                    {
                        //increment sheet number
                        SheetNumInt++;
                        //add sheetnumprefix and sheetnumber
                        NextSheetNumber = SheetNumPrefix + SheetNumInt;
                        //re-check if sheet exists
                    }

                    //when while loop breaks give user yes.no dialog
                    //when yes is clicked, Change the user input sheet number to the next one in the series
                    if (MessageBox.Show($"The sheet number {FullSheetNumber} already exists."
                                        + Environment.NewLine +
                                        $"Would you like to start with the next number in the series, {NextSheetNumber}?",
                                        "Warning!",
                                        MessageBoxButtons.YesNo,
                                        MessageBoxIcon.Question)
                                        == DialogResult.Yes)
                    {
                        //Change the user input sheet number to the next one in the series
                        SheetNumber = SheetNumInt.ToString();
                    }
                    else
                    {
                        txtbSheetNumPrefix.SelectAll();
                        return false;
                    }
                }

                //if sheetnumprefix = letter then run string increment loop
                else if (SheetNumberIsLetters == true)
                {
                    //.FindIndex is used because it exits when the first instance is matched.
                    //.Exists or .Contains checks the entire list before exiting.
                    //While user input sheet number exists in document
                    while (SheetsInDoc.FindIndex(x => x.SheetNumber.Equals(NextSheetNumber, StringComparison.OrdinalIgnoreCase)) != -1)
                    {
                        //increment sheet number
                        SheetNumLetter = General.IncrementLetters.Increment(SheetNumLetter);
                        //add sheetnumprefix and sheetnumber
                        NextSheetNumber = SheetNumPrefix + SheetNumLetter;
                        //re-check if sheet exists
                    }

                    //when while loop breaks give user yes.no dialog
                    //when yes is clicked, Change the user input sheet number to the next one in the series
                    if (MessageBox.Show($"The sheet number {FullSheetNumber} already exists."
                                        + Environment.NewLine +
                                        $"Would you like to start with the next number in the series, {NextSheetNumber}?",
                                        "Warning!",
                                        MessageBoxButtons.YesNo,
                                        MessageBoxIcon.Question)
                                        == DialogResult.Yes)
                    {
                        //Change the user input sheet number to the next one in the series
                        FullSheetNumber = NextSheetNumber;
                    }

                    //if "no" is clicked, close prompt and select the sheet number textbox
                    else
                    {
                        txtbSheetNumPrefix.SelectAll();
                        return false;
                    }
                }

                //Show message box if user has not entered pure letter or number as sheetnumber
                else
                {
                    MessageBox.Show("Please enter a sheetnumber of either letter or number format");
                }
            }

            return true;
        }

        private void txtbSheetQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Optional function to stop user
            //from being able to enter any character
            //other than numbers into the quantity textbox

            //                //allows backspace key
            //                if (e.KeyChar != '\b')
            //                {
            //                    //allows just number keys
            //                    e.Handled = !char.IsNumber(e.KeyChar);
            //                }
        }

        //Name individual sheets
        private void chkbxFullName()
        {
            /*
            option to name each sheet individually as it is created
            include a checkbox "Name each sheet", on the form
            when chkbx is changed to ticked, pop up yes/no window
            "Are you sure?", $"Ticking this option will open a prompt for each of the {sheetquantity} sheets in this batch." + Environment.writeling + "Do you wish to continue?"
            yes sets bool fullname to true, no changes chkbx to unticked
            when continue is clicked, set bool fullname to true
            ticking this option will pop up a window for each new sheet to name it individually
            while bool fullname is true, at creation of each sheet, an ok/cancel messagebox
            with "Please enter the individual sheet's name, for sheet {FullSheetNumber}." and "SheetName" Prefix + txtbxFullName
            this name will be appended to the prefix that was entered in txtbSheetName
            ok button continues to next created sheet and prompts for full name again
            cancel button brings up another yes/no message
            "Do you wish to cancel individual sheet naming for the rest of the batch?"
            no leaves FullName blank and continues opening messages for each new sheet
            yes sets bool fullname to false
            */
        }

       private void ImportSheetList()
        {
            /*
            Import sheet list from excell document
            */
        }
         #region Textbox 'select on focus' function

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