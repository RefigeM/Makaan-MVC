using Makaan2.Models.Enums;

namespace Makaan2.Extentions
{
	public static class RolesExtention
	{
		public static string GetRoles(this Roles role) 
		{
			return role switch
			{
				Roles.Admin => nameof(Roles.Admin),
				Roles.User => nameof(Roles.User)
			};
		}
	}
}
