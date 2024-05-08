namespace ZWinformsCoreAppCallsMsgraph
{
	partial class FormSignIn
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSignIn));
			label1 = new Label();
			label2 = new Label();
			label3 = new Label();
			label8 = new Label();
			buttonSignIn = new Button();
			buttonSignOut = new Button();
			groupBox1 = new GroupBox();
			radioButtonMethod2 = new RadioButton();
			radioButtonMethod1 = new RadioButton();
			label5 = new Label();
			label4 = new Label();
			groupBox2 = new GroupBox();
			radioButtonScopes2 = new RadioButton();
			radioButtonScopes1 = new RadioButton();
			label10 = new Label();
			pictureBox1 = new PictureBox();
			label14 = new Label();
			label15 = new Label();
			label17 = new Label();
			label6 = new Label();
			panel1 = new Panel();
			label7 = new Label();
			label9 = new Label();
			label11 = new Label();
			groupBox1.SuspendLayout();
			groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label1.Location = new Point(12, 9);
			label1.Name = "label1";
			label1.Size = new Size(608, 25);
			label1.TabIndex = 8;
			label1.Text = "Sample: Call Microsoft Graph from a winforms application (.NET 8).";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
			label2.Location = new Point(12, 48);
			label2.Name = "label2";
			label2.Size = new Size(631, 120);
			label2.TabIndex = 9;
			label2.Text = resources.GetString("label2.Text");
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
			label3.Location = new Point(22, 532);
			label3.Name = "label3";
			label3.Size = new Size(439, 80);
			label3.TabIndex = 12;
			label3.Text = resources.GetString("label3.Text");
			// 
			// label8
			// 
			label8.AutoSize = true;
			label8.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label8.Location = new Point(22, 511);
			label8.Name = "label8";
			label8.Size = new Size(206, 21);
			label8.TabIndex = 19;
			label8.Text = "There are 2 ways to sign in:";
			// 
			// buttonSignIn
			// 
			buttonSignIn.Location = new Point(232, 433);
			buttonSignIn.Name = "buttonSignIn";
			buttonSignIn.Size = new Size(101, 23);
			buttonSignIn.TabIndex = 42;
			buttonSignIn.Text = "Sign-in";
			buttonSignIn.UseVisualStyleBackColor = true;
			buttonSignIn.Click += buttonSignIn_Click;
			// 
			// buttonSignOut
			// 
			buttonSignOut.Location = new Point(232, 467);
			buttonSignOut.Name = "buttonSignOut";
			buttonSignOut.Size = new Size(101, 23);
			buttonSignOut.TabIndex = 41;
			buttonSignOut.Text = "Sign-out";
			buttonSignOut.UseVisualStyleBackColor = true;
			buttonSignOut.Click += buttonSignOut_Click;
			// 
			// groupBox1
			// 
			groupBox1.BackColor = Color.White;
			groupBox1.Controls.Add(radioButtonMethod2);
			groupBox1.Controls.Add(radioButtonMethod1);
			groupBox1.Location = new Point(22, 423);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new Size(187, 85);
			groupBox1.TabIndex = 43;
			groupBox1.TabStop = false;
			groupBox1.Text = "Choose sign-in method";
			// 
			// radioButtonMethod2
			// 
			radioButtonMethod2.AutoSize = true;
			radioButtonMethod2.Location = new Point(28, 48);
			radioButtonMethod2.Name = "radioButtonMethod2";
			radioButtonMethod2.Size = new Size(76, 19);
			radioButtonMethod2.TabIndex = 1;
			radioButtonMethod2.Text = "Method 2";
			radioButtonMethod2.UseVisualStyleBackColor = true;
			// 
			// radioButtonMethod1
			// 
			radioButtonMethod1.AutoSize = true;
			radioButtonMethod1.Checked = true;
			radioButtonMethod1.Location = new Point(28, 23);
			radioButtonMethod1.Name = "radioButtonMethod1";
			radioButtonMethod1.Size = new Size(135, 19);
			radioButtonMethod1.TabIndex = 0;
			radioButtonMethod1.TabStop = true;
			radioButtonMethod1.Text = "Method 1 (preferred)";
			radioButtonMethod1.UseVisualStyleBackColor = true;
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
			label5.ForeColor = Color.DarkViolet;
			label5.Location = new Point(22, 378);
			label5.Name = "label5";
			label5.Size = new Size(391, 40);
			label5.TabIndex = 44;
			label5.Text = "Normally you would not give a choice for sign-in method.\r\nThis demo allows you to experiment with both methods.";
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
			label4.ForeColor = Color.DarkViolet;
			label4.Location = new Point(22, 203);
			label4.Name = "label4";
			label4.Size = new Size(402, 40);
			label4.TabIndex = 46;
			label4.Text = "Permission scopes should be hard-coded in the application.\r\nThis demo allows you to experiment with different scopes.";
			// 
			// groupBox2
			// 
			groupBox2.BackColor = Color.White;
			groupBox2.Controls.Add(radioButtonScopes2);
			groupBox2.Controls.Add(radioButtonScopes1);
			groupBox2.Location = new Point(22, 248);
			groupBox2.Name = "groupBox2";
			groupBox2.Size = new Size(598, 85);
			groupBox2.TabIndex = 45;
			groupBox2.TabStop = false;
			groupBox2.Text = "Scopes";
			// 
			// radioButtonScopes2
			// 
			radioButtonScopes2.AutoSize = true;
			radioButtonScopes2.Location = new Point(28, 48);
			radioButtonScopes2.Name = "radioButtonScopes2";
			radioButtonScopes2.Size = new Size(115, 19);
			radioButtonScopes2.TabIndex = 1;
			radioButtonScopes2.Text = "<In appsettings>";
			radioButtonScopes2.UseVisualStyleBackColor = true;
			// 
			// radioButtonScopes1
			// 
			radioButtonScopes1.AutoSize = true;
			radioButtonScopes1.Checked = true;
			radioButtonScopes1.Location = new Point(28, 23);
			radioButtonScopes1.Name = "radioButtonScopes1";
			radioButtonScopes1.Size = new Size(115, 19);
			radioButtonScopes1.TabIndex = 0;
			radioButtonScopes1.TabStop = true;
			radioButtonScopes1.Text = "<In appsettings>";
			radioButtonScopes1.UseVisualStyleBackColor = true;
			// 
			// label10
			// 
			label10.AutoSize = true;
			label10.Font = new Font("Segoe UI", 9.75F);
			label10.ForeColor = Color.DarkViolet;
			label10.Location = new Point(669, 63);
			label10.Name = "label10";
			label10.Size = new Size(270, 51);
			label10.TabIndex = 48;
			label10.Text = "In Microsoft Entra these group names will be\r\nprefixed with \"DemoGroup\".\r\nEx: DemoGroupStaff";
			// 
			// pictureBox1
			// 
			pictureBox1.Image = Properties.Resources.Entra_Nested_Groups;
			pictureBox1.Location = new Point(669, 153);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new Size(309, 213);
			pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
			pictureBox1.TabIndex = 50;
			pictureBox1.TabStop = false;
			// 
			// label14
			// 
			label14.AutoSize = true;
			label14.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label14.Location = new Point(686, 125);
			label14.Name = "label14";
			label14.Size = new Size(248, 25);
			label14.TabIndex = 51;
			label14.Text = "Group/Subgroup scenario";
			// 
			// label15
			// 
			label15.AutoSize = true;
			label15.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
			label15.ForeColor = Color.DarkViolet;
			label15.Location = new Point(669, 381);
			label15.Name = "label15";
			label15.Size = new Size(425, 187);
			label15.TabIndex = 48;
			label15.Text = resources.GetString("label15.Text");
			// 
			// label17
			// 
			label17.AutoSize = true;
			label17.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
			label17.Location = new Point(984, 82);
			label17.Name = "label17";
			label17.Size = new Size(356, 289);
			label17.TabIndex = 10;
			label17.Text = resources.GetString("label17.Text");
			// 
			// label6
			// 
			label6.AutoSize = true;
			label6.Font = new Font("Segoe UI", 9.75F);
			label6.ForeColor = Color.Blue;
			label6.Location = new Point(669, 582);
			label6.Name = "label6";
			label6.Size = new Size(350, 119);
			label6.TabIndex = 52;
			label6.Text = resources.GetString("label6.Text");
			// 
			// panel1
			// 
			panel1.BackColor = Color.Blue;
			panel1.Location = new Point(649, 12);
			panel1.Name = "panel1";
			panel1.Size = new Size(10, 687);
			panel1.TabIndex = 53;
			// 
			// label7
			// 
			label7.AutoSize = true;
			label7.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label7.Location = new Point(688, 12);
			label7.Name = "label7";
			label7.Size = new Size(203, 25);
			label7.TabIndex = 54;
			label7.Text = "Setup for this tutorial";
			// 
			// label9
			// 
			label9.AutoSize = true;
			label9.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
			label9.ForeColor = Color.Blue;
			label9.Location = new Point(339, 425);
			label9.Name = "label9";
			label9.Size = new Size(206, 42);
			label9.TabIndex = 56;
			label9.Text = "After Setup is complete, use \r\nSign-in to start the tutorial.";
			// 
			// label11
			// 
			label11.AutoSize = true;
			label11.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
			label11.ForeColor = Color.Red;
			label11.Location = new Point(971, 12);
			label11.Name = "label11";
			label11.Size = new Size(404, 60);
			label11.TabIndex = 57;
			label11.Text = "Instructions can be found in the SetupInstructions folder.\r\nSetup can be performed manually or by using the provided \r\nPowershell script (KenSetupWinformCallsMsgraph.ps1).";
			// 
			// FormSignIn
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1384, 711);
			Controls.Add(label11);
			Controls.Add(label9);
			Controls.Add(label7);
			Controls.Add(panel1);
			Controls.Add(label6);
			Controls.Add(label15);
			Controls.Add(label10);
			Controls.Add(label17);
			Controls.Add(label14);
			Controls.Add(pictureBox1);
			Controls.Add(label4);
			Controls.Add(groupBox2);
			Controls.Add(label5);
			Controls.Add(groupBox1);
			Controls.Add(buttonSignIn);
			Controls.Add(buttonSignOut);
			Controls.Add(label8);
			Controls.Add(label3);
			Controls.Add(label2);
			Controls.Add(label1);
			Name = "FormSignIn";
			Text = "FormSignIn";
			Load += FormSignIn_Load;
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			groupBox2.ResumeLayout(false);
			groupBox2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label label1;
		private Label label2;
		private Label label3;
		private Label label8;
		private Button buttonSignIn;
		private Button buttonSignOut;
		private GroupBox groupBox1;
		private RadioButton radioButtonMethod2;
		private RadioButton radioButtonMethod1;
		private Label label5;
		private Label label4;
		private GroupBox groupBox2;
		private RadioButton radioButtonScopes2;
		private RadioButton radioButtonScopes1;
		private Label label10;
		private PictureBox pictureBox1;
		private Label label14;
		private Label label15;
		private Label label17;
		private Label label6;
		private Panel panel1;
		private Label label7;
		private Label label9;
		private Label label11;
	}
}