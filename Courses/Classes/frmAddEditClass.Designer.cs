namespace TMS.Courses.Classes
{
    partial class frmAddEditClass
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
            this.lbTitle = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpCourseInfo = new System.Windows.Forms.TabPage();
            this.btnNext = new System.Windows.Forms.Button();
            this.tpClassroomInfo = new System.Windows.Forms.TabPage();
            this.btnClassroomInfoNext = new System.Windows.Forms.Button();
            this.tpClassInfo = new System.Windows.Forms.TabPage();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbCreationDate = new System.Windows.Forms.Label();
            this.lbCreatedBy = new System.Windows.Forms.Label();
            this.lbSessionID = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.ctrlCourseCardWithFilter1 = new TMS.Courses.ctrlCourseCardWithFilter();
            this.ctrlClassroomCardWithFilter1 = new TMS.Courses.Classrooms.ctrlClassroomCardWithFilter();
            this.tabControl1.SuspendLayout();
            this.tpCourseInfo.SuspendLayout();
            this.tpClassroomInfo.SuspendLayout();
            this.tpClassInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbTitle
            // 
            this.lbTitle.BackColor = System.Drawing.Color.Transparent;
            this.lbTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 33F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbTitle.Location = new System.Drawing.Point(0, 0);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(986, 51);
            this.lbTitle.TabIndex = 1;
            this.lbTitle.Text = "Add New Class";
            this.lbTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpCourseInfo);
            this.tabControl1.Controls.Add(this.tpClassroomInfo);
            this.tabControl1.Controls.Add(this.tpClassInfo);
            this.tabControl1.Location = new System.Drawing.Point(12, 85);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(965, 455);
            this.tabControl1.TabIndex = 2;
            // 
            // tpCourseInfo
            // 
            this.tpCourseInfo.Controls.Add(this.ctrlCourseCardWithFilter1);
            this.tpCourseInfo.Controls.Add(this.btnNext);
            this.tpCourseInfo.Location = new System.Drawing.Point(4, 29);
            this.tpCourseInfo.Name = "tpCourseInfo";
            this.tpCourseInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tpCourseInfo.Size = new System.Drawing.Size(957, 422);
            this.tpCourseInfo.TabIndex = 0;
            this.tpCourseInfo.Text = "Course Info";
            this.tpCourseInfo.UseVisualStyleBackColor = true;
            // 
            // btnNext
            // 
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Image = global::TMS.Properties.Resources.Next_32;
            this.btnNext.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNext.Location = new System.Drawing.Point(805, 365);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(129, 41);
            this.btnNext.TabIndex = 59;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // tpClassroomInfo
            // 
            this.tpClassroomInfo.Controls.Add(this.ctrlClassroomCardWithFilter1);
            this.tpClassroomInfo.Controls.Add(this.btnClassroomInfoNext);
            this.tpClassroomInfo.Location = new System.Drawing.Point(4, 29);
            this.tpClassroomInfo.Name = "tpClassroomInfo";
            this.tpClassroomInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tpClassroomInfo.Size = new System.Drawing.Size(957, 422);
            this.tpClassroomInfo.TabIndex = 1;
            this.tpClassroomInfo.Text = "Classroom Info";
            this.tpClassroomInfo.UseVisualStyleBackColor = true;
            // 
            // btnClassroomInfoNext
            // 
            this.btnClassroomInfoNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClassroomInfoNext.Image = global::TMS.Properties.Resources.Next_32;
            this.btnClassroomInfoNext.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClassroomInfoNext.Location = new System.Drawing.Point(805, 365);
            this.btnClassroomInfoNext.Name = "btnClassroomInfoNext";
            this.btnClassroomInfoNext.Size = new System.Drawing.Size(129, 41);
            this.btnClassroomInfoNext.TabIndex = 60;
            this.btnClassroomInfoNext.Text = "Next";
            this.btnClassroomInfoNext.UseVisualStyleBackColor = true;
            this.btnClassroomInfoNext.Click += new System.EventHandler(this.btnClassroomInfoNext_Click);
            // 
            // tpClassInfo
            // 
            this.tpClassInfo.Controls.Add(this.pictureBox3);
            this.tpClassInfo.Controls.Add(this.pictureBox2);
            this.tpClassInfo.Controls.Add(this.pictureBox1);
            this.tpClassInfo.Controls.Add(this.lbCreationDate);
            this.tpClassInfo.Controls.Add(this.lbCreatedBy);
            this.tpClassInfo.Controls.Add(this.lbSessionID);
            this.tpClassInfo.Controls.Add(this.label3);
            this.tpClassInfo.Controls.Add(this.label2);
            this.tpClassInfo.Controls.Add(this.label1);
            this.tpClassInfo.Location = new System.Drawing.Point(4, 29);
            this.tpClassInfo.Name = "tpClassInfo";
            this.tpClassInfo.Size = new System.Drawing.Size(957, 422);
            this.tpClassInfo.TabIndex = 2;
            this.tpClassInfo.Text = "Class Info";
            this.tpClassInfo.UseVisualStyleBackColor = true;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::TMS.Properties.Resources.Calendar_32;
            this.pictureBox3.Location = new System.Drawing.Point(230, 135);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(32, 32);
            this.pictureBox3.TabIndex = 8;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::TMS.Properties.Resources.User_32__2;
            this.pictureBox2.Location = new System.Drawing.Point(230, 90);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(32, 32);
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::TMS.Properties.Resources.Number_32;
            this.pictureBox1.Location = new System.Drawing.Point(230, 45);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // lbCreationDate
            // 
            this.lbCreationDate.AutoSize = true;
            this.lbCreationDate.Location = new System.Drawing.Point(283, 141);
            this.lbCreationDate.Name = "lbCreationDate";
            this.lbCreationDate.Size = new System.Drawing.Size(44, 20);
            this.lbCreationDate.TabIndex = 5;
            this.lbCreationDate.Text = "[???]";
            // 
            // lbCreatedBy
            // 
            this.lbCreatedBy.AutoSize = true;
            this.lbCreatedBy.Location = new System.Drawing.Point(283, 96);
            this.lbCreatedBy.Name = "lbCreatedBy";
            this.lbCreatedBy.Size = new System.Drawing.Size(44, 20);
            this.lbCreatedBy.TabIndex = 4;
            this.lbCreatedBy.Text = "[???]";
            // 
            // lbSessionID
            // 
            this.lbSessionID.AutoSize = true;
            this.lbSessionID.Location = new System.Drawing.Point(283, 51);
            this.lbSessionID.Name = "lbSessionID";
            this.lbSessionID.Size = new System.Drawing.Size(44, 20);
            this.lbSessionID.TabIndex = 3;
            this.lbSessionID.Text = "[???]";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(82, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 24);
            this.label3.TabIndex = 2;
            this.label3.Text = "Creation Date:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(107, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Created by:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(133, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Class ID:";
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Image = global::TMS.Properties.Resources.Save_32;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(847, 546);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(129, 41);
            this.btnSave.TabIndex = 60;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Image = global::TMS.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(712, 546);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(129, 41);
            this.btnClose.TabIndex = 58;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ctrlCourseCardWithFilter1
            // 
            this.ctrlCourseCardWithFilter1.FilterEnabled = true;
            this.ctrlCourseCardWithFilter1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlCourseCardWithFilter1.Location = new System.Drawing.Point(7, 25);
            this.ctrlCourseCardWithFilter1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ctrlCourseCardWithFilter1.Name = "ctrlCourseCardWithFilter1";
            this.ctrlCourseCardWithFilter1.Size = new System.Drawing.Size(940, 332);
            this.ctrlCourseCardWithFilter1.TabIndex = 60;
            // 
            // ctrlClassroomCardWithFilter1
            // 
            this.ctrlClassroomCardWithFilter1.FilterEnabled = true;
            this.ctrlClassroomCardWithFilter1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlClassroomCardWithFilter1.Location = new System.Drawing.Point(7, 25);
            this.ctrlClassroomCardWithFilter1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ctrlClassroomCardWithFilter1.Name = "ctrlClassroomCardWithFilter1";
            this.ctrlClassroomCardWithFilter1.Size = new System.Drawing.Size(777, 226);
            this.ctrlClassroomCardWithFilter1.TabIndex = 61;
            // 
            // frmAddEditClass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(986, 599);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.lbTitle);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmAddEditClass";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add / Edit Session";
            this.Load += new System.EventHandler(this.frmAddEditClass_Load);
            this.tabControl1.ResumeLayout(false);
            this.tpCourseInfo.ResumeLayout(false);
            this.tpClassroomInfo.ResumeLayout(false);
            this.tpClassInfo.ResumeLayout(false);
            this.tpClassInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpCourseInfo;
        private System.Windows.Forms.TabPage tpClassroomInfo;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TabPage tpClassInfo;
        private System.Windows.Forms.Button btnClassroomInfoNext;
        private ctrlCourseCardWithFilter ctrlCourseCardWithFilter1;
        private Classrooms.ctrlClassroomCardWithFilter ctrlClassroomCardWithFilter1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbCreationDate;
        private System.Windows.Forms.Label lbCreatedBy;
        private System.Windows.Forms.Label lbSessionID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}