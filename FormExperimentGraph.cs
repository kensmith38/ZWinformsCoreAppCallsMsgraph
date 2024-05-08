using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Graph;
using Microsoft.Graph.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Reference: https://learn.microsoft.com/en-us/dotnet/api/system.windows.forms.treeview?view=windowsdesktop-8.0
namespace ZWinformsCoreAppCallsMsgraph
{
	public partial class FormExperimentGraph : Form
	{
		// Use dependency injection
		private IConfiguration? _configuration;
		private IUserAuthStatus? _userAuthStatus;
		bool userActionEnabled = true;

		public FormExperimentGraph()
		{
			InitializeComponent();
			_configuration = Program.ServiceProvider.GetRequiredService<IConfiguration>();
			_userAuthStatus = Program.ServiceProvider.GetRequiredService<IUserAuthStatus>();
		}

		private async void FormExperimentGraph_Load(object sender, EventArgs e)
		{

		}
		private async void buttonProceed_Click(object sender, EventArgs e)
		{
			if (!userActionEnabled) { return; }
			panelEntireScreen.Visible = true;
			try
			{
				Cursor.Current = Cursors.WaitCursor;
				await RefreshEntireScreen();
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
		private async Task RefreshEntireScreen()
		{
			userActionEnabled = false;
			textBoxSignedInUserPrincipalName.Text = _userAuthStatus.SignedInUser.UserPrincipalName;
			listBoxDirectMembersOfSelectedGroup.Items.Clear();
			listBoxTransitiveMembersOfSelectedGroup.Items.Clear();
			listBoxUserIsDirectMemberOf.Items.Clear();
			listBoxUserIsTransitiveMemberOf.Items.Clear();
			treeView1.Nodes.Clear();
			try
			{
				Cursor.Current = Cursors.WaitCursor;
				GraphServiceClient graphServiceClient = _userAuthStatus.GraphServiceClient;
				List<string> allGroups = await GraphApiWrapper.GetAllGroups(graphServiceClient);
				List<string> allUsers = await GraphApiWrapper.GetAllUsers(graphServiceClient);
				await populateComboBoxUsers(allUsers, true);
				await populateComboBoxGroups(allGroups, true);
				await populateDatagrid(allGroups);
				await InitializeTreeView(allGroups);
			}
			catch (Exception exc)
			{
				Constants.DisplayExceptionMessage(exc);
			}
			finally
			{
				userActionEnabled = true;
				Cursor.Current = Cursors.Arrow;
			}
		}
		/// <summary>
		/// Populates three combobox controls with same list of users
		/// </summary>
		private async Task populateComboBoxUsers(List<string> listOfStrings, bool sortAscending)
		{
			//..userActionEnabled = false;
			comboBoxUsers.Items.Clear();
			comboBoxUsersForAddToGroup.Items.Clear();
			comboBoxCreateGroupOwner.Items.Clear();


			if (sortAscending)
			{
				listOfStrings.Sort();
			}
			foreach (var nextString in listOfStrings)
			{
				comboBoxUsers.Items.Add(nextString);
				comboBoxUsersForAddToGroup.Items.Add(nextString);
				comboBoxCreateGroupOwner.Items.Add(nextString);
			}
			comboBoxUsers.SelectedIndex = 0;
			comboBoxUsersForAddToGroup.SelectedIndex = 0;
			comboBoxCreateGroupOwner.SelectedIndex = 0;

			await PopulateListsOfGroupsThatUserIsMemberOf(comboBoxUsers.SelectedItem.ToString());
			//..userActionEnabled = true;
		}
		/// <summary>
		/// Populates two combobox controls with same list of groups
		/// </summary>
		private async Task populateComboBoxGroups(List<string> listOfStrings, bool sortAscending)
		{
			//..userActionEnabled = false;
			comboBoxGroups.Items.Clear();
			comboBoxGroupsForAddUserToGroup.Items.Clear();

			if (sortAscending)
			{
				listOfStrings.Sort();
			}
			foreach (var nextString in listOfStrings)
			{
				comboBoxGroups.Items.Add(nextString);
				comboBoxGroupsForAddUserToGroup.Items.Add(nextString);
			}
			comboBoxGroups.SelectedIndex = 0;
			comboBoxGroupsForAddUserToGroup.SelectedIndex = 0;

			await PopulateListsOfMembersOfGroup(comboBoxGroups.SelectedItem.ToString());
			//..userActionEnabled = true;
		}
		/// <summary>
		/// Populate the datagrid with all the groups and direct members.
		/// </summary>
		private async Task populateDatagrid(List<string> allGroups)
		{
			GraphServiceClient graphServiceClient = _userAuthStatus.GraphServiceClient;
			dataGridView1.Rows.Clear();
			Color[] twoColors = { Color.LightBlue, Color.LightGray };
			int colorIndex = 0;
			foreach (var groupName in allGroups)
			{
				List<string> directMembers = await GraphApiWrapper.getDirectMembersOfGroupNamed(graphServiceClient, groupName);
				if ((directMembers == null) || (directMembers.Count == 0))
				{
					DataGridViewRow dgvrow = dataGridView1.Rows[dataGridView1.Rows.Add()];
					dgvrow.Cells[Column_GroupName.Index].Value = groupName;
					dgvrow.Cells[Column_DirectMembers.Index].Value = string.Empty;
					dgvrow.DefaultCellStyle.BackColor = twoColors[colorIndex];
				}
				else
				{
					directMembers.Sort(SortGroupsBeforeUsers());
					bool firstMember = true;
					foreach (string directMember in directMembers)
					{
						DataGridViewRow dgvrow = dataGridView1.Rows[dataGridView1.Rows.Add()];
						dgvrow.Cells[Column_GroupName.Index].Value = firstMember ? groupName : string.Empty;
						dgvrow.Cells[Column_DirectMembers.Index].Value = directMember;
						dgvrow.DefaultCellStyle.BackColor = twoColors[colorIndex];
						firstMember = false;
					}
				}
				// Add blank spacer row
				DataGridViewRow spacerRow = dataGridView1.Rows[dataGridView1.Rows.Add()];
				spacerRow.Height = 6;
				colorIndex = colorIndex == 0 ? 1 : 0;
			}
			dataGridView1.ClearSelection();
		}
		/// <summary>
		/// Populate listbox with list of strings (optional sort parm)
		/// </summary>
		private async Task populateListBox(ListBox listBox, List<string> listOfStrings, bool sortAscending)
		{
			listBox.Items.Clear();
			listOfStrings.Sort(SortGroupsBeforeUsers());
			foreach (var nextString in listOfStrings)
			{
				listBox.Items.Add(nextString);
			}
			if (listOfStrings.Count == 0)
			{
				listBox.Items.Add("<None>");
			}
		}
		private async void comboBoxUsers_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (userActionEnabled)
			{
				string selectedUserName = comboBoxUsers.SelectedItem.ToString();
				await PopulateListsOfGroupsThatUserIsMemberOf(selectedUserName);
			}
		}
		private async void comboBoxGroups_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (userActionEnabled)
			{
				string selectedGroupName = comboBoxGroups.SelectedItem.ToString();
				await PopulateListsOfMembersOfGroup(selectedGroupName);
			}
		}
		private async Task PopulateListsOfGroupsThatUserIsMemberOf(string userName)
		{
			userActionEnabled = false;
			listBoxUserIsDirectMemberOf.Items.Clear();
			listBoxUserIsTransitiveMemberOf.Items.Clear();
			GraphServiceClient graphServiceClient = _userAuthStatus.GraphServiceClient;
			if (!string.IsNullOrWhiteSpace(userName))
			{
				string userId = await GraphApiWrapper.GetUserIdForUserPrincipalName(graphServiceClient, userName);
				// If userName is not null and userId is null then we have a timing problem.
				// This occurs when we create a new user.
				// We will wait a period of milliseconds and try again!
				if ((userId == null) && (!string.IsNullOrWhiteSpace(userName)))
				{
					Constants.DisplayErrorMessage("Compensating for timing problem!");
					await Task.Delay(2000);
					userId = await GraphApiWrapper.GetUserIdForUserPrincipalName(graphServiceClient, userName);
					if (userId == null)
					{
						Constants.DisplayErrorMessage("Compensating for timing problem FAILED!");
					}
				}
				List<string> groupsThatUserIsDirectMemberOf = await GraphApiWrapper.getGroupsThatUserDirectMemberOf(graphServiceClient, userId);
				List<string> groupsThatUserIsTransitiveMemberOf = await GraphApiWrapper.getGroupsThatUserTransitiveMemberOf(graphServiceClient, userId);

				await populateListBox(listBoxUserIsDirectMemberOf, groupsThatUserIsDirectMemberOf, true);
				await populateListBox(listBoxUserIsTransitiveMemberOf, groupsThatUserIsTransitiveMemberOf, true);
			}
			userActionEnabled = true;
		}
		private async Task PopulateListsOfMembersOfGroup(string groupName)
		{
			userActionEnabled = false;
			listBoxDirectMembersOfSelectedGroup.Items.Clear();
			listBoxTransitiveMembersOfSelectedGroup.Items.Clear();
			GraphServiceClient graphServiceClient = _userAuthStatus.GraphServiceClient;
			if (!string.IsNullOrWhiteSpace(groupName))
			{
				List<string> directMembers = await GraphApiWrapper.getDirectMembersOfGroupNamed(graphServiceClient, groupName);
				List<string> transitiveMembers = await GraphApiWrapper.getTransitiveMembersOfGroupNamed(graphServiceClient, groupName);
				await populateListBox(listBoxDirectMembersOfSelectedGroup, directMembers, true);
				await populateListBox(listBoxTransitiveMembersOfSelectedGroup, transitiveMembers, true);
			}
			userActionEnabled = true;
		}

