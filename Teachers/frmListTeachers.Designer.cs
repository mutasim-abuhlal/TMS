namespace TMS.Teachers
{
    partial class frmListTeachers
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
            this.txtFilterValue = new System.Windows.Forms.TextBox();
            this.cbFilterBy = new System.Windows.Forms.ComboBox();
            this.dgvTeachers = new System.Windows.Forms.DataGridView();
            this.lbTotalRecords = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnClose = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnAddNewTeacher = new System.Windows.Forms.Button();
            this.showTeacherDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewTeacherToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editTeacherToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteTeacherToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sendEmailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.callPhoneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTeachers)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtFilterValue
            // 
            this.txtFilterValue.Location = new System.Drawing.Point(288, 255);
            this.txtFilterValue.Name = "txtFilterValue";
            this.txtFilterValue.Size = new System.Drawing.Size(186, 26);
            this.txtFilterValue.TabIndex = 51;
            this.txtFilterValue.Visible = false;
            this.txtFilterValue.TextChanged += new System.EventHandler(this.txtFilterValue_TextChanged);
            this.txtFilterValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilterValue_KeyPress);
            // 
            // cbFilterBy
            // 
            this.cbFilterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterBy.FormattingEnabled = true;
            this.cbFilterBy.Items.AddRange(new object[] {
            "None",
            "Teacher ID",
            "Major",
            "National No",
            "Full Name"});
            this.cbFilterBy.Location = new System.Drawing.Point(111, 254);
            this.cbFilterBy.Name = "cbFilterBy";
            this.cbFilterBy.Size = new System.Drawing.Size(165, 28);
            this.cbFilterBy.TabIndex = 50;
            this.cbFilterBy.SelectedIndexChanged += new System.EventHandler(this.cbFilterBy_SelectedIndexChanged);
            // 
            // dgvTeachers
            // 
            this.dgvTeachers.AllowUserToAddRows = false;
            this.dgvTeachers.AllowUserToDeleteRows = false;
            this.dgvTeachers.AllowUserToResizeColumns = false;
            this.dgvTeachers.AllowUserToResizeRows = false;
            this.dgvTeachers.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvTeachers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTeachers.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvTeachers.GridColor = System.Drawing.SystemColors.Control;
            this.dgvTeachers.Location = new System.Drawing.Point(19, 294);
            this.dgvTeachers.Name = "dgvTeachers";
            this.dgvTeachers.Size = new System.Drawing.Size(942, 334);
            this.dgvTeachers.TabIndex = 49;
            this.dgvTeachers.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTeachers_CellDoubleClick);
            // 
            // lbTotalRecords
            // 
            this.lbTotalRecords.AutoSize = true;
            this.lbTotalRecords.Location = new System.Drawing.Point(121, 634);
            this.lbTotalRecords.Name = "lbTotalRecords";
            this.lbTotalRecords.Size = new System.Drawing.Size(44, 20);
            this.lbTotalRecords.TabIndex = 48;
            this.lbTotalRecords.Text = "[???]";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(15, 634);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 20);
            this.label4.TabIndex = 47;
            this.label4.Text = "#Records:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(25, 254);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 20);
            this.label2.TabIndex = 45;
            this.label2.Text = "Filter By:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(309, 160);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(413, 55);
            this.label1.TabIndex = 44;
            this.label1.Text = "Manage Teachers";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showTeacherDetailsToolStripMenuItem,
            this.toolStripMenuItem1,
            this.addNewTeacherToolStripMenuItem,
            this.editTeacherToolStripMenuItem,
            this.deleteTeacherToolStripMenuItem,
            this.toolStripMenuItem2,
            this.sendEmailToolStripMenuItem,
            this.callPhoneToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(201, 244);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(197, 6);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(197, 6);
            // 
            // btnClose
            // 
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Image = global::TMS.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(832, 634);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(129, 41);
            this.btnClose.TabIndex = 52;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::TMS.Properties.Resources.Teachers512;
            this.pictureBox1.Location = new System.Drawing.Point(398, 28);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(228, 129);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 43;
            this.pictureBox1.TabStop = false;
            // 
            // btnAddNewTeacher
            // 
            this.btnAddNewTeacher.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNewTeacher.Image = global::TMS.Properties.Resources.AddTeacher64;
            this.btnAddNewTeacher.Location = new System.Drawing.Point(873, 212);
            this.btnAddNewTeacher.Name = "btnAddNewTeacher";
            this.btnAddNewTeacher.Size = new System.Drawing.Size(88, 76);
            this.btnAddNewTeacher.TabIndex = 46;
            this.btnAddNewTeacher.UseVisualStyleBackColor = true;
            this.btnAddNewTeacher.Click += new System.EventHandler(this.btnAddNewTeacher_Click);
            // 
            // showTeacherDetailsToolStripMenuItem
            // 
            this.showTeacherDetailsToolStripMenuItem.Image = global::TMS.Properties.Resources.PersonDetails_32;
            this.showTeacherDetailsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.showTeacherDetailsToolStripMenuItem.Name = "showTeacherDetailsToolStripMenuItem";
            this.showTeacherDetailsToolStripMenuItem.Size = new System.Drawing.Size(200, 38);
            this.showTeacherDetailsToolStripMenuItem.Text = "Show Teacher Details";
            this.showTeacherDetailsToolStripMenuItem.Click += new System.EventHandler(this.showTeacherDetailsToolStripMenuItem_Click);
            // 
            // addNewTeacherToolStripMenuItem
            // 
            this.addNewTeacherToolStripMenuItem.Image = global::TMS.Properties.Resources.AddTeacher32;
            this.addNewTeacherToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.addNewTeacherToolStripMenuItem.Name = "addNewTeacherToolStripMenuItem";
            this.addNewTeacherToolStripMenuItem.Size = new System.Drawing.Size(200, 38);
            this.addNewTeacherToolStripMenuItem.Text = "Add New Teacher";
            this.addNewTeacherToolStripMenuItem.Click += new System.EventHandler(this.addNewTeacherToolStripMenuItem_Click);
            // 
            // editTeacherToolStripMenuItem
            // 
            this.editTeacherToolStripMenuItem.Image = global::TMS.Properties.Resources.edit_32;
            this.editTeacherToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.editTeacherToolStripMenuItem.Name = "editTeacherToolStripMenuItem";
            this.editTeacherToolStripMenuItem.Size = new System.Drawing.Size(200, 38);
            this.editTeacherToolStripMenuItem.Text = "Edit Teacher";
            this.editTeacherToolStripMenuItem.Click += new System.EventHandler(this.editTeacherToolStripMenuItem_Click);
            // 
            // deleteTeacherToolStripMenuItem
            // 
            this.deleteTeacherToolStripMenuItem.Image = global::TMS.Properties.Resources.Delete_32;
            this.deleteTeacherToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.deleteTeacherToolStripMenuItem.Name = "deleteTeacherToolStripMenuItem";
            this.deleteTeacherToolStripMenuItem.Size = new System.Drawing.Size(200, 38);
            this.deleteTeacherToolStripMenuItem.Text = "Delete Teacher";
            this.deleteTeacherToolStripMenuItem.Click += new System.EventHandler(this.deleteTeacherToolStripMenuItem_Click);
            // 
            // sendEmailToolStripMenuItem
            // 
            this.sendEmailToolStripMenuItem.Image = global::TMS.Properties.Resources.send_email_32;
            this.sendEmailToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.sendEmailToolStripMenuItem.Name = "sendEmailToolStripMenuItem";
            this.sendEmailToolStripMenuItem.Size = new System.Drawing.Size(200, 38);
            this.sendEmailToolStripMenuItem.Text = "Send Email";
            this.sendEmailToolStripMenuItem.Click += new System.EventHandler(this.sendEmailToolStripMenuItem_Click);
            // 
            // callPhoneToolStripMenuItem
            // 
            this.callPhoneToolStripMenuItem.Image = global::TMS.Properties.Resources.call_32;
            this.callPhoneToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.callPhoneToolStripMenuItem.Name = "callPhoneToolStripMenuItem";
            this.callPhoneToolStripMenuItem.Size = new System.Drawing.Size(200, 38);
            this.callPhoneToolStripMenuItem.Text = "Call Phone";
            this.callPhoneToolStripMenuItem.Click += new System.EventHandler(this.callPhoneToolStripMenuItem_Click);
            // 
            // frmListTeachers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(999, 700);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtFilterValue);
            this.Controls.Add(this.cbFilterBy);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnAddNewTeacher);
            this.Controls.Add(this.dgvTeachers);
            this.Controls.Add(this.lbTotalRecords);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmListTeachers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "List Teachers";
            this.Load += new System.EventHandler(this.frmListTeachers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTeachers)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtFilterValue;
        private System.Windows.Forms.ComboBox cbFilterBy;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnAddNewTeacher;
        private System.Windows.Forms.DataGridView dgvTeachers;
        private System.Windows.Forms.Label lbTotalRecords;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem showTeacherDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem addNewTeacherToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editTeacherToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteTeacherToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem sendEmailToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem callPhoneToolStripMenuItem;
    }
}