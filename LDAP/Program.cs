using System.DirectoryServices;
using System.IO;
using System.Linq;

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
                PageSize = int.MaxValue
            }; 
            var groups = ds.FindAll();

            using (StreamWriter sw = new StreamWriter("LDAP__UST_Distribution_Groups.txt"))
            {
                foreach (SearchResult sr in groups)
                {
                    sw.WriteLine(string.Format("Path: {0}", sr.Path));

                    foreach (string property in sr.Properties.PropertyNames.Cast<string>().OrderBy(ch => ch))
                    {
                        sw.WriteLine("\t {0}", property);

                        foreach (var item in sr.Properties[property])
                        {
                            sw.WriteLine("\t\t" + item);
                        }
                    }

                    sw.WriteLine();
                    //File.AppendAllText("UST_LDAP_GROUPS.csv", string.Format("{0},{1}@stthomas.edu\n", sr.Properties["displayName"][0].ToString(), sr.Properties["cn"][0].ToString()));
                }
            }
        }
    }
}
