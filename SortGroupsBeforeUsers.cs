using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace ZWinformsCoreAppCallsMsgraph
{
	/// <summary>
	/// Sometimes we have a list of strings containing group names and User names.
	/// This sorts the list such that group names are first.
	/// It relies on the fact that user names end with domain (ex: Bill@kensmithsoftware.com where domain="kensmithsoftware.com")
	/// </summary>
	public class SortGroupsBeforeUsersHelper : IComparer<string>
	{
		private IConfiguration? _configuration;
        public SortGroupsBeforeUsersHelper()
        {
            _configuration = Program.ServiceProvider.GetRequiredService<IConfiguration>();
		}
        int IComparer<string>.Compare(string? stringA, string? stringB)  
		{
			string domain = _configuration.GetValue<string>("Domain");
			// Distinguish betweenn users and groups.
			// Users end with domain name. ex: Bill@kensmithsoftware.com (domain="kensmithsoftware.com")
			if (stringA.ToUpper().Equals(stringB.ToUpper()))
			{
				return 0;
			}
			else if (stringA.EndsWith(domain) && stringB.EndsWith(domain))
			{
				return string.Compare(stringA, stringB);
			}
			else if (!stringA.EndsWith(domain) && !stringB.EndsWith(domain))
			{
				return string.Compare(stringA, stringB);
			}
			else
			{
				return stringB.EndsWith(domain) ? -1 : 1;
			}
		}

	}
	
}
