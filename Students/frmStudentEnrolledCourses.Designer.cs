namespace TMS.Students
{
    partial class frmStudentEnrolledCourses
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
            this.ctrlStudentCard1 = new TMS.Students.ctrlStudentCard();
            this.ctrlStudentEnrolledCourses1 = new TMS.Students.ctrlStudentEnrolledCourses();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ctrlStudentCard1
            // 
            this.ctrlStudentCard1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlStudentCard1.Location = new System.Drawing.Point(13, 14);
            this.ctrlStudentCard1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ctrlStudentCard1.Name = "ctrlStudentCard1";
            this.ctrlStudentCard1.Size = new System.Drawing.Size(919, 318);
            this.ctrlStudentCard1.TabIndex = 0;
            // 
            // ctrlStudentEnrolledCourses1
            // 
            this.ctrlStudentEnrolledCourses1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlStudentEnrolledCourses1.Location = new System.Drawing.Point(13, 342);
            this.ctrlStudentEnrolledCourses1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ctrlStudentEnrolledCourses1.Name = "ctrlStudentEnrolledCourses1";
            this.ctrlStudentEnrolledCourses1.Size = new System.Drawing.Size(899, 366);
            this.ctrlStudentEnrolledCourses1.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Image = global::TMS.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(783, 716);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(129, 41);
            this.btnClose.TabIndex = 53;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmStudentEnrolledCourses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(943, 773);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.ctrlStudentEnrolledCourses1);
            this.Controls.Add(this.ctrlStudentCard1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmStudentEnrolledCourses";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Student\'s Enrolled Courses";
            this.Load += new System.EventHandler(this.frmStudentEnrolledCourses_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlStudentCard ctrlStudentCard1;
        private ctrlStudentEnrolledCourses ctrlStudentEnrolledCourses1;
        private System.Windows.Forms.Button btnClose;
    }
}