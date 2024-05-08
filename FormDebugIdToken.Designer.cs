namespace ZWinformsCoreAppCallsMsgraph
{
	partial class FormDebugIdToken
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
			label1 = new Label();
			textBoxTokenExpirationTime = new TextBox();
			label9 = new Label();
			textBoxDecodedAccessTokenClaims = new TextBox();
			label16 = new Label();
			textBoxDecodedIdTokenClaims = new TextBox();
			label15 = new Label();
			label14 = new Label();
			textBoxClaimsForSignedInUser = new TextBox();
			label13 = new Label();
			textBoxRawDataAccessToken = new TextBox();
			label7 = new Label();
			textBoxRawDataIdToken = new TextBox();
			label6 = new Label();
			textBoxIdTokenValidYorN = new TextBox();
			label3 = new Label();
			SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label1.Location = new Point(12, 9);
			label1.Name = "label1";
			label1.Size = new Size(132, 21);
			label1.TabIndex = 87;
			label1.Text = "Debug ID Token";
			// 
			// textBoxTokenExpirationTime
			// 
			textBoxTokenExpirationTime.Location = new Point(134, 118);
			textBoxTokenExpirationTime.Name = "textBoxTokenExpirationTime";
			textBoxTokenExpirationTime.ReadOnly = true;
			textBoxTokenExpirationTime.Size = new Size(298, 23);
			textBoxTokenExpirationTime.TabIndex = 100;
			// 
			// label9
			// 
			label9.AutoSize = true;
			label9.Location = new Point(48, 121);
			label9.Name = "label9";
			label9.Size = new Size(81, 15);
			label9.TabIndex = 99;
			label9.Text = "Token Expires:";
			// 
			// textBoxDecodedAccessTokenClaims
			// 
			textBoxDecodedAccessTokenClaims.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
			textBoxDecodedAccessTokenClaims.Location = new Point(926, 334);
			textBoxDecodedAccessTokenClaims.Multiline = true;
			textBoxDecodedAccessTokenClaims.Name = "textBoxDecodedAccessTokenClaims";
			textBoxDecodedAccessTokenClaims.ReadOnly = true;
			textBoxDecodedAccessTokenClaims.ScrollBars = ScrollBars.Both;
			textBoxDecodedAccessTokenClaims.Size = new Size(333, 315);
			textBoxDecodedAccessTokenClaims.TabIndex = 98;
			textBoxDecodedAccessTokenClaims.WordWrap = false;
			// 
			// label16
			// 
			label16.AutoSize = true;
			label16.Location = new Point(926, 316);
			label16.Name = "label16";
			label16.Size = new Size(251, 15);
			label16.TabIndex = 97;
			label16.Text = "Decoded Access Token - Payload only (claims)";
			// 
			// textBoxDecodedIdTokenClaims
			// 
			textBoxDecodedIdTokenClaims.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
			textBoxDecodedIdTokenClaims.Location = new Point(587, 334);
			textBoxDecodedIdTokenClaims.Multiline = true;
			textBoxDecodedIdTokenClaims.Name = "textBoxDecodedIdTokenClaims";
			textBoxDecodedIdTokenClaims.ReadOnly = true;
			textBoxDecodedIdTokenClaims.ScrollBars = ScrollBars.Both;
			textBoxDecodedIdTokenClaims.Size = new Size(333, 315);
			textBoxDecodedIdTokenClaims.TabIndex = 96;
			textBoxDecodedIdTokenClaims.WordWrap = false;
			// 
			// label15
			// 
			label15.AutoSize = true;
			label15.Location = new Point(587, 316);
			label15.Name = "label15";
			label15.Size = new Size(226, 15);
			label15.TabIndex = 95;
			label15.Text = "Decoded ID Token - Payload only (claims)";
			// 
			// label14
			// 
			label14.AutoSize = true;
			label14.Location = new Point(647, 151);
			label14.Name = "label14";
			label14.Size = new Size(530, 15);
			label14.TabIndex = 94;
			label14.Text = "JSON Web Tokens can be parsed online (https://jwt.ms/) or in code using JwtSecurityTokenHandler.";
			// 
			// textBoxClaimsForSignedInUser
			// 
			textBoxClaimsForSignedInUser.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
			textBoxClaimsForSignedInUser.Location = new Point(46, 177);
			textBoxClaimsForSignedInUser.Multiline = true;
			textBoxClaimsForSignedInUser.Name = "textBoxClaimsForSignedInUser";
			textBoxClaimsForSignedInUser.ReadOnly = true;
			textBoxClaimsForSignedInUser.ScrollBars = ScrollBars.Both;
			textBoxClaimsForSignedInUser.Size = new Size(498, 472);
			textBoxClaimsForSignedInUser.TabIndex = 93;
			textBoxClaimsForSignedInUser.WordWrap = false;
			// 
			// label13
			// 
			label13.AutoSize = true;
			label13.Location = new Point(46, 157);
			label13.Name = "label13";
			label13.Size = new Size(139, 15);
			label13.TabIndex = 92;
			label13.Text = "Claims for signed-in user";
			// 
			// textBoxRawDataAccessToken
			// 
			textBoxRawDataAccessToken.Location = new Point(926, 196);
			textBoxRawDataAccessToken.Multiline = true;
			textBoxRawDataAccessToken.Name = "textBoxRawDataAccessToken";
			textBoxRawDataAccessToken.ReadOnly = true;
			textBoxRawDataAccessToken.ScrollBars = ScrollBars.Both;
			textBoxRawDataAccessToken.Size = new Size(333, 112);
			textBoxRawDataAccessToken.TabIndex = 91;
			// 
			// label7
			// 
			label7.AutoSize = true;
			label7.Location = new Point(926, 177);
			label7.Name = "label7";
			label7.Size = new Size(136, 15);
			label7.TabIndex = 90;
			label7.Text = "Raw data (Access Token)";
			// 
			// textBoxRawDataIdToken
			// 
			textBoxRawDataIdToken.Location = new Point(587, 196);
			textBoxRawDataIdToken.Multiline = true;
			textBoxRawDataIdToken.Name = "textBoxRawDataIdToken";
			textBoxRawDataIdToken.ReadOnly = true;
			textBoxRawDataIdToken.ScrollBars = ScrollBars.Both;
			textBoxRawDataIdToken.Size = new Size(333, 112);
			textBoxRawDataIdToken.TabIndex = 89;
			// 
			// label6
			// 
			label6.AutoSize = true;
			label6.Location = new Point(587, 178);
			label6.Name = "label6";
			label6.Size = new Size(111, 15);
			label6.TabIndex = 88;
			label6.Text = "Raw data (ID Token)";
			// 
			// textBoxIdTokenValidYorN
			// 
			textBoxIdTokenValidYorN.Location = new Point(134, 89);
			textBoxIdTokenValidYorN.Name = "textBoxIdTokenValidYorN";
			textBoxIdTokenValidYorN.ReadOnly = true;
			textBoxIdTokenValidYorN.Size = new Size(44, 23);
			textBoxIdTokenValidYorN.TabIndex = 104;
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new Point(33, 92);
			label3.Name = "label3";
			label3.Size = new Size(95, 15);
			label3.TabIndex = 103;
			label3.Text = "Is ID token valid?";
			// 
			// FormDebugIdToken
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1334, 661);
			Controls.Add(textBoxIdTokenValidYorN);
			Controls.Add(label3);
			Controls.Add(textBoxTokenExpirationTime);
			Controls.Add(label9);
			Controls.Add(textBoxDecodedAccessTokenClaims);
			Controls.Add(label16);
			Controls.Add(textBoxDecodedIdTokenClaims);
			Controls.Add(label15);
			Controls.Add(label14);
			Controls.Add(textBoxClaimsForSignedInUser);
			Controls.Add(label13);
			Controls.Add(textBoxRawDataAccessToken);
			Controls.Add(label7);
			Controls.Add(textBoxRawDataIdToken);
			Controls.Add(label6);
			Controls.Add(label1);
			Name = "FormDebugIdToken";
			Text = "FormDebugIdToken";
			Load += FormDebugIdToken_Load;
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label label1;
		private TextBox textBoxTokenExpirationTime;
		private Label label9;
		private TextBox textBoxDecodedAccessTokenClaims;
		private Label label16;
		private TextBox textBoxDecodedIdTokenClaims;
		private Label label15;
		private Label label14;
		private TextBox textBoxClaimsForSignedInUser;
		private Label label13;
		private TextBox textBoxRawDataAccessToken;
		private Label label7;
		private TextBox textBoxRawDataIdToken;
		private Label label6;
		private TextBox textBoxIdTokenValidYorN;
		private Label label3;
	}
}