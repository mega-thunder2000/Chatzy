using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDAP
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryEntry de = new DirectoryEntry("LDAP://ust-viscount.stthomas.edu/OU=Distribution Groups,DC=stthomas,DC=edu")
            {
                Username = "chou0015",
                Password = "Stthomas1"
            };

            DirectorySearcher ds = new DirectorySearcher(de)
            {
                //Filter = "(&(pwdLastSet=*)(displayName=*))",
                PageSize = int.MaxValue
            }; 
            //ds.PropertiesToLoad.AddRange(new string[] { "displayName", "cn" });
            var groups = ds.FindAll();

            foreach (SearchResult sr in groups)
            {
                //File.AppendAllText("UST_LDAP_GROUPS.csv", string.Format("{0},{1}@stthomas.edu\n", sr.Properties["displayName"][0].ToString(), sr.Properties["cn"][0].ToString()));
            }
        }
    }
}
