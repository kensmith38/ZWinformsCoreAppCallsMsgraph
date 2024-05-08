using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;

namespace ZWinformsCoreAppCallsMsgraph
{
	// Reference: https://gist.github.com/schaabs/edbce217621e5ce5aca1a8fa6f711952
	// @ken 4/11/2024 Ken wanted to create a GraphServiceClient using an AccessToken that was previously acquired!
	// @ken Why doesn't GraphServiceClient have a constructor to do this?  Or is this technique a bad idea?
	internal class CustomTokenCredential : TokenCredential
	{
		private AccessToken _token;
		// TODO Find out why AccessToken constrcutor has parameter for expiresOn which is totally ignored here!
		//		Also, the original token already has a claim "exp" which specifies expiration!
		public CustomTokenCredential(string token) : this(new AccessToken(token, DateTimeOffset.MinValue)) { }
		//public CustomTokenCredential(string token) : this(new AccessToken(token, new DateTimeOffset(DateTime.Now.AddSeconds(10)))) { }

		public CustomTokenCredential(AccessToken accessToken)
		{
			_token = accessToken;
		}
		public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
		{
			return _token;
		}
		public override ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
		{
			return new ValueTask<AccessToken>(_token);
		}
	}
}
