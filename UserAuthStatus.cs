using Microsoft.Graph;
using Microsoft.Graph.Models;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZWinformsCoreAppCallsMsgraph
{
	public class UserAuthStatus : IUserAuthStatus
	{
		public bool IsAuthenticated { get; set; } = false;
		public User SignedInUser { get; set; }
		// AuthResult will be null if user signed in with method #2.
		public AuthenticationResult AuthResult { get; set; }
		public GraphServiceClient GraphServiceClient { get; set; }
		public List<string> GroupsThatSignedInUserDirectMemberOf { get; set; }
		public List<string> GroupsThatSignedInUserTransitiveMemberOf { get; set; }
        public UserAuthStatus()
        {
			IsAuthenticated = false;
			SignedInUser = null;
			AuthResult = null;
			GraphServiceClient = null;
			GroupsThatSignedInUserDirectMemberOf = new List<string>();
			GroupsThatSignedInUserTransitiveMemberOf = new List<string>();
        }
		public void SignOut()
		{
			IsAuthenticated = false;
			SignedInUser = null;
			AuthResult = null;
			GraphServiceClient = null;
			GroupsThatSignedInUserDirectMemberOf = new List<string>();
			GroupsThatSignedInUserTransitiveMemberOf = new List<string>();
		}
        public bool IsSignedInUserDirectMemberOf(string GroupName)
		{
			return GroupsThatSignedInUserDirectMemberOf.Contains(GroupName);
		}

		public bool IsSignedInUserTransitiveMemberOf(string GroupName)
		{
			return GroupsThatSignedInUserTransitiveMemberOf.Contains(GroupName);
		}
	}
}
