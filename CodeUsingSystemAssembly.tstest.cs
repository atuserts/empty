using Telerik.TestingFramework.Controls.KendoUI;
using Telerik.WebAii.Controls.Html;
using Telerik.WebAii.Controls.Xaml;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using ArtOfTest.Common.UnitTesting;
using ArtOfTest.WebAii.Core;
using ArtOfTest.WebAii.Controls.HtmlControls;
using ArtOfTest.WebAii.Controls.HtmlControls.HtmlAsserts;
using ArtOfTest.WebAii.Design;
using ArtOfTest.WebAii.Design.Execution;
using ArtOfTest.WebAii.ObjectModel;
using ArtOfTest.WebAii.Silverlight;
using ArtOfTest.WebAii.Silverlight.UI;

namespace TestProject19
{

    public class CodeUsingSystemAssembly : BaseWebAiiTest
    {
        #region [ Dynamic Pages Reference ]

        private Pages _pages;

        /// <summary>
        /// Gets the Pages object that has references
        /// to all the elements, frames or regions
        /// in this project.
        /// </summary>
        public Pages Pages
        {
            get
            {
                if (_pages == null)
                {
                    _pages = new Pages(Manager.Current);
                }
                return _pages;
            }
        }

        #endregion
        public string clipboard;
        public string externalClipboard;
        // Add your test methods here...
    
        [CodedStep(@"CodeUsingSystemAssembly_CodedStep")]
        public void CodeUsingSystemAssembly_CodedStep()
        {
            Log.WriteLine(clipboard);
            Assert.IsTrue(clipboard == externalClipboard);
        }
        
        public static string ReturnClipboardString()
        {
            return System.Windows.Forms.Clipboard.GetText(); ;
        }
    
        [CodedStep(@"CopyContentToClipBoard")]
        public void CopyContentToClipBoard()
        {
            Exception ThreadEx = null;
            System.Threading.Thread staThread = new System.Threading.Thread(
            delegate()
            {
                try
                {
                    Manager.Current.Desktop.KeyBoard.KeyDown(System.Windows.Forms.Keys.Control);
                    Manager.Current.Desktop.KeyBoard.KeyPress(System.Windows.Forms.Keys.A);
                    Manager.Current.Desktop.KeyBoard.KeyUp(System.Windows.Forms.Keys.Control);
                    System.Threading.Thread.Sleep(500);
                    Manager.Current.Desktop.KeyBoard.KeyDown(System.Windows.Forms.Keys.Control);
                    Manager.Current.Desktop.KeyBoard.KeyPress(System.Windows.Forms.Keys.C);
                    Manager.Current.Desktop.KeyBoard.KeyUp(System.Windows.Forms.Keys.Control);
                    System.Threading.Thread.Sleep(200);
                    clipboard = EmptyWebProject.Class1.ReturnClipboardString();
                    externalClipboard = CodeUsingSystemAssembly.ReturnClipboardString();
                    Log.WriteLine(clipboard);
                }
                catch (Exception ex)
                {
                    ThreadEx = ex;
                }
            });
            staThread.SetApartmentState(System.Threading.ApartmentState.STA);
            staThread.Start();
            staThread.Join();
        }
    }
}
