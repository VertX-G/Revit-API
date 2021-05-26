using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using TaskDialog = Autodesk.Revit.UI.TaskDialog;

namespace RevitPluginSuiteRibbon.General
{
    class RevisionData
    {
        public int SequenceNumber { get; set; }
        public RevisionNumberType NumberType { get; set; }
        public string RevisionDate { get; set; }
        public string Description { get; set; }
        public bool Issued { get; set; }
        public string IssuedTo { get; set; }
        public string IssuedBy { get; set; }
        public RevisionVisibility Show { get; set; }
        public ElementId Id { get; set; }
        public string RevisionNumber { get; set; }

        public RevisionData(Revision r)
        {
            SequenceNumber = r.SequenceNumber;
            NumberType = r.NumberType;
            RevisionDate = r.RevisionDate;
            Description = r.Description;
            Issued = r.Issued;
            IssuedTo = r.IssuedTo;
            IssuedBy = r.IssuedBy;
            Show = r.Visibility;
            Id = r.Id;
            RevisionNumber = r.RevisionNumber;
        }
    }
}
