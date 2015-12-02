namespace TravianBot.UI.Controls
{
    partial class AccountManagerControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.accountListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // accountListBox
            // 
            this.accountListBox.DisplayMember = "Username";
            this.accountListBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.accountListBox.FormattingEnabled = true;
            this.accountListBox.Location = new System.Drawing.Point(0, 0);
            this.accountListBox.Name = "accountListBox";
            this.accountListBox.Size = new System.Drawing.Size(151, 419);
            this.accountListBox.TabIndex = 0;
            // 
            // AccountManagerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.accountListBox);
            this.Name = "AccountManagerControl";
            this.Size = new System.Drawing.Size(524, 419);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox accountListBox;
    }
}
