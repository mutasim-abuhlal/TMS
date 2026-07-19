namespace TMS.Enrollments
{
    partial class frmAddEditEnrollment
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
            this.tpStudentInfo = new System.Windows.Forms.TabPage();
            this.btnStudentNext = new System.Windows.Forms.Button();
            this.ctrlStudentCardWithFilter1 = new TMS.Students.ctrlStudentCardWithFilter();
            this.tpClassInfo = new System.Windows.Forms.TabPage();
            this.lbCourseNext = new System.Windows.Forms.Button();
            this.tpEnrollmentInfo = new System.Windows.Forms.TabPage();
            this.cbPaymentMethod = new System.Windows.Forms.ComboBox();
            this.lbTotalFees = new System.Windows.Forms.Label();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.lbEnrollDate = new System.Windows.Forms.Label();
            this.lbCreatedBy = new System.Windows.Forms.Label();
            this.lbEnrollmentID = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.ctrlClassCardWithFilter1 = new TMS.Courses.Classes.ctrlClassCardWithFilter();
            this.tabControl1.SuspendLayout();
            this.tpStudentInfo.SuspendLayout();
            this.tpClassInfo.SuspendLayout();
            this.tpEnrollmentInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbTitle
            // 
            this.lbTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbTitle.Location = new System.Drawing.Point(0, 0);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(981, 55);
            this.lbTitle.TabIndex = 46;
            this.lbTitle.Text = "Add New Enrollment";
            this.lbTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpStudentInfo);
            this.tabControl1.Controls.Add(this.tpClassInfo);
            this.tabControl1.Controls.Add(this.tpEnrollmentInfo);
            this.tabControl1.Location = new System.Drawing.Point(12, 81);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(959, 516);
            this.tabControl1.TabIndex = 47;
            // 
            // tpStudentInfo
            // 
            this.tpStudentInfo.Controls.Add(this.btnStudentNext);
            this.tpStudentInfo.Controls.Add(this.ctrlStudentCardWithFilter1);
            this.tpStudentInfo.Location = new System.Drawing.Point(4, 29);
            this.tpStudentInfo.Name = "tpStudentInfo";
            this.tpStudentInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tpStudentInfo.Size = new System.Drawing.Size(951, 483);
            this.tpStudentInfo.TabIndex = 0;
            this.tpStudentInfo.Text = "Student Info";
            this.tpStudentInfo.UseVisualStyleBackColor = true;
            // 
            // btnStudentNext
            // 
            this.btnStudentNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStudentNext.Image = global::TMS.Properties.Resources.Next_32;
            this.btnStudentNext.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnStudentNext.Location = new System.Drawing.Point(808, 425);
            this.btnStudentNext.Name = "btnStudentNext";
            this.btnStudentNext.Size = new System.Drawing.Size(129, 41);
            this.btnStudentNext.TabIndex = 57;
            this.btnStudentNext.Text = "Next";
            this.btnStudentNext.UseVisualStyleBackColor = true;
            this.btnStudentNext.Click += new System.EventHandler(this.btnStudentNext_Click);
            // 
            // ctrlStudentCardWithFilter1
            // 
            this.ctrlStudentCardWithFilter1.FilterEnabled = true;
            this.ctrlStudentCardWithFilter1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlStudentCardWithFilter1.Location = new System.Drawing.Point(6, 8);
            this.ctrlStudentCardWithFilter1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ctrlStudentCardWithFilter1.Name = "ctrlStudentCardWithFilter1";
            this.ctrlStudentCardWithFilter1.Size = new System.Drawing.Size(941, 428);
            this.ctrlStudentCardWithFilter1.TabIndex = 0;
            this.ctrlStudentCardWithFilter1.OnStudentSelected += new TMS.Students.ctrlStudentCardWithFilter.OnStudentSelectedEvent(this.ctrlStudentCardWithFilter1_OnStudentSelected);
            // 
            // tpClassInfo
            // 
            this.tpClassInfo.Controls.Add(this.ctrlClassCardWithFilter1);
            this.tpClassInfo.Controls.Add(this.lbCourseNext);
            this.tpClassInfo.Location = new System.Drawing.Point(4, 29);
            this.tpClassInfo.Name = "tpClassInfo";
            this.tpClassInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tpClassInfo.Size = new System.Drawing.Size(951, 483);
            this.tpClassInfo.TabIndex = 1;
            this.tpClassInfo.Text = "Class Info";
            this.tpClassInfo.UseVisualStyleBackColor = true;
            // 
            // lbCourseNext
            // 
            this.lbCourseNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbCourseNext.Image = global::TMS.Properties.Resources.Next_32;
            this.lbCourseNext.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbCourseNext.Location = new System.Drawing.Point(671, 349);
            this.lbCourseNext.Name = "lbCourseNext";
            this.lbCourseNext.Size = new System.Drawing.Size(129, 41);
            this.lbCourseNext.TabIndex = 57;
            this.lbCourseNext.Text = "Next";
            this.lbCourseNext.UseVisualStyleBackColor = true;
            this.lbCourseNext.Click += new System.EventHandler(this.lbCourseNext_Click);
            // 
            // tpEnrollmentInfo
            // 
            this.tpEnrollmentInfo.Controls.Add(this.cbPaymentMethod);
            this.tpEnrollmentInfo.Controls.Add(this.lbTotalFees);
            this.tpEnrollmentInfo.Controls.Add(this.pictureBox6);
            this.tpEnrollmentInfo.Controls.Add(this.label6);
            this.tpEnrollmentInfo.Controls.Add(this.pictureBox5);
            this.tpEnrollmentInfo.Controls.Add(this.label5);
            this.tpEnrollmentInfo.Controls.Add(this.txtNotes);
            this.tpEnrollmentInfo.Controls.Add(this.lbEnrollDate);
            this.tpEnrollmentInfo.Controls.Add(this.lbCreatedBy);
            this.tpEnrollmentInfo.Controls.Add(this.lbEnrollmentID);
            this.tpEnrollmentInfo.Controls.Add(this.pictureBox3);
            this.tpEnrollmentInfo.Controls.Add(this.pictureBox4);
            this.tpEnrollmentInfo.Controls.Add(this.pictureBox2);
            this.tpEnrollmentInfo.Controls.Add(this.pictureBox1);
            this.tpEnrollmentInfo.Controls.Add(this.label4);
            this.tpEnrollmentInfo.Controls.Add(this.label3);
            this.tpEnrollmentInfo.Controls.Add(this.label2);
            this.tpEnrollmentInfo.Controls.Add(this.label1);
            this.tpEnrollmentInfo.Location = new System.Drawing.Point(4, 29);
            this.tpEnrollmentInfo.Name = "tpEnrollmentInfo";
            this.tpEnrollmentInfo.Size = new System.Drawing.Size(951, 483);
            this.tpEnrollmentInfo.TabIndex = 2;
            this.tpEnrollmentInfo.Text = "Enrollment Info";
            this.tpEnrollmentInfo.UseVisualStyleBackColor = true;
            // 
            // cbPaymentMethod
            // 
            this.cbPaymentMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPaymentMethod.FormattingEnabled = true;
            this.cbPaymentMethod.Location = new System.Drawing.Point(279, 365);
            this.cbPaymentMethod.Name = "cbPaymentMethod";
            this.cbPaymentMethod.Size = new System.Drawing.Size(213, 28);
            this.cbPaymentMethod.TabIndex = 17;
            // 
            // lbTotalFees
            // 
            this.lbTotalFees.AutoSize = true;
            this.lbTotalFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotalFees.Location = new System.Drawing.Point(275, 408);
            this.lbTotalFees.Name = "lbTotalFees";
            this.lbTotalFees.Size = new System.Drawing.Size(60, 24);
            this.lbTotalFees.TabIndex = 16;
            this.lbTotalFees.Text = "[????]";
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = global::TMS.Properties.Resources.money_32;
            this.pictureBox6.Location = new System.Drawing.Point(230, 404);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(32, 32);
            this.pictureBox6.TabIndex = 15;
            this.pictureBox6.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(102, 408);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(115, 24);
            this.label6.TabIndex = 14;
            this.label6.Text = "Total Fees:";
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::TMS.Properties.Resources.paymentmethod32;
            this.pictureBox5.Location = new System.Drawing.Point(230, 361);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(32, 32);
            this.pictureBox5.TabIndex = 13;
            this.pictureBox5.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(45, 365);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(172, 24);
            this.label5.TabIndex = 12;
            this.label5.Text = "Payment Method:";
            // 
            // txtNotes
            // 
            this.txtNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNotes.Location = new System.Drawing.Point(279, 195);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(634, 151);
            this.txtNotes.TabIndex = 11;
            // 
            // lbEnrollDate
            // 
            this.lbEnrollDate.AutoSize = true;
            this.lbEnrollDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEnrollDate.Location = new System.Drawing.Point(275, 155);
            this.lbEnrollDate.Name = "lbEnrollDate";
            this.lbEnrollDate.Size = new System.Drawing.Size(60, 24);
            this.lbEnrollDate.TabIndex = 10;
            this.lbEnrollDate.Text = "[????]";
            // 
            // lbCreatedBy
            // 
            this.lbCreatedBy.AutoSize = true;
            this.lbCreatedBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCreatedBy.Location = new System.Drawing.Point(275, 114);
            this.lbCreatedBy.Name = "lbCreatedBy";
            this.lbCreatedBy.Size = new System.Drawing.Size(60, 24);
            this.lbCreatedBy.TabIndex = 9;
            this.lbCreatedBy.Text = "[????]";
            // 
            // lbEnrollmentID
            // 
            this.lbEnrollmentID.AutoSize = true;
            this.lbEnrollmentID.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEnrollmentID.Location = new System.Drawing.Point(275, 75);
            this.lbEnrollmentID.Name = "lbEnrollmentID";
            this.lbEnrollmentID.Size = new System.Drawing.Size(60, 24);
            this.lbEnrollmentID.TabIndex = 8;
            this.lbEnrollmentID.Text = "[????]";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::TMS.Properties.Resources.Notes_32;
            this.pictureBox3.Location = new System.Drawing.Point(230, 191);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(32, 32);
            this.pictureBox3.TabIndex = 7;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::TMS.Properties.Resources.Calendar_32;
            this.pictureBox4.Location = new System.Drawing.Point(230, 151);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(32, 32);
            this.pictureBox4.TabIndex = 6;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::TMS.Properties.Resources.User_32__2;
            this.pictureBox2.Location = new System.Drawing.Point(230, 110);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(32, 32);
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::TMS.Properties.Resources.Number_32;
            this.pictureBox1.Location = new System.Drawing.Point(230, 71);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(147, 195);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 24);
            this.label4.TabIndex = 3;
            this.label4.Text = "Notes:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(98, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 24);
            this.label3.TabIndex = 2;
            this.label3.Text = "Enroll Date:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(99, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Created By:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(75, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enrollment ID:";
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Image = global::TMS.Properties.Resources.Save_32;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(837, 603);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(129, 41);
            this.btnSave.TabIndex = 59;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Image = global::TMS.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(702, 603);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(129, 41);
            this.btnClose.TabIndex = 58;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ctrlClassCardWithFilter1
            // 
            this.ctrlClassCardWithFilter1.FilterEnabled = true;
            this.ctrlClassCardWithFilter1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlClassCardWithFilter1.Location = new System.Drawing.Point(9, 8);
            this.ctrlClassCardWithFilter1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ctrlClassCardWithFilter1.Name = "ctrlClassCardWithFilter1";
            this.ctrlClassCardWithFilter1.Size = new System.Drawing.Size(806, 339);
            this.ctrlClassCardWithFilter1.TabIndex = 58;
            this.ctrlClassCardWithFilter1.OnSelectedClass += new System.Action<int>(this.ctrlClassCardWithFilter1_OnCourseSelected);
            // 
            // frmAddEditEnrollment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(981, 663);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.lbTitle);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmAddEditEnrollment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add / Edit Enrollment";
            this.Load += new System.EventHandler(this.frmAddEditEnrollment_Load);
            this.tabControl1.ResumeLayout(false);
            this.tpStudentInfo.ResumeLayout(false);
            this.tpClassInfo.ResumeLayout(false);
            this.tpEnrollmentInfo.ResumeLayout(false);
            this.tpEnrollmentInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpStudentInfo;
        private System.Windows.Forms.TabPage tpClassInfo;
        private Students.ctrlStudentCardWithFilter ctrlStudentCardWithFilter1;
        private System.Windows.Forms.TabPage tpEnrollmentInfo;
        private System.Windows.Forms.Button btnStudentNext;
        private System.Windows.Forms.Button lbCourseNext;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbEnrollDate;
        private System.Windows.Forms.Label lbCreatedBy;
        private System.Windows.Forms.Label lbEnrollmentID;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.ComboBox cbPaymentMethod;
        private System.Windows.Forms.Label lbTotalFees;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Label label5;
        private Courses.Classes.ctrlClassCardWithFilter ctrlClassCardWithFilter1;
    }
}