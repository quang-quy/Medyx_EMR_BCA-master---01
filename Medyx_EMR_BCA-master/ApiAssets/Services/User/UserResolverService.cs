using Medyx_EMR_BCA.ApiAssets.Helpers;
using Medyx_EMR_BCA.ApiAssets.Models.Session;
using Microsoft.AspNetCore.Http;

namespace Medyx_EMR_BCA.ApiAssets.Services.User
{
    public interface IUserResolverService
    {
        string GetUser();
    }
    public class UserResolverService : IUserResolverService
    {
        private readonly IHttpContextAccessor accessor;
        public UserResolverService(IHttpContextAccessor accessor)
        {
            this.accessor = accessor;
        }
        public string GetUser()
        {
            var session = accessor?.HttpContext?.Session;
            var user = SessionHelper.GetObjectFromJson<UserSession>(session, "UserProfileSessionData");
            if (user != null)
            {
                return user.Pub_sNguoiSD;
            }
            return null;
        }
    }

}
