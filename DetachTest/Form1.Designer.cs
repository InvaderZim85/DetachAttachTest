namespace DetachTest
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.someUserControl1 = new DetachTest.SomeUserControl();
            this.buttonDetach = new System.Windows.Forms.Button();
            this.buttonAttach = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // someUserControl1
            // 
            this.someUserControl1.Location = new System.Drawing.Point(202, 38);
            this.someUserControl1.Name = "someUserControl1";
            this.someUserControl1.Size = new System.Drawing.Size(368, 250);
            this.someUserControl1.TabIndex = 0;
            // 
            // buttonDetach
            // 
            this.buttonDetach.Location = new System.Drawing.Point(12, 415);
            this.buttonDetach.Name = "buttonDetach";
            this.buttonDetach.Size = new System.Drawing.Size(75, 23);
            this.buttonDetach.TabIndex = 1;
            this.buttonDetach.Text = "Detach";
            this.buttonDetach.UseVisualStyleBackColor = true;
            // 
            // buttonAttach
            // 
            this.buttonAttach.Location = new System.Drawing.Point(93, 415);
            this.buttonAttach.Name = "buttonAttach";
            this.buttonAttach.Size = new System.Drawing.Size(75, 23);
            this.buttonAttach.TabIndex = 2;
            this.buttonAttach.Text = "Attach";
            this.buttonAttach.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonAttach);
            this.Controls.Add(this.buttonDetach);
            this.Controls.Add(this.someUserControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button buttonDetach;
        private System.Windows.Forms.Button buttonAttach;

        private DetachTest.SomeUserControl someUserControl1;

        #endregion
    }
}