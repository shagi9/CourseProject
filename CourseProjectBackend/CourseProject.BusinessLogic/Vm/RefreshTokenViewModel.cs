
namespace CourseProject.BusinessLogic.Vm
{
    public class RefreshTokenViewModel
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public RefreshTokenViewModel() : this("", "") { }
        public RefreshTokenViewModel(string token, string refreshToken)
        {
            Token = token;
            RefreshToken = refreshToken;
        }
    }
}
