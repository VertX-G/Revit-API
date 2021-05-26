using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitPluginSuiteRibbon.Resources
{
    class NewSheetNumber
    {
        public string Prefix;// { get; set; }
        public string Number;// { get; set; }
        public string FullNumber;// { get; set; }

        //Constructor for SheetData Class
        public NewSheetNumber(string SheetPrefix, string SheetNumber)
        {
            Prefix = SheetPrefix;
            Number = SheetNumber;
            FullNumber = Prefix + Number;
        }
    }
}
