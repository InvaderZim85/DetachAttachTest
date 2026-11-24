using System;
using System.Windows.Forms;

namespace DetachTest;

public partial class SomeUserControl : UserControl
{
    public event EventHandler DetachRequested;
    public event EventHandler AttachRequested;
    
    public SomeUserControl()
    {
        InitializeComponent();

        buttonAttach.Click += (_, _) => AttachRequested?.Invoke(this, EventArgs.Empty);
        buttonDetach.Click += (_, _) => DetachRequested?.Invoke(this, EventArgs.Empty);
    }

    private void buttonShowMessage_Click(object sender, EventArgs e)
    {
        MessageBox.Show("Some Message");
    }
}