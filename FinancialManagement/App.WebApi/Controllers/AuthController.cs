using System;
using System.Web;
using System.Web.Http;

public class AuthController : ApiController
{
    private readonly JwtTokenService _jwtTokenService;

    public AuthController()
    {
        _jwtTokenService = new JwtTokenService();
    }

    [HttpPost]
    [Route("api/auth/login")]
    public IHttpActionResult Login([FromBody] LoginModel login)
    {
        if (login.Username == "user" && login.Password == "password")
        {
            var token = _jwtTokenService.GenerateToken(login.Username);

            // কুকি তৈরি করা
            var cookie = new HttpCookie("AuthToken", token)
            {
                HttpOnly = true, // JavaScript থেকে অ্যাক্সেস করা যাবে না
                Secure = true,   // শুধুমাত্র HTTPS এ কাজ করবে
                SameSite = SameSiteMode.Strict, // Cross-site রিকোয়েস্ট প্রতিরোধ
                Expires = DateTime.Now.AddHours(1) // কুকির মেয়াদ
            };

            // কুকি ক্লায়েন্টে পাঠানো
            HttpContext.Current.Response.Cookies.Add(cookie);

            return Ok(new { Message = "Token set in cookie" });
        }

        return Unauthorized();
    }

}

public class LoginModel
{
    public string Username { get; set; }
    public string Password { get; set; }
}
