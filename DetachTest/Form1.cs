using DetachTest.Docking;

using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace DetachTest
{
    public partial class Form1 : Form
    {
        private DetachableControl _detachableControl;
        
        public Form1()
        {
            InitializeComponent();

            _detachableControl = new DetachableControl(someUserControl1);
            
            buttonDetach.Click += (_, _) => _detachableControl.Detach(this);
            buttonAttach.Click += (_, _) => _detachableControl.Attach();

            someUserControl1.AttachRequested += (_, _) => _detachableControl.Attach();
            someUserControl1.DetachRequested += (_, _) => _detachableControl.Detach(this);
        }
    }
}