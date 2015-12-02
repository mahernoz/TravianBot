namespace TravianBot.UI.Controls
{
    partial class ServerViewTabPage
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
            this.components = new System.ComponentModel.Container();
            this.table = new System.Windows.Forms.TableLayoutPanel();
            this.groupPlayers = new System.Windows.Forms.GroupBox();
            this.gridPlayers = new System.Windows.Forms.DataGridView();
            this.groupAllies = new System.Windows.Forms.GroupBox();
            this.gridAllies = new System.Windows.Forms.DataGridView();
            this.ıdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rankDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ısGoldClubDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tribeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.allianceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ısAdminDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.villagesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.centralVillageDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.playerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.table.SuspendLayout();
            this.groupPlayers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPlayers)).BeginInit();
            this.groupAllies.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridAllies)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // table
            // 
            this.table.ColumnCount = 2;
            this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.table.Controls.Add(this.groupPlayers, 0, 0);
            this.table.Controls.Add(this.groupAllies, 0, 1);
            this.table.Dock = System.Windows.Forms.DockStyle.Fill;
            this.table.Location = new System.Drawing.Point(0, 0);
            this.table.Name = "table";
            this.table.RowCount = 2;
            this.table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.table.Size = new System.Drawing.Size(1024, 457);
            this.table.TabIndex = 1;
            // 
            // groupPlayers
            // 
            this.table.SetColumnSpan(this.groupPlayers, 2);
            this.groupPlayers.Controls.Add(this.gridPlayers);
            this.groupPlayers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPlayers.Location = new System.Drawing.Point(3, 3);
            this.groupPlayers.Name = "groupPlayers";
            this.groupPlayers.Size = new System.Drawing.Size(1018, 222);
            this.groupPlayers.TabIndex = 0;
            this.groupPlayers.TabStop = false;
            this.groupPlayers.Text = "Players";
            // 
            // gridPlayers
            // 
            this.gridPlayers.AllowUserToOrderColumns = true;
            this.gridPlayers.AutoGenerateColumns = false;
            this.gridPlayers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridPlayers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ıdDataGridViewTextBoxColumn,
            this.rankDataGridViewTextBoxColumn,
            this.ısGoldClubDataGridViewCheckBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.descriptionDataGridViewTextBoxColumn,
            this.tribeDataGridViewTextBoxColumn,
            this.allianceDataGridViewTextBoxColumn,
            this.ısAdminDataGridViewCheckBoxColumn,
            this.villagesDataGridViewTextBoxColumn,
            this.centralVillageDataGridViewTextBoxColumn});
            this.gridPlayers.DataSource = this.playerBindingSource;
            this.gridPlayers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridPlayers.Location = new System.Drawing.Point(3, 16);
            this.gridPlayers.Name = "gridPlayers";
            this.gridPlayers.Size = new System.Drawing.Size(1012, 203);
            this.gridPlayers.TabIndex = 0;
            // 
            // groupAllies
            // 
            this.table.SetColumnSpan(this.groupAllies, 2);
            this.groupAllies.Controls.Add(this.gridAllies);
            this.groupAllies.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupAllies.Location = new System.Drawing.Point(3, 231);
            this.groupAllies.Name = "groupAllies";
            this.groupAllies.Size = new System.Drawing.Size(1018, 223);
            this.groupAllies.TabIndex = 1;
            this.groupAllies.TabStop = false;
            this.groupAllies.Text = "Alliances";
            // 
            // gridAllies
            // 
            this.gridAllies.AllowUserToOrderColumns = true;
            this.gridAllies.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridAllies.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridAllies.Location = new System.Drawing.Point(3, 16);
            this.gridAllies.Name = "gridAllies";
            this.gridAllies.Size = new System.Drawing.Size(1012, 204);
            this.gridAllies.TabIndex = 0;
            // 
            // ıdDataGridViewTextBoxColumn
            // 
            this.ıdDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.ıdDataGridViewTextBoxColumn.HeaderText = "ID";
            this.ıdDataGridViewTextBoxColumn.Name = "ıdDataGridViewTextBoxColumn";
            this.ıdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // rankDataGridViewTextBoxColumn
            // 
            this.rankDataGridViewTextBoxColumn.DataPropertyName = "Rank";
            this.rankDataGridViewTextBoxColumn.HeaderText = "Rank";
            this.rankDataGridViewTextBoxColumn.Name = "rankDataGridViewTextBoxColumn";
            // 
            // ısGoldClubDataGridViewCheckBoxColumn
            // 
            this.ısGoldClubDataGridViewCheckBoxColumn.DataPropertyName = "IsGoldClub";
            this.ısGoldClubDataGridViewCheckBoxColumn.HeaderText = "Gold Member";
            this.ısGoldClubDataGridViewCheckBoxColumn.Name = "ısGoldClubDataGridViewCheckBoxColumn";
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "Description";
            this.descriptionDataGridViewTextBoxColumn.HeaderText = "Description";
            this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            // 
            // tribeDataGridViewTextBoxColumn
            // 
            this.tribeDataGridViewTextBoxColumn.DataPropertyName = "Tribe";
            this.tribeDataGridViewTextBoxColumn.HeaderText = "Tribe";
            this.tribeDataGridViewTextBoxColumn.Name = "tribeDataGridViewTextBoxColumn";
            // 
            // allianceDataGridViewTextBoxColumn
            // 
            this.allianceDataGridViewTextBoxColumn.DataPropertyName = "Alliance";
            this.allianceDataGridViewTextBoxColumn.HeaderText = "Alliance";
            this.allianceDataGridViewTextBoxColumn.Name = "allianceDataGridViewTextBoxColumn";
            // 
            // ısAdminDataGridViewCheckBoxColumn
            // 
            this.ısAdminDataGridViewCheckBoxColumn.DataPropertyName = "IsAdmin";
            this.ısAdminDataGridViewCheckBoxColumn.HeaderText = "IsAdmin";
            this.ısAdminDataGridViewCheckBoxColumn.Name = "ısAdminDataGridViewCheckBoxColumn";
            // 
            // villagesDataGridViewTextBoxColumn
            // 
            this.villagesDataGridViewTextBoxColumn.DataPropertyName = "Villages";
            this.villagesDataGridViewTextBoxColumn.HeaderText = "Villages";
            this.villagesDataGridViewTextBoxColumn.Name = "villagesDataGridViewTextBoxColumn";
            this.villagesDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // centralVillageDataGridViewTextBoxColumn
            // 
            this.centralVillageDataGridViewTextBoxColumn.DataPropertyName = "CentralVillage";
            this.centralVillageDataGridViewTextBoxColumn.HeaderText = "CentralVillage";
            this.centralVillageDataGridViewTextBoxColumn.Name = "centralVillageDataGridViewTextBoxColumn";
            this.centralVillageDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // playerBindingSource
            // 
            this.playerBindingSource.DataSource = typeof(TravianBot.Data.Player);
            // 
            // ServerViewTabPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.table);
            this.Name = "ServerViewTabPage";
            this.Size = new System.Drawing.Size(1024, 457);
            this.table.ResumeLayout(false);
            this.groupPlayers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridPlayers)).EndInit();
            this.groupAllies.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridAllies)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel table;
        private System.Windows.Forms.GroupBox groupPlayers;
        private System.Windows.Forms.DataGridView gridPlayers;
        private System.Windows.Forms.GroupBox groupAllies;
        private System.Windows.Forms.DataGridView gridAllies;
        private System.Windows.Forms.DataGridViewTextBoxColumn ıdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rankDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ısGoldClubDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tribeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn allianceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ısAdminDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn villagesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn centralVillageDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource playerBindingSource;
    }
}
