using System.Collections.Immutable;

namespace JobPost.API.Constants
{
   
public static class Cons
    {
        public static readonly ImmutableList<string> Roles = ImmutableList.Create("Admin", "Employer", "Employee");

        public static string getAdminRole()
        {
            return Roles[0];
        }
        public static string getEmployerRole()
        {
            return Roles[1];
        }
        public static string getEmployeeRole()
        {
            return Roles[2];
        }
    }
}