		// Populates a TreeView control with example nodes. 
		private async Task InitializeTreeView(List<string> allGroups)
		{
			GraphServiceClient graphServiceClient = _userAuthStatus.GraphServiceClient;
			treeView1.BeginUpdate();
			treeView1.Nodes.Clear();
			TreeNode currentNode = treeView1.Nodes.Add("Groups");
			foreach (string groupName in allGroups)
			{

				//currentNode.Nodes.Add(group);
				await AddSubgroupsToNode(graphServiceClient, currentNode, groupName);
			}
			treeView1.EndUpdate();
			treeView1.ExpandAll();

		}
		/// <summary>
		/// Recursive method to add subgroups to current node
		/// </summary>
		private async Task AddSubgroupsToNode(GraphServiceClient graphServiceClient, TreeNode currentNode, string groupName)
		{
			currentNode = currentNode.Nodes.Add(groupName);
			List<string> subgroups = await GraphApiWrapper.getDirectMembersOfGroupNamed(graphServiceClient, groupName);
			if ((subgroups != null) && (subgroups.Count > 0))
			{

				subgroups.Sort(SortGroupsBeforeUsers());
				string domain = _configuration.GetValue<string>("Domain");
				foreach (string subgroupName in subgroups)
				{
					// Users are identified by subgroupName end with domain
					if (subgroupName.EndsWith(domain))
					{
						currentNode.Nodes.Add(subgroupName);
					}
					else
					{
						await AddSubgroupsToNode(graphServiceClient, currentNode, subgroupName);
					}
				}
			}
		}
		/// <summary>
		/// Sorts a list of strings (of groups and users) by placing groups before users.
		/// Static class helps performance (only instantantiated one time).
		/// </summary>
		/// <returns></returns>
		public static IComparer<string> SortGroupsBeforeUsers()
		{
			return (IComparer<string>)new SortGroupsBeforeUsersHelper();
		}
		/// <summary>
		/// Add existing user to existing group
		/// </summary>
		private async void buttonAddMemberToGroup_Click(object sender, EventArgs e)
		{
			if (!userActionEnabled) { return; }
			userActionEnabled = false;
			string infomssg = null;
			try
			{
				Cursor.Current = Cursors.WaitCursor;
				int saveGroupsSelectedIndex = comboBoxGroupsForAddUserToGroup.SelectedIndex;
				int saveUsersSelectedIndex = comboBoxUsersForAddToGroup.SelectedIndex;
				GraphServiceClient graphServiceClient = _userAuthStatus.GraphServiceClient;
				string userPrincipalName = comboBoxUsersForAddToGroup.SelectedItem.ToString();
				string groupName = comboBoxGroupsForAddUserToGroup.SelectedItem.ToString();
				await GraphApiWrapper.AddUserToGroup(graphServiceClient, userPrincipalName, groupName);
				infomssg = $"Successfully added {userPrincipalName} to {groupName}";
				Constants.DisplayInfoMessage(infomssg);
				await RefreshEntireScreen();
				// keep selected user and group as they were
				comboBoxGroupsForAddUserToGroup.SelectedIndex = saveGroupsSelectedIndex;
				comboBoxUsersForAddToGroup.SelectedIndex = saveUsersSelectedIndex;
			}
			catch (Exception exc)
			{
				// Don't show stack trace if simple "insufficient privileges".
				if (exc.Message.ToLower().Contains("insufficient privileges"))
				{
					Constants.DisplayErrorMessage(exc.Message);
					infomssg = "Insufficient privileges is usually due to:"
						+ "\n1. Wrong scopes selected in sign-in screen."
						+ "\n2. The signed-in user does not have authority (such as Group Owner).";
					Constants.DisplayInfoMessage(infomssg);
				}
				else
				{
					Constants.DisplayExceptionMessage(exc);
				}
			}
			finally
			{
				userActionEnabled = true;
				Cursor.Current = Cursors.Arrow;
			}

		}

