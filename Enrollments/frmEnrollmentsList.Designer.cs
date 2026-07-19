namespace TMS.Enrollments
{
    partial class frmEnrollmentsList
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
            this.components = new System.ComponentModel.Container();
            this.lbTotalRecords = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbFilterBy = new System.Windows.Forms.ComboBox();
            this.dgvEnrollments = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showEnrollmentDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.addNewEnrollmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editEnrollmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteEnrollmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtFilterValue = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnAddSEnrollment = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEnrollments)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbTotalRecords
            // 
            this.lbTotalRecords.AutoSize = true;
            this.lbTotalRecords.Location = new System.Drawing.Point(118, 634);
            this.lbTotalRecords.Name = "lbTotalRecords";
            this.lbTotalRecords.Size = new System.Drawing.Size(44, 20);
            this.lbTotalRecords.TabIndex = 58;
            this.lbTotalRecords.Text = "[???]";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 634);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 20);
            this.label4.TabIndex = 57;
            this.label4.Text = "#Records:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(22, 254);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 20);
            this.label2.TabIndex = 55;
            this.label2.Text = "Filter By:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(445, 144);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(465, 55);
            this.label1.TabIndex = 54;
            this.label1.Text = "Manage Enrollments";
            // 
            // cbFilterBy
            // 
            this.cbFilterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterBy.FormattingEnabled = true;
            this.cbFilterBy.Items.AddRange(new object[] {
            "None",
            "Enrollment ID",
            "Class ID",
            "Full Name"});
            this.cbFilterBy.Location = new System.Drawing.Point(108, 254);
            this.cbFilterBy.Name = "cbFilterBy";
            this.cbFilterBy.Size = new System.Drawing.Size(165, 28);
            this.cbFilterBy.TabIndex = 60;
            this.cbFilterBy.SelectedIndexChanged += new System.EventHandler(this.cbFilterBy_SelectedIndexChanged);
            // 
            // dgvEnrollments
            // 
            this.dgvEnrollments.AllowUserToAddRows = false;
            this.dgvEnrollments.AllowUserToDeleteRows = false;
            this.dgvEnrollments.AllowUserToResizeColumns = false;
            this.dgvEnrollments.AllowUserToResizeRows = false;
            this.dgvEnrollments.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvEnrollments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEnrollments.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvEnrollments.GridColor = System.Drawing.SystemColors.Control;
            this.dgvEnrollments.Location = new System.Drawing.Point(16, 294);
            this.dgvEnrollments.Name = "dgvEnrollments";
            this.dgvEnrollments.Size = new System.Drawing.Size(1261, 334);
            this.dgvEnrollments.TabIndex = 59;
            this.dgvEnrollments.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEnrollments_CellDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showEnrollmentDetailsToolStripMenuItem,
            this.toolStripMenuItem1,
            this.addNewEnrollmentToolStripMenuItem,
            this.editEnrollmentToolStripMenuItem,
            this.deleteEnrollmentToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(219, 162);
            // 
            // showEnrollmentDetailsToolStripMenuItem
            // 
            this.showEnrollmentDetailsToolStripMenuItem.Image = global::TMS.Properties.Resources.EnrollmentInfo32;
            this.showEnrollmentDetailsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.showEnrollmentDetailsToolStripMenuItem.Name = "showEnrollmentDetailsToolStripMenuItem";
            this.showEnrollmentDetailsToolStripMenuItem.Size = new System.Drawing.Size(218, 38);
            this.showEnrollmentDetailsToolStripMenuItem.Text = "Show Enrollment Details";
            this.showEnrollmentDetailsToolStripMenuItem.Click += new System.EventHandler(this.showEnrollmentDetailsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(215, 6);
            // 
            // addNewEnrollmentToolStripMenuItem
            // 
            this.addNewEnrollmentToolStripMenuItem.Image = global::TMS.Properties.Resources.AddNewEnrollment32;
            this.addNewEnrollmentToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.addNewEnrollmentToolStripMenuItem.Name = "addNewEnrollmentToolStripMenuItem";
            this.addNewEnrollmentToolStripMenuItem.Size = new System.Drawing.Size(218, 38);
            this.addNewEnrollmentToolStripMenuItem.Text = "Add New Enrollment";
            // 
            // editEnrollmentToolStripMenuItem
            // 
            this.editEnrollmentToolStripMenuItem.Image = global::TMS.Properties.Resources.edit_32;
            this.editEnrollmentToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.editEnrollmentToolStripMenuItem.Name = "editEnrollmentToolStripMenuItem";
            this.editEnrollmentToolStripMenuItem.Size = new System.Drawing.Size(218, 38);
            this.editEnrollmentToolStripMenuItem.Text = "Edit Enrollment";
            this.editEnrollmentToolStripMenuItem.Click += new System.EventHandler(this.editEnrollmentToolStripMenuItem_Click);
            // 
            // deleteEnrollmentToolStripMenuItem
            // 
            this.deleteEnrollmentToolStripMenuItem.Image = global::TMS.Properties.Resources.Delete_32;
            this.deleteEnrollmentToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.deleteEnrollmentToolStripMenuItem.Name = "deleteEnrollmentToolStripMenuItem";
            this.deleteEnrollmentToolStripMenuItem.Size = new System.Drawing.Size(218, 38);
            this.deleteEnrollmentToolStripMenuItem.Text = "Delete Enrollment";
            this.deleteEnrollmentToolStripMenuItem.Click += new System.EventHandler(this.deleteEnrollmentToolStripMenuItem_Click);
            // 
            // txtFilterValue
            // 
            this.txtFilterValue.Location = new System.Drawing.Point(285, 255);
            this.txtFilterValue.Name = "txtFilterValue";
            this.txtFilterValue.Size = new System.Drawing.Size(186, 26);
            this.txtFilterValue.TabIndex = 61;
            this.txtFilterValue.Visible = false;
            this.txtFilterValue.TextChanged += new System.EventHandler(this.txtFilterValue_TextChanged);
            this.txtFilterValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilterValue_KeyPress);
            // 
            // btnClose
            // 
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Image = global::TMS.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(1148, 634);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(129, 41);
            this.btnClose.TabIndex = 62;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnAddSEnrollment
            // 
            this.btnAddSEnrollment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddSEnrollment.Image = global::TMS.Properties.Resources.AddNewEnrollment64;
            this.btnAddSEnrollment.Location = new System.Drawing.Point(1195, 223);
            this.btnAddSEnrollment.Name = "btnAddSEnrollment";
            this.btnAddSEnrollment.Size = new System.Drawing.Size(82, 65);
            this.btnAddSEnrollment.TabIndex = 56;
            this.btnAddSEnrollment.UseVisualStyleBackColor = true;
            this.btnAddSEnrollment.Click += new System.EventHandler(this.btnAddSEnrollment_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::TMS.Properties.Resources.Enrollments512;
            this.pictureBox1.Location = new System.Drawing.Point(563, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(228, 129);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 53;
            this.pictureBox1.TabStop = false;
            // 
            // frmEnrollmentsList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1293, 687);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnAddSEnrollment);
            this.Controls.Add(this.lbTotalRecords);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.cbFilterBy);
            this.Controls.Add(this.dgvEnrollments);
            this.Controls.Add(this.txtFilterValue);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmEnrollmentsList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Enrollments List";
            this.Load += new System.EventHandler(this.frmEnrollmentsList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEnrollments)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnAddSEnrollment;
        private System.Windows.Forms.Label lbTotalRecords;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox cbFilterBy;
        private System.Windows.Forms.DataGridView dgvEnrollments;
        private System.Windows.Forms.TextBox txtFilterValue;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem showEnrollmentDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem addNewEnrollmentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editEnrollmentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteEnrollmentToolStripMenuItem;
    }
}