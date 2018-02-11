namespace Others.Enum
{
    public class Enums
    {
        public enum DefaultRole
        {
            SystemAdmin,
            SuperAdmin,
            Admin
        }
        public static string ToFriendlyString(DefaultRole defaultRole)
        {
            switch (defaultRole)
            {
                case DefaultRole.SystemAdmin:
                    return "System Admin";
                case DefaultRole.SuperAdmin:
                    return "Super Admin";
                case DefaultRole.Admin:
                    return "Admin";
                default:
                    return "User";
            }
        }
        public enum DefaultUser
        {
            SystemAdmin,
            SuperAdmin
        }
    }
}
