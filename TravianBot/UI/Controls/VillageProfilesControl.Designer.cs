namespace TravianBot.UI.Controls
{
    partial class VillageProfilesControl
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
            this.createProfileBtn = new System.Windows.Forms.Button();
            this.profileComboBox = new System.Windows.Forms.ComboBox();
            this.requirementListBox = new System.Windows.Forms.ListBox();
            this.addBtn = new System.Windows.Forms.Button();
            this.removeBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.profileNameTxtBox = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // createProfileBtn
            // 
            this.createProfileBtn.AutoSize = true;
            this.createProfileBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.createProfileBtn.Location = new System.Drawing.Point(183, 3);
            this.createProfileBtn.Name = "createProfileBtn";
            this.createProfileBtn.Size = new System.Drawing.Size(174, 26);
            this.createProfileBtn.TabIndex = 1;
            this.createProfileBtn.Text = "Create Profile";
            this.createProfileBtn.UseVisualStyleBackColor = true;
            this.createProfileBtn.Click += new System.EventHandler(this.createProfileBtn_Click);
            // 
            // profileComboBox
            // 
            this.profileComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.profileComboBox.FormattingEnabled = true;
            this.profileComboBox.Location = new System.Drawing.Point(3, 35);
            this.profileComboBox.Name = "profileComboBox";
            this.profileComboBox.Size = new System.Drawing.Size(174, 21);
            this.profileComboBox.TabIndex = 2;
            // 
            // requirementListBox
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.requirementListBox, 2);
            this.requirementListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.requirementListBox.FormattingEnabled = true;
            this.requirementListBox.Location = new System.Drawing.Point(3, 99);
            this.requirementListBox.Name = "requirementListBox";
            this.requirementListBox.Size = new System.Drawing.Size(354, 346);
            this.requirementListBox.TabIndex = 3;
            // 
            // addBtn
            // 
            this.addBtn.AutoSize = true;
            this.addBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.addBtn.Location = new System.Drawing.Point(183, 451);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(174, 26);
            this.addBtn.TabIndex = 4;
            this.addBtn.Text = "Add New";
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // removeBtn
            // 
            this.removeBtn.AutoSize = true;
            this.removeBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.removeBtn.Location = new System.Drawing.Point(3, 451);
            this.removeBtn.Name = "removeBtn";
            this.removeBtn.Size = new System.Drawing.Size(174, 26);
            this.removeBtn.TabIndex = 5;
            this.removeBtn.Text = "Remove";
            this.removeBtn.UseVisualStyleBackColor = true;
            this.removeBtn.Click += new System.EventHandler(this.removeBtn_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Profile Requirements :";
            // 
            // profileNameTxtBox
            // 
            this.profileNameTxtBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.profileNameTxtBox.Location = new System.Drawing.Point(3, 3);
            this.profileNameTxtBox.Name = "profileNameTxtBox";
            this.profileNameTxtBox.Size = new System.Drawing.Size(174, 20);
            this.profileNameTxtBox.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.profileNameTxtBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.removeBtn, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.createProfileBtn, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.profileComboBox, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.addBtn, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.requirementListBox, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(360, 480);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // VillageProfilesControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "VillageProfilesControl";
            this.Size = new System.Drawing.Size(360, 480);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button createProfileBtn;
        private System.Windows.Forms.ComboBox profileComboBox;
        private System.Windows.Forms.ListBox requirementListBox;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.Button removeBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox profileNameTxtBox;
    }
}