		// Reference: https://learn.microsoft.com/en-us/graph/api/user-post-users?view=graph-rest-1.0&tabs=csharp
		private async void buttonCreateUser_Click(object sender, EventArgs e)
		{
			if (!userActionEnabled) { return; }
			string infomssg = null;
			userActionEnabled = false;
			try
			{
				Cursor.Current = Cursors.WaitCursor;
				string domainName = _configuration.GetValue<string>("Domain");
				string password = textBoxPasswordForCreateUser.Text;
				string userName = textBoxNameForCreateUser.Text;
				GraphServiceClient graphServiceClient = _userAuthStatus.GraphServiceClient;
				await GraphApiWrapper.CreateUser(graphServiceClient, domainName, userName, password);
				infomssg = $"Successfully created user={userName}@{domainName}";
				Constants.DisplayInfoMessage(infomssg);
				await RefreshEntireScreen();
			}
			catch (Exception exc)
			{
				Constants.DisplayExceptionMessage(exc);
			}
			finally
			{
				userActionEnabled = true;
				Cursor.Current = Cursors.Arrow;
			}
		}
		// Reference: https://learn.microsoft.com/en-us/graph/api/group-post-groups?view=graph-rest-1.0&tabs=csharp
		private async void buttonCreateGroup_Click(object sender, EventArgs e)
		{
			if (!userActionEnabled) { return; }
			userActionEnabled = false;
			string infomssg = null;
			try
			{
				Cursor.Current = Cursors.WaitCursor;
				string groupOwner = comboBoxCreateGroupOwner.SelectedItem.ToString();
				string groupName = textBoxCreateGroupName.Text;
				GraphServiceClient graphServiceClient = _userAuthStatus.GraphServiceClient;
				await GraphApiWrapper.CreateGroup(graphServiceClient, groupName, textBoxCreateGroupDesc.Text, groupOwner);
				infomssg = $"Successfully created group={groupName} with owner={groupOwner}";
				Constants.DisplayInfoMessage(infomssg);
				await RefreshEntireScreen();
			}
			catch (Exception exc)
			{
				Constants.DisplayExceptionMessage(exc);
			}
			finally
			{
				userActionEnabled = true;
				Cursor.Current = Cursors.Arrow;
			}
		}
	}
}
