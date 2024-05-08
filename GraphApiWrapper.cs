using Microsoft.Graph.Models;
using Microsoft.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZWinformsCoreAppCallsMsgraph
{
	// Note: This code always grabs every page of users/groups immediately.
	//		In production scenarios you may want to process a page at a time (with GUI events determining when to get next page).
	public static class GraphApiWrapper
	{
		/// <summary>
		/// Get all users in tenant.
		/// </summary>
		public static async Task<List<string>> GetAllUsers(GraphServiceClient graphServiceClient)
		{
			List<DirectoryObject> directoryObjects = new List<DirectoryObject>();
			List<string> users = new List<string>();
			// Tricky! This can return multiple pages so we must process more pages if OdataNextLink != null.
			/*
			// Setting QueryParameters.Top=2 is only used during unit test to test multiple pages of results (OdataNextLink)
			var pageOfMemberObjects = await graphServiceClient.Users.GetAsync(requestConfiguration =>
				{
					requestConfiguration.QueryParameters.Top = 2;

				});
			*/
			var pageOfMemberObjects = await graphServiceClient.Users.GetAsync();
			if ((pageOfMemberObjects != null) && (pageOfMemberObjects.Value != null))
			{
				directoryObjects.AddRange(pageOfMemberObjects.Value);
				while (pageOfMemberObjects.OdataNextLink != null)
				{
					string nextUrl = pageOfMemberObjects.OdataNextLink;
					pageOfMemberObjects = await graphServiceClient.Users.WithUrl(nextUrl).GetAsync();
					directoryObjects.AddRange(pageOfMemberObjects.Value);
				}
			}
			foreach (var dirobj in directoryObjects)
			{
				if (dirobj.GetType() != typeof(User)) continue;
				//users.Add(((User)dirobj).DisplayName);
				users.Add(((User)dirobj).UserPrincipalName);
			}
			return users;
		}
		/// <summary>
		/// Get all groups in tenant.
		/// </summary>
		public static async Task<List<string>> GetAllGroups(GraphServiceClient graphServiceClient)
		{
			List<DirectoryObject> directoryObjects = new List<DirectoryObject>();
			List<string> groups = new List<string>();
			// Tricky! This can return multiple pages so we must process more pages if OdataNextLink != null.
			var pageOfMemberObjects = await graphServiceClient.Groups.GetAsync();
			if ((pageOfMemberObjects != null) && (pageOfMemberObjects.Value != null))
			{
				directoryObjects.AddRange(pageOfMemberObjects.Value);
				while (pageOfMemberObjects.OdataNextLink != null)
				{
					string nextUrl = pageOfMemberObjects.OdataNextLink;
					pageOfMemberObjects = await graphServiceClient.Groups.WithUrl(nextUrl).GetAsync();
					directoryObjects.AddRange(pageOfMemberObjects.Value);
				}
			}
			foreach (var dirobj in directoryObjects)
			{
				if (dirobj.GetType() != typeof(Group)) continue;
				groups.Add(((Group)dirobj).DisplayName);
			}
			return groups;
		}
		/// <summary>
		/// Determine if user exists (based on UserPrincipalName)
		/// </summary>
		public static async Task<bool> UserExists(GraphServiceClient graphServiceClient, string userPrincipalName)
		{
			bool exists = await GetUserIdForUserPrincipalName(graphServiceClient, userPrincipalName) != null;
			return exists;
		}
		/// <summary>
		/// Determine if group exists.
		/// </summary>
		public static async Task<bool> GroupExists(GraphServiceClient graphServiceClient, string groupName)
		{
			bool exists = await getGroupId(graphServiceClient, groupName) != null;
			return exists;
		}

		/// <summary>
		/// Get userId for provided UserPrincipalName.  Returns null if no user found.
		/// </summary>
		public static async Task<string> GetUserIdForUserPrincipalName(GraphServiceClient graphServiceClient, string userPrincipalName)
		{
			string userId = null;
			var users = await graphServiceClient.Users.GetAsync((requestConfiguration) =>
			{
				requestConfiguration.QueryParameters.Filter = $"UserPrincipalName eq '{userPrincipalName}'";
				requestConfiguration.Headers.Add("ConsistencyLevel", "eventual");
			});
			if ((users != null) && (users.Value.Count == 1))
			{
				userId = users.Value[0].Id;
			}
			return userId;
		}
		public static async Task<User> GetUserById(GraphServiceClient graphServiceClient, string id)
		{
			User user = await graphServiceClient.Users[id].GetAsync();
			return user;
		}
		
		/// <summary>
		/// Get all the groups that a user is a DIRECT member of.
		/// </summary>
		public static async Task<List<string>> getGroupsThatUserDirectMemberOf(GraphServiceClient graphServiceClient, string userId)
		{
			List<DirectoryObject> directoryObjects = new List<DirectoryObject>();
			List<string> groups = new List<string>();
			// 4/25/2024 Userid should never be null but it is null after create user!
			if (userId != null)
			{
				// Tricky! This can return multiple pages so we must process more pages if OdataNextLink != null.
				var pageOfMemberObjects = await graphServiceClient.Users[userId].MemberOf.GetAsync();

				if ((pageOfMemberObjects != null) && (pageOfMemberObjects.Value != null))
				{
					directoryObjects.AddRange(pageOfMemberObjects.Value);
					while (pageOfMemberObjects.OdataNextLink != null)
					{
						string nextUrl = pageOfMemberObjects.OdataNextLink;
						pageOfMemberObjects = await graphServiceClient.Me.MemberOf.WithUrl(nextUrl).GetAsync();
						directoryObjects.AddRange(pageOfMemberObjects.Value);
					}
				}
				foreach (var dirobj in directoryObjects)
				{
					if (dirobj.GetType() != typeof(Group)) continue;
					groups.Add(((Group)dirobj).DisplayName);
				}
			}
			else
			{
				// 4/25/2024 Userid should never be null but it is null after create user!
				//Constants.DisplayErrorMessage("WTF Direct ???");
			}
			return groups;
		}
		/// <summary>
		/// Get all the groups that a user is a TRANSITIVE member of.
		/// </summary>
		public static async Task<List<string>> getGroupsThatUserTransitiveMemberOf(GraphServiceClient graphServiceClient, string userId)
		{
			List<DirectoryObject> directoryObjects = new List<DirectoryObject>();
			List<string> groups = new List<string>();
			// 4/25/2024 Userid should never be null but it is null after create user!
			if (userId != null)
			{
				// Tricky! This can return multiple pages so we must process more pages if OdataNextLink != null.
				var pageOfMemberObjects = await graphServiceClient.Users[userId].TransitiveMemberOf.GetAsync();

				if ((pageOfMemberObjects != null) && (pageOfMemberObjects.Value != null))
				{
					directoryObjects.AddRange(pageOfMemberObjects.Value);
					while (pageOfMemberObjects.OdataNextLink != null)
					{
						string nextUrl = pageOfMemberObjects.OdataNextLink;
						pageOfMemberObjects = await graphServiceClient.Users[userId].TransitiveMemberOf.WithUrl(nextUrl).GetAsync();
						directoryObjects.AddRange(pageOfMemberObjects.Value);
					}
				}
				foreach (var dirobj in directoryObjects)
				{
					if (dirobj.GetType() != typeof(Group)) continue;
					groups.Add(((Group)dirobj).DisplayName);
				}
			}
			else
			{
				// 4/25/2024 Userid should never be null but it is null after create user!
				//Constants.DisplayErrorMessage("WTF Transitive???");
			}
			return groups;
		}
		
		/// <summary>
		/// Get all the groups that I am a DIRECT member of.
		/// </summary>
		public static async Task<List<string>> getGroupsMeDirectMemberOf(GraphServiceClient graphServiceClient)
		{
			List<DirectoryObject> directoryObjects = new List<DirectoryObject>();
			List<string> groups = new List<string>();
			// Tricky! This can return multiple pages so we must process more pages if OdataNextLink != null.
			var pageOfMemberObjects = await graphServiceClient.Me.MemberOf.GetAsync();

			if ((pageOfMemberObjects != null) && (pageOfMemberObjects.Value != null))
			{
				directoryObjects.AddRange(pageOfMemberObjects.Value);
				while (pageOfMemberObjects.OdataNextLink != null)
				{
					string nextUrl = pageOfMemberObjects.OdataNextLink;
					pageOfMemberObjects = await graphServiceClient.Me.MemberOf.WithUrl(nextUrl).GetAsync();
					directoryObjects.AddRange(pageOfMemberObjects.Value);
				}
			}
			foreach (var dirobj in directoryObjects)
			{
				if (dirobj.GetType() != typeof(Group)) continue;
				groups.Add(((Group)dirobj).DisplayName);
			}

			return groups;
		}
		/// <summary>
		/// Get all the groups that I am a TRANSITIVE member of.
		/// </summary>
		public static async Task<List<string>> getGroupsMeTransitiveMemberOf(GraphServiceClient graphServiceClient)
		{
			List<DirectoryObject> directoryObjects = new List<DirectoryObject>();
			List<string> groups = new List<string>();
			// Tricky! This can return multiple pages so we must process more pages if OdataNextLink != null.
			var pageOfMemberObjects = await graphServiceClient.Me.TransitiveMemberOf.GetAsync();

			if ((pageOfMemberObjects != null) && (pageOfMemberObjects.Value != null))
			{
				directoryObjects.AddRange(pageOfMemberObjects.Value);
				while (pageOfMemberObjects.OdataNextLink != null)
				{
					string nextUrl = pageOfMemberObjects.OdataNextLink;
					pageOfMemberObjects = await graphServiceClient.Me.TransitiveMemberOf.WithUrl(nextUrl).GetAsync();
					directoryObjects.AddRange(pageOfMemberObjects.Value);
				}
			}
			foreach (var dirobj in directoryObjects)
			{
				if (dirobj.GetType() != typeof(Group)) continue;
				groups.Add(((Group)dirobj).DisplayName);
			}

			return groups;
		}
		/// <summary>
		/// Get all transitive members of a group. 
		/// Note that members may be of type (user, group, service principal, and others!)
		/// Returns null if groupName does not exist; else returns list of groups which may have 0 elements.
		/// Requires permission: ??
		/// </summary>
		public static async Task<List<string>> getTransitiveMembersOfGroupNamed(GraphServiceClient graphServiceClient, string groupName)
		{
			List<string> groups = null;
			string groupId = await getGroupId(graphServiceClient, groupName);
			if (groupId != null)
			{
				groups = await getTransitiveMembersOfGroup(graphServiceClient, groupId);
			}
			return groups;
		}
		/// <summary>
		/// Get groupId for provided group name.  Returns null if no group found.
		/// </summary>
		private static async Task<string> getGroupId(GraphServiceClient graphServiceClient, string groupName)
		{
			string groupId = null;
			var groups = await graphServiceClient.Groups.GetAsync((requestConfiguration) =>
			{
				requestConfiguration.QueryParameters.Filter = $"displayname eq '{groupName}'";
				requestConfiguration.Headers.Add("ConsistencyLevel", "eventual");
			});
			if ((groups != null) && (groups.Value.Count == 1))
			{
				groupId = groups.Value[0].Id;
			}
			return groupId;
		}
		
		/// <summary>
		/// Get all direct members of a group. 
		/// Note that members may be of type (user, group, service principal, and others!)
		/// Returns null if groupName does not exist; else returns list of groups which may have 0 elements.
		/// Requires permission: ??
		/// </summary>
		public static async Task<List<string>> getDirectMembersOfGroupNamed(GraphServiceClient graphServiceClient, string groupName)
		{
			List<string> groups = null;
			string groupId = await getGroupId(graphServiceClient, groupName);
			if (groupId != null)
			{
				groups = await getDirectMembersOfGroup(graphServiceClient, groupId);
			}
			return groups;
		}
		
		/// <summary>
		/// Get all transitive members of a group. (Useful helper method: getGroupId which gets groupId for a given groupName!)
		/// Note that members may be of type (user, group, service principal, and others!)
		/// Requires permission: "user.read.all"
		/// </summary>
		private static async Task<List<string>> getTransitiveMembersOfGroup(GraphServiceClient graphServiceClient, string groupId)
		{
			List<DirectoryObject> directoryObjects = new List<DirectoryObject>();
			List<string> groups = new List<string>();
			// Tricky! This can return multiple pages so we must process more pages if OdataNextLink != null.
			var pageOfMemberObjects = await graphServiceClient.Groups[groupId].TransitiveMembers.GetAsync();

			if ((pageOfMemberObjects != null) && (pageOfMemberObjects.Value != null))
			{
				directoryObjects.AddRange(pageOfMemberObjects.Value);
				while (pageOfMemberObjects.OdataNextLink != null)
				{
					string nextUrl = pageOfMemberObjects.OdataNextLink;
					pageOfMemberObjects = await graphServiceClient.Groups[groupId].TransitiveMembers.WithUrl(nextUrl).GetAsync();
					directoryObjects.AddRange(pageOfMemberObjects.Value);
				}
			}
			// 4/15/2024 You need permission, "user.read.all"; otherwise, UserPrincipalName will be null for User entities. 
			foreach (var dirobj in directoryObjects)
			{
				if (dirobj.GetType() == typeof(User))
				{
					string userPrincipalName = ((User)dirobj).UserPrincipalName;
					string Id = ((User)dirobj).Id;
					/* @ken commented out since we grant permission, "user.read.all"
					if (displayName == null)
					{
						User user = await GetUserById(graphServiceClient, Id);
						displayName = user.DisplayName;
					}
					*/
					//groups.Add($"User: {displayName}  ID: {Id}");
					//groups.Add($"User: {userPrincipalName}");
					groups.Add(userPrincipalName);


				}
				if (dirobj.GetType() == typeof(Group))
				{
					//groups.Add("Group: " + ((Group)dirobj).DisplayName);
					groups.Add(((Group)dirobj).DisplayName);
				}
			}
			return groups;
		}
		/// <summary>
		/// Get all direct members of a group. (Useful helper method: getGroupId which gets groupId for a given groupName!)
		/// Note that members may be of type (user, group, service principal, and others!)
		/// Requires permission: "user.read.all"
		/// </summary>
		private static async Task<List<string>> getDirectMembersOfGroup(GraphServiceClient graphServiceClient, string groupId)
		{
			List<DirectoryObject> directoryObjects = new List<DirectoryObject>();
			List<string> groups = new List<string>();
			// Tricky! This can return multiple pages so we must process more pages if OdataNextLink != null.
			var pageOfMemberObjects = await graphServiceClient.Groups[groupId].Members.GetAsync();

			if ((pageOfMemberObjects != null) && (pageOfMemberObjects.Value != null))
			{
				directoryObjects.AddRange(pageOfMemberObjects.Value);
				while (pageOfMemberObjects.OdataNextLink != null)
				{
					string nextUrl = pageOfMemberObjects.OdataNextLink;
					pageOfMemberObjects = await graphServiceClient.Groups[groupId].TransitiveMembers.WithUrl(nextUrl).GetAsync();
					directoryObjects.AddRange(pageOfMemberObjects.Value);
				}
			}
			// 4/15/2024 You need permission, "user.read.all"; otherwise, userPrincipalName will be null for User entities. 
			foreach (var dirobj in directoryObjects)
			{
				if (dirobj.GetType() == typeof(User))
				{
					string userPrincipalName = ((User)dirobj).UserPrincipalName;
					string Id = ((User)dirobj).Id;
					/* @ken commented out since we grant permission, "user.read.all"
					if (displayName == null)
					{
						User user = await GetUserById(graphServiceClient, Id);
						displayName = user.DisplayName;
					}
					*/
					//groups.Add($"User: {displayName}  ID: {Id}");
					//groups.Add($"User: userPrincipalName");
					groups.Add(userPrincipalName);

				}
				if (dirobj.GetType() == typeof(Group))
				{
					//groups.Add("Group: " + ((Group)dirobj).DisplayName);
					groups.Add(((Group)dirobj).DisplayName);

				}
			}
			return groups;
		}
		// ==============================================================
		// APIs that update groups or users
		// ==============================================================
		#region APIs that update groups or users
		/// <summary>
		/// Adds existing user to existing group.
		/// Scopes must include: "GroupMember.ReadWrite.All" and the signed-in user must have authority to write to the group (Group owner, GroupAdministrator, etc)
		/// Throws exception if user or group do not exist.
		/// Nothing happens if user is already in the group.
		/// </summary>
		public static async Task AddUserToGroup(GraphServiceClient graphServiceClient, string userPrincipalName, string groupName)
		{
			string userId = await GetUserIdForUserPrincipalName(graphServiceClient, userPrincipalName);
			string groupId = await getGroupId(graphServiceClient, groupName);
			if (userId == null) { throw new Exception($"User does not exist: {userPrincipalName}"); }
			if (groupId == null) { throw new Exception($"Group does not exist: {groupName}"); }
			//var KengroupAId = "c688cefe-c61f-45de-95d1-0be3b5623da7";   // KengroupA ???
			//var EdId = "3a6060bf-971e-4062-9d65-b88f232d9cef";          // id for Ed@kensmithsoftware.com
			var requestBody = new ReferenceCreate
			{
				OdataId = $"https://graph.microsoft.com/v1.0/directoryObjects/{userId}",
			};

			// Reference: https://learn.microsoft.com/en-us/graph/sdks/create-client?from=snippets&tabs=csharp
			await graphServiceClient.Groups[$"{groupId}"].Members.Ref.PostAsync(requestBody);
		}
		/// <summary>
		/// Adds existing user to existing group.
		/// Scopes must include: "GroupMember.ReadWrite.All" and the signed-in user must have authority to write to the group (Group owner, GroupAdministrator, etc)
		/// Throws exception if user or group do not exist.
		/// Nothing happens if user is already in the group.
		/// </summary>
		public static async Task CreateGroup(GraphServiceClient graphServiceClient, string groupName, string groupDesc, string groupOwner)
		{
			string groupOwnerId = await GetUserIdForUserPrincipalName(graphServiceClient, groupOwner);
			if (groupOwnerId == null) { throw new Exception($"User does not exist: {groupOwner}"); }
			var requestBody = new Group
			{
				Description = groupDesc,
				DisplayName = groupName,
				GroupTypes = new List<string>
				{
				},
				MailEnabled = false,
				MailNickname = "TBD",
				SecurityEnabled = true,
				AdditionalData = new Dictionary<string, object>
				{
					{
						"owners@odata.bind" , new List<string>
						{
							$"https://graph.microsoft.com/v1.0/users/{groupOwnerId}",
						}
					},
				},
			};

			// Reference: https://learn.microsoft.com/en-us/graph/sdks/create-client?from=snippets&tabs=csharp
			await graphServiceClient.Groups.PostAsync(requestBody);
		}
		public static async Task CreateUser(GraphServiceClient graphServiceClient, string domainName, string userName, string password)
		{
			var requestBody = new User
			{
				AccountEnabled = true,
				DisplayName = userName,
				MailNickname = userName,
				UserPrincipalName = $"{userName}@{domainName}",
				PasswordProfile = new PasswordProfile
				{
					ForceChangePasswordNextSignIn = false, // Normally this would be true!!!
					Password = password,
				},
			};

			// To initialize your graphClient, see https://learn.microsoft.com/en-us/graph/sdks/create-client?from=snippets&tabs=csharp
			var result = await graphServiceClient.Users.PostAsync(requestBody);
		}
		#endregion
	}
}
