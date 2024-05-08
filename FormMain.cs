using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Graph;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZWinformsCoreAppCallsMsgraph
{
	public partial class FormMain : Form
	{
		private IUserAuthStatus? _userAuthStatus;
		public FormMain()
		{
			InitializeComponent();
			_userAuthStatus = Program.ServiceProvider.GetRequiredService<IUserAuthStatus>();
		}

		private async void FormMain_Load(object sender, EventArgs e)
		{
			try
			{
				Cursor.Current = Cursors.WaitCursor;
				buttonDebugIdToken.Visible = _userAuthStatus.AuthResult != null;
				textBoxDisplayName.Clear();
				textBoxUserPrincipalName.Clear();
				listBoxMeDirectMemberOf.Items.Clear();
				listBoxMeTransitiveMemberOf.Items.Clear();
				//
				//var me = await GraphServiceClient.Me.GetAsync();
				textBoxDisplayName.Text = _userAuthStatus.SignedInUser.DisplayName;
				textBoxUserPrincipalName.Text = _userAuthStatus.SignedInUser.UserPrincipalName;
				//
				DisableButtonsIfUserNotAuthorized();
				//
				GraphServiceClient graphServiceClient = _userAuthStatus.GraphServiceClient;
				List<string> groupsMeDirectMemberOf = await GraphApiWrapper.getGroupsMeDirectMemberOf(graphServiceClient);
				List<string> groupsMeTransitiveMemberOf = await GraphApiWrapper.getGroupsMeTransitiveMemberOf(graphServiceClient);
				populateListBox(listBoxMeDirectMemberOf, groupsMeDirectMemberOf, true);
				populateListBox(listBoxMeTransitiveMemberOf, groupsMeTransitiveMemberOf, true);
			}
			catch (Exception exc)
			{
				Constants.DisplayExceptionMessage(exc);
			}
			finally
			{
				Cursor.Current = Cursors.Arrow;
			}
		}

		/// <summary>
		/// Populate listbox with list of strings (optional sort parm)
		/// </summary>
		private async void populateListBox(ListBox listBox, List<string> listOfStrings, bool sortAscending)
		{
			listBox.Items.Clear();
			listOfStrings.Sort();
			foreach (var nextString in listOfStrings)
			{
				listBox.Items.Add(nextString);
			}
			if (listOfStrings.Count == 0)
			{
				listBox.Items.Add("<None>");
			}
		}

		private void buttonExperimentWithGraph_Click(object sender, EventArgs e)
		{
			FormExperimentGraph frm = new FormExperimentGraph();
			frm.ShowDialog();
		}

		private void buttonDebugIdToken_Click(object sender, EventArgs e)
		{
			FormDebugIdToken frm = new FormDebugIdToken();
			frm.ShowDialog();
		}

		private void buttonExperimentWithGraphReadWrite_Click(object sender, EventArgs e)
		{
			Constants.DisplayInfoMessage("4/21/2024 TBD");
		}

		private void buttonStaffTask_Click(object sender, EventArgs e)
		{
			Constants.DisplayInfoMessage("Staff task would be performed.");
		}

		private void buttonMarketingTask_Click(object sender, EventArgs e)
		{
			Constants.DisplayInfoMessage("Marketing task would be performed.");
		}

		private void buttonBillingTask_Click(object sender, EventArgs e)
		{
			Constants.DisplayInfoMessage("Billing task would be performed.");
		}

		private void buttonAppealsTask_Click(object sender, EventArgs e)
		{
			Constants.DisplayInfoMessage("Appeals task would be performed.");
		}
		private void buttonAdminTask_Click(object sender, EventArgs e)
		{
			Constants.DisplayInfoMessage("Admin task would be performed.");
		}
		private void DisableButtonsIfUserNotAuthorized()
		{
			buttonStaffTask.Enabled = _userAuthStatus.IsAuthenticated &&
				(_userAuthStatus.IsSignedInUserTransitiveMemberOf("DemoGroupAdmin") || _userAuthStatus.IsSignedInUserTransitiveMemberOf("DemoGroupStaff"));

			buttonMarketingTask.Enabled = _userAuthStatus.IsAuthenticated &&
				(_userAuthStatus.IsSignedInUserTransitiveMemberOf("DemoGroupAdmin") || _userAuthStatus.IsSignedInUserTransitiveMemberOf("DemoGroupMarketing"));

			buttonBillingTask.Enabled = _userAuthStatus.IsAuthenticated &&
				(_userAuthStatus.IsSignedInUserTransitiveMemberOf("DemoGroupAdmin") || _userAuthStatus.IsSignedInUserTransitiveMemberOf("DemoGroupBilling"));

			buttonAppealsTask.Enabled = _userAuthStatus.IsAuthenticated &&
				(_userAuthStatus.IsSignedInUserTransitiveMemberOf("DemoGroupAdmin") || _userAuthStatus.IsSignedInUserTransitiveMemberOf("DemoGroupAppeals"));
			buttonAdminTask.Enabled = _userAuthStatus.IsAuthenticated && _userAuthStatus.IsSignedInUserTransitiveMemberOf("DemoGroupAdmin");

		}
	}
}
