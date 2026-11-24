using System;
using System.Drawing;
using System.Windows.Forms;

namespace DetachTest.Docking;

public sealed class DetachableControl
{
    private readonly Control _control;
    private readonly Control _originalParent;

    private readonly int _originalIndex;
    private readonly DockStyle _originalDock;
    private readonly AnchorStyles _originalAnchor;
    private readonly Rectangle _originalBounds;
    private readonly Padding _originalMargin;

    private FloatingForm _floatingForm;

    public bool IsDetached => _floatingForm != null;
    public FloatingForm FloatingForm => _floatingForm;

    public DetachableControl(Control control)
    {
        if (control is null)
            throw new ArgumentNullException(nameof(control));

        if (control.Parent is null)
            throw new ArgumentException("Parent missing", nameof(control));

        _control = control;
        _originalParent = control.Parent;

        _originalIndex = _originalParent.Controls.GetChildIndex(control);
        _originalDock = control.Dock;
        _originalAnchor = control.Anchor;
        _originalBounds = control.Bounds;
        _originalMargin = control.Margin;
    }

    public void Detach(IWin32Window owner = null)
    {
        if (IsDetached)
            return;

        if (_control.IsDisposed)
            throw new ObjectDisposedException(_control.Name);

        if (_originalParent.IsDisposed || _originalParent.Disposing)
            throw new InvalidOperationException("Parent was disposed.");

        string title = string.IsNullOrWhiteSpace(_control.Text)
            ? _control.Name
            : _control.Text;

        var floatingForm = new FloatingForm(title);

        try
        {
            // Remove the control from the parent
            _originalParent.Controls.Remove(_control);

            _control.Dock = DockStyle.Fill;

            floatingForm.Controls.Add(_control);

            _floatingForm = floatingForm;

            floatingForm.FormClosing += FloatingForm_Closing;

            if (owner is not null)
                floatingForm.Show(owner);
            else
                floatingForm.Show();
        }
        catch (Exception ex)
        {
            RestoreControl();

            floatingForm.Dispose();

            throw;
        }
    }

    private void FloatingForm_Closing(object sender, EventArgs e)
    {
        RestoreControl();
    }

    public void Attach()
    {
        if (!IsDetached)
            return;
        
        _floatingForm.Close();
    }

    private void RestoreControl()
    {
        if (_floatingForm is not null)
        {
            _floatingForm.Controls.Remove(_control);
            _floatingForm.FormClosing -= FloatingForm_Closing;
            _floatingForm = null;
        }

        if (_originalParent.IsDisposed ||
            _originalParent.Disposing ||
            _control.IsDisposed)
            return;

        _control.Dock = _originalDock;
        _control.Anchor = _originalAnchor;
        _control.Margin = _originalMargin;
        _control.Bounds = _originalBounds;
        _control.Dock = _originalDock;

        _originalParent.Controls.Add(_control);

        int index = Math.Min(_originalIndex, _originalParent.Controls.Count - 1);

        _originalParent.Controls.SetChildIndex(_control, index);
    }
    
}