namespace ZWinformsCoreAppCallsMsgraph
{
	partial class FormMain
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
			label1 = new Label();
			label5 = new Label();
			listBoxMeTransitiveMemberOf = new ListBox();
			label4 = new Label();
			listBoxMeDirectMemberOf = new ListBox();
			textBoxUserPrincipalName = new TextBox();
			label3 = new Label();
			textBoxDisplayName = new TextBox();
			label8 = new Label();
			label17 = new Label();
			label18 = new Label();
			panel2 = new Panel();
			label19 = new Label();
			buttonExperimentWithGraphReadOnly = new Button();
			buttonDebugIdToken = new Button();
			label2 = new Label();
			panel1 = new Panel();
			label11 = new Label();
			label6 = new Label();
			buttonStaffTask = new Button();
			label7 = new Label();
			label9 = new Label();
			buttonMarketingTask = new Button();
			buttonBillingTask = new Button();
			buttonAppealsTask = new Button();
			panel3 = new Panel();
			label10 = new Label();
			buttonAdminTask = new Button();
			label15 = new Label();
			label14 = new Label();
			label13 = new Label();
			pictureBox1 = new PictureBox();
			label12 = new Label();
			panel2.SuspendLayout();
			panel1.SuspendLayout();
			panel3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label1.Location = new Point(12, 9);
			label1.Name = "label1";
			label1.Size = new Size(238, 25);
			label1.TabIndex = 9;
			label1.Text = "Main form (after Sign-In)";
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.Location = new Point(811, 303);
			label5.Name = "label5";
			label5.Size = new Size(247, 15);
			label5.TabIndex = 74;
			label5.Text = "Signed-in user is transitive member of groups";
			// 
			// listBoxMeTransitiveMemberOf
			// 
			listBoxMeTransitiveMemberOf.FormattingEnabled = true;
			listBoxMeTransitiveMemberOf.ItemHeight = 15;
			listBoxMeTransitiveMemberOf.Location = new Point(811, 321);
			listBoxMeTransitiveMemberOf.Name = "listBoxMeTransitiveMemberOf";
			listBoxMeTransitiveMemberOf.Size = new Size(248, 79);
			listBoxMeTransitiveMemberOf.TabIndex = 73;
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Location = new Point(557, 303);
			label4.Name = "label4";
			label4.Size = new Size(229, 15);
			label4.TabIndex = 72;
			label4.Text = "Signed-in user is direct member of groups";
			// 
			// listBoxMeDirectMemberOf
			// 
			listBoxMeDirectMemberOf.FormattingEnabled = true;
			listBoxMeDirectMemberOf.ItemHeight = 15;
			listBoxMeDirectMemberOf.Location = new Point(557, 321);
			listBoxMeDirectMemberOf.Name = "listBoxMeDirectMemberOf";
			listBoxMeDirectMemberOf.Size = new Size(248, 79);
			listBoxMeDirectMemberOf.TabIndex = 71;
			// 
			// textBoxUserPrincipalName
			// 
			textBoxUserPrincipalName.Location = new Point(133, 95);
			textBoxUserPrincipalName.Name = "textBoxUserPrincipalName";
			textBoxUserPrincipalName.ReadOnly = true;
			textBoxUserPrincipalName.Size = new Size(298, 23);
			textBoxUserPrincipalName.TabIndex = 70;
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new Point(14, 98);
			label3.Name = "label3";
			label3.Size = new Size(111, 15);
			label3.TabIndex = 69;
			label3.Text = "UserPrincipalName:";
			// 
			// textBoxDisplayName
			// 
			textBoxDisplayName.Location = new Point(133, 66);
			textBoxDisplayName.Name = "textBoxDisplayName";
			textBoxDisplayName.ReadOnly = true;
			textBoxDisplayName.Size = new Size(298, 23);
			textBoxDisplayName.TabIndex = 68;
			// 
			// label8
			// 
			label8.AutoSize = true;
			label8.Location = new Point(47, 69);
			label8.Name = "label8";
			label8.Size = new Size(80, 15);
			label8.TabIndex = 67;
			label8.Text = "DisplayName:";
			// 
			// label17
			// 
			label17.AutoSize = true;
			label17.Location = new Point(133, 48);
			label17.Name = "label17";
			label17.Size = new Size(268, 15);
			label17.TabIndex = 87;
			label17.Text = "Signed-In User Information from Microsoft Graph";
			// 
			// label18
			// 
			label18.AutoSize = true;
			label18.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
			label18.ForeColor = Color.Blue;
			label18.Location = new Point(14, 12);
			label18.Name = "label18";
			label18.Size = new Size(491, 21);
			label18.TabIndex = 88;
			label18.Text = "After sign-in, the information below is stored in class, UserAuthStatus.";
			// 
			// panel2
			// 
			panel2.BorderStyle = BorderStyle.FixedSingle;
			panel2.Controls.Add(label19);
			panel2.Controls.Add(label18);
			panel2.Controls.Add(label8);
			panel2.Controls.Add(label17);
			panel2.Controls.Add(textBoxDisplayName);
			panel2.Controls.Add(label3);
			panel2.Controls.Add(textBoxUserPrincipalName);
			panel2.Location = new Point(12, 41);
			panel2.Name = "panel2";
			panel2.Size = new Size(530, 260);
			panel2.TabIndex = 89;
			// 
			// label19
			// 
			label19.AutoSize = true;
			label19.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
			label19.ForeColor = Color.Blue;
			label19.Location = new Point(14, 138);
			label19.Name = "label19";
			label19.Size = new Size(415, 105);
			label19.TabIndex = 89;
			label19.Text = resources.GetString("label19.Text");
			// 
			// buttonExperimentWithGraphReadOnly
			// 
			buttonExperimentWithGraphReadOnly.Location = new Point(33, 36);
			buttonExperimentWithGraphReadOnly.Name = "buttonExperimentWithGraphReadOnly";
			buttonExperimentWithGraphReadOnly.Size = new Size(163, 23);
			buttonExperimentWithGraphReadOnly.TabIndex = 90;
			buttonExperimentWithGraphReadOnly.Text = "Experiment with Graph";
			buttonExperimentWithGraphReadOnly.UseVisualStyleBackColor = true;
			buttonExperimentWithGraphReadOnly.Click += buttonExperimentWithGraph_Click;
			// 
			// buttonDebugIdToken
			// 
			buttonDebugIdToken.Location = new Point(33, 109);
			buttonDebugIdToken.Name = "buttonDebugIdToken";
			buttonDebugIdToken.Size = new Size(163, 23);
			buttonDebugIdToken.TabIndex = 91;
			buttonDebugIdToken.Text = "Debug Id Token";
			buttonDebugIdToken.UseVisualStyleBackColor = true;
			buttonDebugIdToken.Click += buttonDebugIdToken_Click;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label2.Location = new Point(14, 12);
			label2.Name = "label2";
			label2.Size = new Size(262, 30);
			label2.TabIndex = 90;
			label2.Text = "Primary Tutorial Objective \r\nIllustrate authorization via group membership";
			// 
			// panel1
			// 
			panel1.BorderStyle = BorderStyle.FixedSingle;
			panel1.Controls.Add(label11);
			panel1.Controls.Add(label6);
			panel1.Controls.Add(buttonExperimentWithGraphReadOnly);
			panel1.Controls.Add(buttonDebugIdToken);
			panel1.Location = new Point(872, 87);
			panel1.Name = "panel1";
			panel1.Size = new Size(350, 149);
			panel1.TabIndex = 94;
			// 
			// label11
			// 
			label11.AutoSize = true;
			label11.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label11.Location = new Point(14, 85);
			label11.Name = "label11";
			label11.Size = new Size(284, 15);
			label11.TabIndex = 96;
			label11.Text = "Tutorial Objective #3: Study Entra Security Tokens";
			// 
			// label6
			// 
			label6.AutoSize = true;
			label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label6.Location = new Point(14, 12);
			label6.Name = "label6";
			label6.Size = new Size(292, 15);
			label6.TabIndex = 95;
			label6.Text = "Tutorial Objective #2: Microsoft Graph sample code";
			// 
			// buttonStaffTask
			// 
			buttonStaffTask.Location = new Point(14, 54);
			buttonStaffTask.Name = "buttonStaffTask";
			buttonStaffTask.Size = new Size(93, 23);
			buttonStaffTask.TabIndex = 95;
			buttonStaffTask.Text = "Staff task";
			buttonStaffTask.UseVisualStyleBackColor = true;
			buttonStaffTask.Click += buttonStaffTask_Click;
			// 
			// label7
			// 
			label7.AutoSize = true;
			label7.Location = new Point(113, 58);
			label7.Name = "label7";
			label7.Size = new Size(133, 15);
			label7.TabIndex = 96;
			label7.Text = "Every user is authorized.";
			// 
			// label9
			// 
			label9.AutoSize = true;
			label9.Location = new Point(113, 90);
			label9.Name = "label9";
			label9.Size = new Size(229, 15);
			label9.TabIndex = 97;
			label9.Text = "Ed, Kenadmin, and Kellette are authorized.";
			// 
			// buttonMarketingTask
			// 
			buttonMarketingTask.Location = new Point(14, 86);
			buttonMarketingTask.Name = "buttonMarketingTask";
			buttonMarketingTask.Size = new Size(93, 23);
			buttonMarketingTask.TabIndex = 98;
			buttonMarketingTask.Text = "Marketing task";
			buttonMarketingTask.UseVisualStyleBackColor = true;
			buttonMarketingTask.Click += buttonMarketingTask_Click;
			// 
			// buttonBillingTask
			// 
			buttonBillingTask.Location = new Point(14, 118);
			buttonBillingTask.Name = "buttonBillingTask";
			buttonBillingTask.Size = new Size(93, 23);
			buttonBillingTask.TabIndex = 100;
			buttonBillingTask.Text = "Billing task";
			buttonBillingTask.UseVisualStyleBackColor = true;
			buttonBillingTask.Click += buttonBillingTask_Click;
			// 
			// buttonAppealsTask
			// 
			buttonAppealsTask.Location = new Point(14, 150);
			buttonAppealsTask.Name = "buttonAppealsTask";
			buttonAppealsTask.Size = new Size(93, 23);
			buttonAppealsTask.TabIndex = 102;
			buttonAppealsTask.Text = "Appeals task";
			buttonAppealsTask.UseVisualStyleBackColor = true;
			buttonAppealsTask.Click += buttonAppealsTask_Click;
			// 
			// panel3
			// 
			panel3.BorderStyle = BorderStyle.FixedSingle;
			panel3.Controls.Add(label10);
			panel3.Controls.Add(buttonAdminTask);
			panel3.Controls.Add(label15);
			panel3.Controls.Add(label14);
			panel3.Controls.Add(label2);
			panel3.Controls.Add(buttonStaffTask);
			panel3.Controls.Add(buttonAppealsTask);
			panel3.Controls.Add(label7);
			panel3.Controls.Add(buttonBillingTask);
			panel3.Controls.Add(buttonMarketingTask);
			panel3.Controls.Add(label9);
			panel3.Location = new Point(12, 307);
			panel3.Name = "panel3";
			panel3.Size = new Size(370, 226);
			panel3.TabIndex = 104;
			// 
			// label10
			// 
			label10.AutoSize = true;
			label10.Location = new Point(113, 188);
			label10.Name = "label10";
			label10.Size = new Size(181, 15);
			label10.TabIndex = 106;
			label10.Text = "Ed and Kenadmin are authorized.";
			// 
			// buttonAdminTask
			// 
			buttonAdminTask.Location = new Point(14, 184);
			buttonAdminTask.Name = "buttonAdminTask";
			buttonAdminTask.Size = new Size(93, 23);
			buttonAdminTask.TabIndex = 105;
			buttonAdminTask.Text = "Admin task";
			buttonAdminTask.UseVisualStyleBackColor = true;
			buttonAdminTask.Click += buttonAdminTask_Click;
			// 
			// label15
			// 
			label15.AutoSize = true;
			label15.Location = new Point(113, 154);
			label15.Name = "label15";
			label15.Size = new Size(220, 15);
			label15.TabIndex = 104;
			label15.Text = "Ed, Kenadmin, and Kathy are authorized.";
			// 
			// label14
			// 
			label14.AutoSize = true;
			label14.Location = new Point(113, 122);
			label14.Name = "label14";
			label14.Size = new Size(252, 15);
			label14.TabIndex = 103;
			label14.Text = "Ed, Kenadmin, Karla, and Kathy are authorized.";
			// 
			// label13
			// 
			label13.AutoSize = true;
			label13.Font = new Font("Segoe UI", 9.75F);
			label13.ForeColor = Color.Blue;
			label13.Location = new Point(398, 414);
			label13.Name = "label13";
			label13.Size = new Size(350, 119);
			label13.TabIndex = 105;
			label13.Text = resources.GetString("label13.Text");
			// 
			// pictureBox1
			// 
			pictureBox1.Image = Properties.Resources.Entra_Nested_Groups;
			pictureBox1.Location = new Point(557, 87);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new Size(309, 213);
			pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
			pictureBox1.TabIndex = 106;
			pictureBox1.TabStop = false;
			// 
			// label12
			// 
			label12.AutoSize = true;
			label12.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
			label12.ForeColor = Color.DarkViolet;
			label12.Location = new Point(557, 33);
			label12.Name = "label12";
			label12.Size = new Size(615, 42);
			label12.TabIndex = 90;
			label12.Text = "Note that I prefer to avoid subgroups in my environment, but this tutorial demonstrates\r\nhow subgroups can be used for authorization (using transitive group membership). ";
			// 
			// FormMain
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1234, 561);
			Controls.Add(label12);
			Controls.Add(pictureBox1);
			Controls.Add(label13);
			Controls.Add(panel3);
			Controls.Add(panel1);
			Controls.Add(panel2);
			Controls.Add(label1);
			Controls.Add(label5);
			Controls.Add(listBoxMeDirectMemberOf);
			Controls.Add(listBoxMeTransitiveMemberOf);
			Controls.Add(label4);
			Name = "FormMain";
			Text = "FormMain";
			Load += FormMain_Load;
			panel2.ResumeLayout(false);
			panel2.PerformLayout();
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			panel3.ResumeLayout(false);
			panel3.PerformLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label label1;
		private Label label5;
		private ListBox listBoxMeTransitiveMemberOf;
		private Label label4;
		private ListBox listBoxMeDirectMemberOf;
		private TextBox textBoxUserPrincipalName;
		private Label label3;
		private TextBox textBoxDisplayName;
		private Label label8;
		private Label label17;
		private Label label18;
		private Panel panel2;
		private Label label19;
		private Button buttonExperimentWithGraphReadOnly;
		private Button buttonDebugIdToken;
		private Label label2;
		private Panel panel1;
		private Label label6;
		private Button buttonStaffTask;
		private Label label7;
		private Label label9;
		private Button buttonMarketingTask;
		private Button buttonBillingTask;
		private Button buttonAppealsTask;
		private Panel panel3;
		private Label label13;
		private Label label10;
		private Button buttonAdminTask;
		private Label label15;
		private Label label14;
		private PictureBox pictureBox1;
		private Label label11;
		private Label label12;
	}
}