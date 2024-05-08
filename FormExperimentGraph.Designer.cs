namespace ZWinformsCoreAppCallsMsgraph
{
	partial class FormExperimentGraph
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormExperimentGraph));
			label1 = new Label();
			label2 = new Label();
			buttonProceed = new Button();
			buttonCancel = new Button();
			panelEntireScreen = new Panel();
			panel2 = new Panel();
			label24 = new Label();
			label23 = new Label();
			textBoxPasswordForCreateUser = new TextBox();
			textBox2 = new TextBox();
			label22 = new Label();
			textBoxNameForCreateUser = new TextBox();
			label21 = new Label();
			label20 = new Label();
			label19 = new Label();
			comboBoxCreateGroupOwner = new ComboBox();
			label18 = new Label();
			textBoxCreateGroupName = new TextBox();
			label17 = new Label();
			label15 = new Label();
			textBoxCreateGroupDesc = new TextBox();
			label14 = new Label();
			label7 = new Label();
			comboBoxGroupsForAddUserToGroup = new ComboBox();
			comboBoxUsersForAddToGroup = new ComboBox();
			buttonCreateUser = new Button();
			buttonCreateGroup = new Button();
			buttonAddUserToGroup = new Button();
			label6 = new Label();
			label5 = new Label();
			panel3 = new Panel();
			label8 = new Label();
			comboBoxUsers = new ComboBox();
			label9 = new Label();
			listBoxUserIsTransitiveMemberOf = new ListBox();
			label13 = new Label();
			listBoxUserIsDirectMemberOf = new ListBox();
			label4 = new Label();
			label3 = new Label();
			treeView1 = new TreeView();
			dataGridView1 = new DataGridView();
			Column_GroupName = new DataGridViewTextBoxColumn();
			Column_DirectMembers = new DataGridViewTextBoxColumn();
			panel1 = new Panel();
			label12 = new Label();
			comboBoxGroups = new ComboBox();
			label10 = new Label();
			listBoxTransitiveMembersOfSelectedGroup = new ListBox();
			label11 = new Label();
			listBoxDirectMembersOfSelectedGroup = new ListBox();
			label16 = new Label();
			textBoxSignedInUserPrincipalName = new TextBox();
			panelEntireScreen.SuspendLayout();
			panel2.SuspendLayout();
			panel3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
			panel1.SuspendLayout();
			SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label1.Location = new Point(12, 9);
			label1.Name = "label1";
			label1.Size = new Size(507, 21);
			label1.TabIndex = 86;
			label1.Text = "Experiment with Microsoft Graph using GraphServiceClient (SDK)";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label2.ForeColor = Color.Red;
			label2.Location = new Point(28, 40);
			label2.Name = "label2";
			label2.Size = new Size(652, 21);
			label2.TabIndex = 87;
			label2.Text = "This is meant for demo on a system with less than a dozen users and a dozen groups.\r\n";
			// 
			// buttonProceed
			// 
			buttonProceed.Location = new Point(699, 40);
			buttonProceed.Name = "buttonProceed";
			buttonProceed.Size = new Size(75, 23);
			buttonProceed.TabIndex = 88;
			buttonProceed.TabStop = false;
			buttonProceed.Text = "Proceed";
			buttonProceed.UseVisualStyleBackColor = true;
			buttonProceed.Click += buttonProceed_Click;
			// 
			// buttonCancel
			// 
			buttonCancel.DialogResult = DialogResult.Cancel;
			buttonCancel.Location = new Point(804, 40);
			buttonCancel.Name = "buttonCancel";
			buttonCancel.Size = new Size(75, 23);
			buttonCancel.TabIndex = 89;
			buttonCancel.TabStop = false;
			buttonCancel.Text = "Cancel";
			buttonCancel.UseVisualStyleBackColor = true;
			// 
			// panelEntireScreen
			// 
			panelEntireScreen.Controls.Add(panel2);
			panelEntireScreen.Controls.Add(panel3);
			panelEntireScreen.Controls.Add(label4);
			panelEntireScreen.Controls.Add(label3);
			panelEntireScreen.Controls.Add(treeView1);
			panelEntireScreen.Controls.Add(dataGridView1);
			panelEntireScreen.Controls.Add(panel1);
			panelEntireScreen.Location = new Point(12, 75);
			panelEntireScreen.Name = "panelEntireScreen";
			panelEntireScreen.Size = new Size(1340, 725);
			panelEntireScreen.TabIndex = 94;
			panelEntireScreen.Visible = false;
			// 
			// panel2
			// 
			panel2.BorderStyle = BorderStyle.FixedSingle;
			panel2.Controls.Add(label24);
			panel2.Controls.Add(label23);
			panel2.Controls.Add(textBoxPasswordForCreateUser);
			panel2.Controls.Add(textBox2);
			panel2.Controls.Add(label22);
			panel2.Controls.Add(textBoxNameForCreateUser);
			panel2.Controls.Add(label21);
			panel2.Controls.Add(label20);
			panel2.Controls.Add(label19);
			panel2.Controls.Add(comboBoxCreateGroupOwner);
			panel2.Controls.Add(label18);
			panel2.Controls.Add(textBoxCreateGroupName);
			panel2.Controls.Add(label17);
			panel2.Controls.Add(label15);
			panel2.Controls.Add(textBoxCreateGroupDesc);
			panel2.Controls.Add(label14);
			panel2.Controls.Add(label7);
			panel2.Controls.Add(comboBoxGroupsForAddUserToGroup);
			panel2.Controls.Add(comboBoxUsersForAddToGroup);
			panel2.Controls.Add(buttonCreateUser);
			panel2.Controls.Add(buttonCreateGroup);
			panel2.Controls.Add(buttonAddUserToGroup);
			panel2.Controls.Add(label6);
			panel2.Controls.Add(label5);
			panel2.Location = new Point(16, 413);
			panel2.Name = "panel2";
			panel2.Size = new Size(1309, 297);
			panel2.TabIndex = 100;
			// 
			// label24
			// 
			label24.AutoSize = true;
			label24.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label24.ForeColor = Color.Red;
			label24.Location = new Point(33, 247);
			label24.Name = "label24";
			label24.Size = new Size(668, 42);
			label24.TabIndex = 114;
			label24.Text = "Note: Add user, create group, and add user to group will fail with insufficient authority\r\n          if you did not select the appropriate 'scope' on the sign-in screen!\r\n";
			// 
			// label23
			// 
			label23.AutoSize = true;
			label23.Location = new Point(937, 183);
			label23.Name = "label23";
			label23.Size = new Size(60, 15);
			label23.TabIndex = 113;
			label23.Text = "Password:";
			// 
			// textBoxPasswordForCreateUser
			// 
			textBoxPasswordForCreateUser.Location = new Point(1003, 180);
			textBoxPasswordForCreateUser.Name = "textBoxPasswordForCreateUser";
			textBoxPasswordForCreateUser.Size = new Size(82, 23);
			textBoxPasswordForCreateUser.TabIndex = 3;
			// 
			// textBox2
			// 
			textBox2.Location = new Point(1091, 151);
			textBox2.Name = "textBox2";
			textBox2.ReadOnly = true;
			textBox2.Size = new Size(150, 23);
			textBox2.TabIndex = 102;
			textBox2.TabStop = false;
			textBox2.Text = "@kensmithsoftware.com";
			// 
			// label22
			// 
			label22.AutoSize = true;
			label22.Location = new Point(882, 154);
			label22.Name = "label22";
			label22.Size = new Size(115, 15);
			label22.TabIndex = 111;
			label22.Text = "User principal name:";
			// 
			// textBoxNameForCreateUser
			// 
			textBoxNameForCreateUser.Location = new Point(1003, 151);
			textBoxNameForCreateUser.Name = "textBoxNameForCreateUser";
			textBoxNameForCreateUser.Size = new Size(82, 23);
			textBoxNameForCreateUser.TabIndex = 2;
			// 
			// label21
			// 
			label21.AutoSize = true;
			label21.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
			label21.ForeColor = Color.DarkViolet;
			label21.Location = new Point(890, 63);
			label21.Name = "label21";
			label21.Size = new Size(395, 63);
			label21.TabIndex = 109;
			label21.Text = "1. One scope that is sufficient: \"User.ReadWrite.All\"\r\n2. Signed-in user could have role: User Administrator or\r\n    Global Administrator.";
			// 
			// label20
			// 
			label20.AutoSize = true;
			label20.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
			label20.ForeColor = Color.DarkViolet;
			label20.Location = new Point(461, 63);
			label20.Name = "label20";
			label20.Size = new Size(414, 63);
			label20.TabIndex = 108;
			label20.Text = "1. One scope that is sufficient: \"Group.ReadWrite.All\"\r\n2. Signed-in user could have role: Groups Administrator or\r\n    Global Administrator.";
			// 
			// label19
			// 
			label19.AutoSize = true;
			label19.Location = new Point(462, 151);
			label19.Name = "label19";
			label19.Size = new Size(77, 15);
			label19.TabIndex = 106;
			label19.Text = "Select owner:";
			// 
			// comboBoxCreateGroupOwner
			// 
			comboBoxCreateGroupOwner.DropDownStyle = ComboBoxStyle.DropDownList;
			comboBoxCreateGroupOwner.FormattingEnabled = true;
			comboBoxCreateGroupOwner.Location = new Point(543, 147);
			comboBoxCreateGroupOwner.Name = "comboBoxCreateGroupOwner";
			comboBoxCreateGroupOwner.Size = new Size(279, 23);
			comboBoxCreateGroupOwner.TabIndex = 107;
			// 
			// label18
			// 
			label18.AutoSize = true;
			label18.Location = new Point(461, 179);
			label18.Name = "label18";
			label18.Size = new Size(76, 15);
			label18.TabIndex = 104;
			label18.Text = "Group name:";
			// 
			// textBoxCreateGroupName
			// 
			textBoxCreateGroupName.Location = new Point(543, 176);
			textBoxCreateGroupName.Name = "textBoxCreateGroupName";
			textBoxCreateGroupName.Size = new Size(298, 23);
			textBoxCreateGroupName.TabIndex = 0;
			// 
			// label17
			// 
			label17.AutoSize = true;
			label17.Location = new Point(467, 208);
			label17.Name = "label17";
			label17.Size = new Size(70, 15);
			label17.TabIndex = 102;
			label17.Text = "Group desc:";
			// 
			// label15
			// 
			label15.AutoSize = true;
			label15.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
			label15.ForeColor = Color.DarkViolet;
			label15.Location = new Point(378, 10);
			label15.Name = "label15";
			label15.Size = new Size(859, 42);
			label15.TabIndex = 99;
			label15.Text = resources.GetString("label15.Text");
			// 
			// textBoxCreateGroupDesc
			// 
			textBoxCreateGroupDesc.Location = new Point(543, 205);
			textBoxCreateGroupDesc.Name = "textBoxCreateGroupDesc";
			textBoxCreateGroupDesc.Size = new Size(298, 23);
			textBoxCreateGroupDesc.TabIndex = 1;
			// 
			// label14
			// 
			label14.AutoSize = true;
			label14.Location = new Point(12, 183);
			label14.Name = "label14";
			label14.Size = new Size(85, 15);
			label14.TabIndex = 61;
			label14.Text = "Select a group:";
			// 
			// label7
			// 
			label7.AutoSize = true;
			label7.Location = new Point(22, 155);
			label7.Name = "label7";
			label7.Size = new Size(75, 15);
			label7.TabIndex = 61;
			label7.Text = "Select a user:";
			// 
			// comboBoxGroupsForAddUserToGroup
			// 
			comboBoxGroupsForAddUserToGroup.DropDownStyle = ComboBoxStyle.DropDownList;
			comboBoxGroupsForAddUserToGroup.FormattingEnabled = true;
			comboBoxGroupsForAddUserToGroup.Location = new Point(103, 180);
			comboBoxGroupsForAddUserToGroup.Name = "comboBoxGroupsForAddUserToGroup";
			comboBoxGroupsForAddUserToGroup.Size = new Size(279, 23);
			comboBoxGroupsForAddUserToGroup.TabIndex = 62;
			comboBoxGroupsForAddUserToGroup.TabStop = false;
			// 
			// comboBoxUsersForAddToGroup
			// 
			comboBoxUsersForAddToGroup.DropDownStyle = ComboBoxStyle.DropDownList;
			comboBoxUsersForAddToGroup.FormattingEnabled = true;
			comboBoxUsersForAddToGroup.Location = new Point(103, 151);
			comboBoxUsersForAddToGroup.Name = "comboBoxUsersForAddToGroup";
			comboBoxUsersForAddToGroup.Size = new Size(279, 23);
			comboBoxUsersForAddToGroup.TabIndex = 61;
			comboBoxUsersForAddToGroup.TabStop = false;
			// 
			// buttonCreateUser
			// 
			buttonCreateUser.Location = new Point(978, 218);
			buttonCreateUser.Name = "buttonCreateUser";
			buttonCreateUser.Size = new Size(107, 23);
			buttonCreateUser.TabIndex = 98;
			buttonCreateUser.TabStop = false;
			buttonCreateUser.Text = "Create user";
			buttonCreateUser.UseVisualStyleBackColor = true;
			buttonCreateUser.Click += buttonCreateUser_Click;
			// 
			// buttonCreateGroup
			// 
			buttonCreateGroup.Location = new Point(734, 243);
			buttonCreateGroup.Name = "buttonCreateGroup";
			buttonCreateGroup.Size = new Size(107, 23);
			buttonCreateGroup.TabIndex = 97;
			buttonCreateGroup.TabStop = false;
			buttonCreateGroup.Text = "Create group";
			buttonCreateGroup.UseVisualStyleBackColor = true;
			buttonCreateGroup.Click += buttonCreateGroup_Click;
			// 
			// buttonAddUserToGroup
			// 
			buttonAddUserToGroup.Location = new Point(232, 218);
			buttonAddUserToGroup.Name = "buttonAddUserToGroup";
			buttonAddUserToGroup.Size = new Size(150, 23);
			buttonAddUserToGroup.TabIndex = 96;
			buttonAddUserToGroup.TabStop = false;
			buttonAddUserToGroup.Text = "Add user to group";
			buttonAddUserToGroup.UseVisualStyleBackColor = true;
			buttonAddUserToGroup.Click += buttonAddMemberToGroup_Click;
			// 
			// label6
			// 
			label6.AutoSize = true;
			label6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
			label6.ForeColor = Color.DarkViolet;
			label6.Location = new Point(14, 63);
			label6.Name = "label6";
			label6.Size = new Size(431, 63);
			label6.TabIndex = 95;
			label6.Text = "1. One scope that is sufficient: \"GroupMember.ReadWrite.All\"\r\n2. Signed-in user could have role: Groups Administrator or\r\n    could be the owner of the group.";
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label5.ForeColor = Color.DarkViolet;
			label5.Location = new Point(22, 13);
			label5.Name = "label5";
			label5.Size = new Size(350, 21);
			label5.TabIndex = 94;
			label5.Text = "Read/Write functions for GraphServiceClient\r\n";
			// 
			// panel3
			// 
			panel3.BackColor = Color.White;
			panel3.BorderStyle = BorderStyle.FixedSingle;
			panel3.Controls.Add(label8);
			panel3.Controls.Add(comboBoxUsers);
			panel3.Controls.Add(label9);
			panel3.Controls.Add(listBoxUserIsTransitiveMemberOf);
			panel3.Controls.Add(label13);
			panel3.Controls.Add(listBoxUserIsDirectMemberOf);
			panel3.Location = new Point(762, 36);
			panel3.Name = "panel3";
			panel3.Size = new Size(563, 178);
			panel3.TabIndex = 99;
			// 
			// label8
			// 
			label8.AutoSize = true;
			label8.Location = new Point(28, 17);
			label8.Name = "label8";
			label8.Size = new Size(75, 15);
			label8.TabIndex = 53;
			label8.Text = "Select a user:";
			// 
			// comboBoxUsers
			// 
			comboBoxUsers.DropDownStyle = ComboBoxStyle.DropDownList;
			comboBoxUsers.FormattingEnabled = true;
			comboBoxUsers.Location = new Point(109, 14);
			comboBoxUsers.Name = "comboBoxUsers";
			comboBoxUsers.Size = new Size(279, 23);
			comboBoxUsers.TabIndex = 60;
			comboBoxUsers.TabStop = false;
			comboBoxUsers.SelectedIndexChanged += comboBoxUsers_SelectedIndexChanged;
			// 
			// label9
			// 
			label9.AutoSize = true;
			label9.Location = new Point(294, 46);
			label9.Name = "label9";
			label9.Size = new Size(225, 15);
			label9.TabIndex = 52;
			label9.Text = "User is transitive member of these groups";
			// 
			// listBoxUserIsTransitiveMemberOf
			// 
			listBoxUserIsTransitiveMemberOf.FormattingEnabled = true;
			listBoxUserIsTransitiveMemberOf.ItemHeight = 15;
			listBoxUserIsTransitiveMemberOf.Location = new Point(294, 64);
			listBoxUserIsTransitiveMemberOf.Name = "listBoxUserIsTransitiveMemberOf";
			listBoxUserIsTransitiveMemberOf.Size = new Size(248, 94);
			listBoxUserIsTransitiveMemberOf.TabIndex = 51;
			listBoxUserIsTransitiveMemberOf.TabStop = false;
			// 
			// label13
			// 
			label13.AutoSize = true;
			label13.Location = new Point(17, 46);
			label13.Name = "label13";
			label13.Size = new Size(207, 15);
			label13.TabIndex = 50;
			label13.Text = "User is direct member of these groups";
			// 
			// listBoxUserIsDirectMemberOf
			// 
			listBoxUserIsDirectMemberOf.FormattingEnabled = true;
			listBoxUserIsDirectMemberOf.ItemHeight = 15;
			listBoxUserIsDirectMemberOf.Location = new Point(17, 64);
			listBoxUserIsDirectMemberOf.Name = "listBoxUserIsDirectMemberOf";
			listBoxUserIsDirectMemberOf.Size = new Size(248, 94);
			listBoxUserIsDirectMemberOf.TabIndex = 49;
			listBoxUserIsDirectMemberOf.TabStop = false;
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Location = new Point(381, 18);
			label4.Name = "label4";
			label4.Size = new Size(148, 15);
			label4.TabIndex = 98;
			label4.Text = "Datagrid view of all groups";
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new Point(32, 18);
			label3.Name = "label3";
			label3.Size = new Size(124, 15);
			label3.TabIndex = 94;
			label3.Text = "Tree view of all groups";
			// 
			// treeView1
			// 
			treeView1.Location = new Point(16, 36);
			treeView1.Name = "treeView1";
			treeView1.Size = new Size(325, 362);
			treeView1.TabIndex = 97;
			treeView1.TabStop = false;
			// 
			// dataGridView1
			// 
			dataGridView1.AllowUserToAddRows = false;
			dataGridView1.AllowUserToDeleteRows = false;
			dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Column_GroupName, Column_DirectMembers });
			dataGridView1.Location = new Point(356, 36);
			dataGridView1.MultiSelect = false;
			dataGridView1.Name = "dataGridView1";
			dataGridView1.ReadOnly = true;
			dataGridView1.RowHeadersVisible = false;
			dataGridView1.Size = new Size(384, 362);
			dataGridView1.TabIndex = 96;
			dataGridView1.TabStop = false;
			// 
			// Column_GroupName
			// 
			Column_GroupName.HeaderText = "Group name";
			Column_GroupName.Name = "Column_GroupName";
			Column_GroupName.ReadOnly = true;
			Column_GroupName.SortMode = DataGridViewColumnSortMode.NotSortable;
			Column_GroupName.Width = 150;
			// 
			// Column_DirectMembers
			// 
			Column_DirectMembers.HeaderText = "Direct members";
			Column_DirectMembers.Name = "Column_DirectMembers";
			Column_DirectMembers.ReadOnly = true;
			Column_DirectMembers.SortMode = DataGridViewColumnSortMode.NotSortable;
			Column_DirectMembers.Width = 200;
			// 
			// panel1
			// 
			panel1.BackColor = Color.White;
			panel1.BorderStyle = BorderStyle.FixedSingle;
			panel1.Controls.Add(label12);
			panel1.Controls.Add(comboBoxGroups);
			panel1.Controls.Add(label10);
			panel1.Controls.Add(listBoxTransitiveMembersOfSelectedGroup);
			panel1.Controls.Add(label11);
			panel1.Controls.Add(listBoxDirectMembersOfSelectedGroup);
			panel1.Location = new Point(762, 220);
			panel1.Name = "panel1";
			panel1.Size = new Size(563, 178);
			panel1.TabIndex = 95;
			// 
			// label12
			// 
			label12.AutoSize = true;
			label12.Location = new Point(18, 17);
			label12.Name = "label12";
			label12.Size = new Size(85, 15);
			label12.TabIndex = 53;
			label12.Text = "Select a group:";
			// 
			// comboBoxGroups
			// 
			comboBoxGroups.DropDownStyle = ComboBoxStyle.DropDownList;
			comboBoxGroups.FormattingEnabled = true;
			comboBoxGroups.Location = new Point(109, 14);
			comboBoxGroups.Name = "comboBoxGroups";
			comboBoxGroups.Size = new Size(279, 23);
			comboBoxGroups.TabIndex = 60;
			comboBoxGroups.TabStop = false;
			comboBoxGroups.SelectedIndexChanged += comboBoxGroups_SelectedIndexChanged;
			// 
			// label10
			// 
			label10.AutoSize = true;
			label10.Location = new Point(294, 46);
			label10.Name = "label10";
			label10.Size = new Size(204, 15);
			label10.TabIndex = 52;
			label10.Text = "Transitive members of selected group";
			// 
			// listBoxTransitiveMembersOfSelectedGroup
			// 
			listBoxTransitiveMembersOfSelectedGroup.FormattingEnabled = true;
			listBoxTransitiveMembersOfSelectedGroup.ItemHeight = 15;
			listBoxTransitiveMembersOfSelectedGroup.Location = new Point(294, 64);
			listBoxTransitiveMembersOfSelectedGroup.Name = "listBoxTransitiveMembersOfSelectedGroup";
			listBoxTransitiveMembersOfSelectedGroup.Size = new Size(248, 94);
			listBoxTransitiveMembersOfSelectedGroup.TabIndex = 51;
			listBoxTransitiveMembersOfSelectedGroup.TabStop = false;
			// 
			// label11
			// 
			label11.AutoSize = true;
			label11.Location = new Point(17, 46);
			label11.Name = "label11";
			label11.Size = new Size(186, 15);
			label11.TabIndex = 50;
			label11.Text = "Direct members of selected group";
			// 
			// listBoxDirectMembersOfSelectedGroup
			// 
			listBoxDirectMembersOfSelectedGroup.FormattingEnabled = true;
			listBoxDirectMembersOfSelectedGroup.ItemHeight = 15;
			listBoxDirectMembersOfSelectedGroup.Location = new Point(17, 64);
			listBoxDirectMembersOfSelectedGroup.Name = "listBoxDirectMembersOfSelectedGroup";
			listBoxDirectMembersOfSelectedGroup.Size = new Size(248, 94);
			listBoxDirectMembersOfSelectedGroup.TabIndex = 49;
			listBoxDirectMembersOfSelectedGroup.TabStop = false;
			// 
			// label16
			// 
			label16.AutoSize = true;
			label16.Location = new Point(927, 41);
			label16.Name = "label16";
			label16.Size = new Size(86, 15);
			label16.TabIndex = 100;
			label16.Text = "Signed-in user:";
			// 
			// textBoxSignedInUserPrincipalName
			// 
			textBoxSignedInUserPrincipalName.Location = new Point(1019, 38);
			textBoxSignedInUserPrincipalName.Name = "textBoxSignedInUserPrincipalName";
			textBoxSignedInUserPrincipalName.ReadOnly = true;
			textBoxSignedInUserPrincipalName.Size = new Size(298, 23);
			textBoxSignedInUserPrincipalName.TabIndex = 101;
			textBoxSignedInUserPrincipalName.TabStop = false;
			// 
			// FormExperimentGraph
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1364, 821);
			Controls.Add(label16);
			Controls.Add(panelEntireScreen);
			Controls.Add(textBoxSignedInUserPrincipalName);
			Controls.Add(buttonCancel);
			Controls.Add(buttonProceed);
			Controls.Add(label2);
			Controls.Add(label1);
			Name = "FormExperimentGraph";
			Text = "FormExperimentGraph";
			Load += FormExperimentGraph_Load;
			panelEntireScreen.ResumeLayout(false);
			panelEntireScreen.PerformLayout();
			panel2.ResumeLayout(false);
			panel2.PerformLayout();
			panel3.ResumeLayout(false);
			panel3.PerformLayout();
			((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion
		private Label label1;
		private Label label2;
		private Button buttonProceed;
		private Button buttonCancel;
		private Panel panelEntireScreen;
		private Panel panel2;
		private Label label15;
		private Label label14;
		private Label label7;
		private ComboBox comboBoxGroupsForAddUserToGroup;
		private ComboBox comboBoxUsersForAddToGroup;
		private Button buttonCreateUser;
		private Button buttonCreateGroup;
		private Button buttonAddUserToGroup;
		private Label label6;
		private Label label5;
		private Panel panel3;
		private Label label8;
		private ComboBox comboBoxUsers;
		private Label label9;
		private ListBox listBoxUserIsTransitiveMemberOf;
		private Label label13;
		private ListBox listBoxUserIsDirectMemberOf;
		private Label label4;
		private Label label3;
		private TreeView treeView1;
		private DataGridView dataGridView1;
		private DataGridViewTextBoxColumn Column_GroupName;
		private DataGridViewTextBoxColumn Column_DirectMembers;
		private Panel panel1;
		private Label label12;
		private ComboBox comboBoxGroups;
		private Label label10;
		private ListBox listBoxTransitiveMembersOfSelectedGroup;
		private Label label11;
		private ListBox listBoxDirectMembersOfSelectedGroup;
		private Label label16;
		private TextBox textBoxSignedInUserPrincipalName;
		private Label label17;
		private TextBox textBoxCreateGroupDesc;
		private Label label19;
		private ComboBox comboBoxCreateGroupOwner;
		private Label label18;
		private TextBox textBoxCreateGroupName;
		private Label label20;
		private Label label21;
		private TextBox textBox2;
		private Label label22;
		private TextBox textBoxNameForCreateUser;
		private Label label23;
		private TextBox textBoxPasswordForCreateUser;
		private Label label24;
	}
}