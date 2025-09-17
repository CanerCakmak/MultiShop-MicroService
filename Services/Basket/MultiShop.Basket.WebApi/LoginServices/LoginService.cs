namespace MultiShop.Basket.WebApi.LoginServices
{
    public class LoginService : ILoginService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LoginService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetUserID => _httpContextAccessor.HttpContext.User.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")?.Value;

        public bool IsUserValid(string userId)
        {
            var authenticatedUserId = GetUserID;
            return !string.IsNullOrEmpty(authenticatedUserId) && authenticatedUserId == userId;
        }
    }
}
