namespace JWTLoginAuthenticationAuthorization.Models
{
    // We are not taking data from data base so we get data from constant
    public class UserConstants
    {
        public static List<UserModel> Users = new()
            {
                    new UserModel(){ Username="jayant",Password="J@321$",Role="Admin"},
                    new UserModel(){ Username="dev",Password="J@321$",Role="EndUser"},
            };
    }
}
