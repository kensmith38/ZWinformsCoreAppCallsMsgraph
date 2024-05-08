using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Graph;
using Microsoft.Graph.Models;
using Microsoft.Identity.Client;


namespace ZWinformsCoreAppCallsMsgraph
{
	// Design: Microsoft Entra is used to Authenticate a user
	public interface IUserAuthStatus
	{
        bool IsAuthenticated { get; set; }
		User SignedInUser { get; set; }
		// AuthResult will be null if user signed in with method #2.
		AuthenticationResult AuthResult { get; set; }
		GraphServiceClient GraphServiceClient { get; set; }
		List<string> GroupsThatSignedInUserDirectMemberOf { get; set; }
		// A user is a transitive member of any group that the user is a
		// direct member of plus all higher level groups in that hierarchy.
		List<string> GroupsThatSignedInUserTransitiveMemberOf { get; set; }
		void SignOut();
		bool IsSignedInUserDirectMemberOf(string GroupName);
		bool IsSignedInUserTransitiveMemberOf(string GroupName);
	}
}
