namespace MultiShop.Basket.WebApi.LoginServices
{
    public interface ILoginService
    {
        public string GetUserID { get; }

        public bool IsUserValid(string userId);
    }
}
