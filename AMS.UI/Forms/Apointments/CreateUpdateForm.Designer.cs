namespace AMS.UI.Forms.Appointments
{
    partial class CreateUpdateForm
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
            this.lblCustomerNameError = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblTitleError = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblDescriptionError = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblLocationError = new System.Windows.Forms.Label();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblContactError = new System.Windows.Forms.Label();
            this.txtContact = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblTypeError = new System.Windows.Forms.Label();
            this.txtType = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.cmbCustomerNames = new System.Windows.Forms.ComboBox();
            this.dtpStartTime = new System.Windows.Forms.DateTimePicker();
            this.lblURLError = new System.Windows.Forms.Label();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lblStartTimeError = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblEndTimeError = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.dtpEndTime = new System.Windows.Forms.DateTimePicker();
            this.cmbConsultant = new System.Windows.Forms.ComboBox();
            this.lblConsultantError = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblCustomerNameError
            // 
            this.lblCustomerNameError.AutoSize = true;
            this.lblCustomerNameError.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerNameError.ForeColor = System.Drawing.Color.Red;
            this.lblCustomerNameError.Location = new System.Drawing.Point(8, 119);
            this.lblCustomerNameError.Name = "lblCustomerNameError";
            this.lblCustomerNameError.Size = new System.Drawing.Size(124, 21);
            this.lblCustomerNameError.TabIndex = 10;
            this.lblCustomerNameError.Text = "Customer Name";
            this.lblCustomerNameError.Visible = false;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.Location = new System.Drawing.Point(8, 63);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(128, 21);
            this.lblUsername.TabIndex = 8;
            this.lblUsername.Text = "Customer Name";
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(615, 40);
            this.lblTitle.TabIndex = 11;
            this.lblTitle.Text = "Form Title";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTitleError
            // 
            this.lblTitleError.AutoSize = true;
            this.lblTitleError.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitleError.ForeColor = System.Drawing.Color.Red;
            this.lblTitleError.Location = new System.Drawing.Point(12, 292);
            this.lblTitleError.Name = "lblTitleError";
            this.lblTitleError.Size = new System.Drawing.Size(124, 21);
            this.lblTitleError.TabIndex = 14;
            this.lblTitleError.Text = "Customer Name";
            this.lblTitleError.Visible = false;
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(16, 260);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(575, 29);
            this.txtTitle.TabIndex = 1;
            this.txtTitle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTitle.TextChanged += new System.EventHandler(this.txtTitle_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 236);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 21);
            this.label2.TabIndex = 12;
            this.label2.Text = "Title";
            // 
            // lblDescriptionError
            // 
            this.lblDescriptionError.AutoSize = true;
            this.lblDescriptionError.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescriptionError.ForeColor = System.Drawing.Color.Red;
            this.lblDescriptionError.Location = new System.Drawing.Point(12, 384);
            this.lblDescriptionError.Name = "lblDescriptionError";
            this.lblDescriptionError.Size = new System.Drawing.Size(91, 21);
            this.lblDescriptionError.TabIndex = 17;
            this.lblDescriptionError.Text = "Postal Code";
            this.lblDescriptionError.Visible = false;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(16, 352);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(575, 29);
            this.txtDescription.TabIndex = 2;
            this.txtDescription.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDescription.TextChanged += new System.EventHandler(this.txtDescription_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 328);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 21);
            this.label3.TabIndex = 15;
            this.label3.Text = "Description";
            // 
            // lblLocationError
            // 
            this.lblLocationError.AutoSize = true;
            this.lblLocationError.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocationError.ForeColor = System.Drawing.Color.Red;
            this.lblLocationError.Location = new System.Drawing.Point(12, 473);
            this.lblLocationError.Name = "lblLocationError";
            this.lblLocationError.Size = new System.Drawing.Size(37, 21);
            this.lblLocationError.TabIndex = 20;
            this.lblLocationError.Text = "City";
            this.lblLocationError.Visible = false;
            // 
            // txtLocation
            // 
            this.txtLocation.Location = new System.Drawing.Point(16, 441);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(575, 29);
            this.txtLocation.TabIndex = 3;
            this.txtLocation.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtLocation.TextChanged += new System.EventHandler(this.txtLocation_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 417);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 21);
            this.label4.TabIndex = 18;
            this.label4.Text = "Location";
            // 
            // lblContactError
            // 
            this.lblContactError.AutoSize = true;
            this.lblContactError.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContactError.ForeColor = System.Drawing.Color.Red;
            this.lblContactError.Location = new System.Drawing.Point(12, 565);
            this.lblContactError.Name = "lblContactError";
            this.lblContactError.Size = new System.Drawing.Size(66, 21);
            this.lblContactError.TabIndex = 23;
            this.lblContactError.Text = "Country";
            this.lblContactError.Visible = false;
            // 
            // txtContact
            // 
            this.txtContact.Location = new System.Drawing.Point(16, 533);
            this.txtContact.Name = "txtContact";
            this.txtContact.Size = new System.Drawing.Size(575, 29);
            this.txtContact.TabIndex = 4;
            this.txtContact.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtContact.TextChanged += new System.EventHandler(this.txtContact_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 509);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 21);
            this.label5.TabIndex = 21;
            this.label5.Text = "Contact";
            // 
            // lblTypeError
            // 
            this.lblTypeError.AutoSize = true;
            this.lblTypeError.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTypeError.ForeColor = System.Drawing.Color.Red;
            this.lblTypeError.Location = new System.Drawing.Point(12, 661);
            this.lblTypeError.Name = "lblTypeError";
            this.lblTypeError.Size = new System.Drawing.Size(116, 21);
            this.lblTypeError.TabIndex = 26;
            this.lblTypeError.Text = "Phone Number";
            this.lblTypeError.Visible = false;
            // 
            // txtType
            // 
            this.txtType.Location = new System.Drawing.Point(16, 629);
            this.txtType.Name = "txtType";
            this.txtType.Size = new System.Drawing.Size(575, 29);
            this.txtType.TabIndex = 5;
            this.txtType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtType.TextChanged += new System.EventHandler(this.txtType_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 605);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 21);
            this.label6.TabIndex = 24;
            this.label6.Text = "Type";
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.White;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Location = new System.Drawing.Point(283, 971);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(91, 37);
            this.btnReset.TabIndex = 28;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.White;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.Location = new System.Drawing.Point(174, 971);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(91, 37);
            this.btnLogin.TabIndex = 27;
            this.btnLogin.Text = "Save";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // cmbCustomerNames
            // 
            this.cmbCustomerNames.FormattingEnabled = true;
            this.cmbCustomerNames.Location = new System.Drawing.Point(12, 87);
            this.cmbCustomerNames.Name = "cmbCustomerNames";
            this.cmbCustomerNames.Size = new System.Drawing.Size(575, 29);
            this.cmbCustomerNames.Sorted = true;
            this.cmbCustomerNames.TabIndex = 0;
            this.cmbCustomerNames.SelectedIndexChanged += new System.EventHandler(this.cmbCustomerNames_SelectedIndexChanged);
            // 
            // dtpStartTime
            // 
            this.dtpStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpStartTime.Location = new System.Drawing.Point(16, 813);
            this.dtpStartTime.Name = "dtpStartTime";
            this.dtpStartTime.Size = new System.Drawing.Size(575, 29);
            this.dtpStartTime.TabIndex = 7;
            this.dtpStartTime.ValueChanged += new System.EventHandler(this.dtpStartTime_ValueChanged);
            // 
            // lblURLError
            // 
            this.lblURLError.AutoSize = true;
            this.lblURLError.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblURLError.ForeColor = System.Drawing.Color.Red;
            this.lblURLError.Location = new System.Drawing.Point(12, 756);
            this.lblURLError.Name = "lblURLError";
            this.lblURLError.Size = new System.Drawing.Size(116, 21);
            this.lblURLError.TabIndex = 33;
            this.lblURLError.Text = "Phone Number";
            this.lblURLError.Visible = false;
            // 
            // txtURL
            // 
            this.txtURL.Location = new System.Drawing.Point(16, 724);
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(575, 29);
            this.txtURL.TabIndex = 6;
            this.txtURL.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtURL.TextChanged += new System.EventHandler(this.txtURL_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(12, 700);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 21);
            this.label7.TabIndex = 31;
            this.label7.Text = "URL";
            // 
            // lblStartTimeError
            // 
            this.lblStartTimeError.AutoSize = true;
            this.lblStartTimeError.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStartTimeError.ForeColor = System.Drawing.Color.Red;
            this.lblStartTimeError.Location = new System.Drawing.Point(12, 845);
            this.lblStartTimeError.Name = "lblStartTimeError";
            this.lblStartTimeError.Size = new System.Drawing.Size(116, 21);
            this.lblStartTimeError.TabIndex = 36;
            this.lblStartTimeError.Text = "Phone Number";
            this.lblStartTimeError.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(12, 789);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(85, 21);
            this.label9.TabIndex = 34;
            this.label9.Text = "Start Time";
            // 
            // lblEndTimeError
            // 
            this.lblEndTimeError.AutoSize = true;
            this.lblEndTimeError.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEndTimeError.ForeColor = System.Drawing.Color.Red;
            this.lblEndTimeError.Location = new System.Drawing.Point(12, 937);
            this.lblEndTimeError.Name = "lblEndTimeError";
            this.lblEndTimeError.Size = new System.Drawing.Size(116, 21);
            this.lblEndTimeError.TabIndex = 39;
            this.lblEndTimeError.Text = "Phone Number";
            this.lblEndTimeError.Visible = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(12, 881);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 21);
            this.label11.TabIndex = 38;
            this.label11.Text = "End Time";
            // 
            // dtpEndTime
            // 
            this.dtpEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpEndTime.Location = new System.Drawing.Point(16, 905);
            this.dtpEndTime.Name = "dtpEndTime";
            this.dtpEndTime.Size = new System.Drawing.Size(575, 29);
            this.dtpEndTime.TabIndex = 8;
            this.dtpEndTime.ValueChanged += new System.EventHandler(this.dtpEndTime_ValueChanged);
            // 
            // cmbConsultant
            // 
            this.cmbConsultant.FormattingEnabled = true;
            this.cmbConsultant.Location = new System.Drawing.Point(16, 175);
            this.cmbConsultant.Name = "cmbConsultant";
            this.cmbConsultant.Size = new System.Drawing.Size(575, 29);
            this.cmbConsultant.Sorted = true;
            this.cmbConsultant.TabIndex = 40;
            this.cmbConsultant.SelectedIndexChanged += new System.EventHandler(this.cmbConsultant_SelectedIndexChanged);
            // 
            // lblConsultantError
            // 
            this.lblConsultantError.AutoSize = true;
            this.lblConsultantError.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConsultantError.ForeColor = System.Drawing.Color.Red;
            this.lblConsultantError.Location = new System.Drawing.Point(12, 207);
            this.lblConsultantError.Name = "lblConsultantError";
            this.lblConsultantError.Size = new System.Drawing.Size(124, 21);
            this.lblConsultantError.TabIndex = 42;
            this.lblConsultantError.Text = "Customer Name";
            this.lblConsultantError.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(12, 151);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(135, 21);
            this.label8.TabIndex = 41;
            this.label8.Text = "Consultant Name";
            // 
            // CreateUpdateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(615, 1026);
            this.Controls.Add(this.cmbConsultant);
            this.Controls.Add(this.lblConsultantError);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblEndTimeError);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.dtpEndTime);
            this.Controls.Add(this.lblStartTimeError);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lblURLError);
            this.Controls.Add(this.txtURL);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dtpStartTime);
            this.Controls.Add(this.cmbCustomerNames);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.lblTypeError);
            this.Controls.Add(this.txtType);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblContactError);
            this.Controls.Add(this.txtContact);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblLocationError);
            this.Controls.Add(this.txtLocation);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblDescriptionError);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblTitleError);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblCustomerNameError);
            this.Controls.Add(this.lblUsername);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CreateUpdateForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCustomerNameError;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblTitleError;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblDescriptionError;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblLocationError;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblContactError;
        private System.Windows.Forms.TextBox txtContact;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblTypeError;
        private System.Windows.Forms.TextBox txtType;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.ComboBox cmbCustomerNames;
        private System.Windows.Forms.DateTimePicker dtpStartTime;
        private System.Windows.Forms.Label lblURLError;
        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblStartTimeError;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblEndTimeError;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker dtpEndTime;
        private System.Windows.Forms.ComboBox cmbConsultant;
        private System.Windows.Forms.Label lblConsultantError;
        private System.Windows.Forms.Label label8;
    }
}