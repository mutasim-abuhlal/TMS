namespace TMS.Payments
{
    partial class frmStudentPaymentsList
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
            this.ctrlStudentPayments1 = new TMS.Payments.ctrlStudentPayments();
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
            // ctrlStudentPayments1
            // 
            this.ctrlStudentPayments1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlStudentPayments1.Location = new System.Drawing.Point(13, 349);
            this.ctrlStudentPayments1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ctrlStudentPayments1.Name = "ctrlStudentPayments1";
            this.ctrlStudentPayments1.Size = new System.Drawing.Size(899, 366);
            this.ctrlStudentPayments1.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Image = global::TMS.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(783, 723);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(129, 41);
            this.btnClose.TabIndex = 53;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmStudentPaymentsList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(946, 779);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.ctrlStudentPayments1);
            this.Controls.Add(this.ctrlStudentCard1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmStudentPaymentsList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Student\'s Payments List";
            this.Load += new System.EventHandler(this.frmStudentPaymentsList_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Students.ctrlStudentCard ctrlStudentCard1;
        private ctrlStudentPayments ctrlStudentPayments1;
        private System.Windows.Forms.Button btnClose;
    }
}