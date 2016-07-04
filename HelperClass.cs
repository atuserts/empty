using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmptyWebProject
{
    public class Class1
    {
        public static string ReturnClipboardString()
        {
            return System.Windows.Forms.Clipboard.GetText();
        }
    }
}
