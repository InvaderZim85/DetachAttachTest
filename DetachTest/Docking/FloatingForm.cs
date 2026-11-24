using System.Windows.Forms;

namespace DetachTest.Docking;

public sealed partial class FloatingForm : Form
{
    public FloatingForm(string title)
    {
        InitializeComponent();

        Text = title;
    }
}