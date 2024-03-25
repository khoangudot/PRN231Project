using System;
using System.IdentityModel.Tokens.Jwt;

namespace StoryFront.Helpers
{
    public static class CheckService
    {
        public static bool IsAdmin(string token)
        {
            if (token == null)
            {
                return false;
            }
            else
            {
                var handler = new JwtSecurityTokenHandler();
                var jwtSecurityToken = handler.ReadJwtToken(token);
                var role = jwtSecurityToken.Claims.FirstOrDefault(c => c.Type == "Role")?.Value;
                if (role == "1")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public static bool IsUser(string token)
        {
            if (token == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static int GetUserId(string token)
        {
            if (token == null)
            {
                return 0;
            }
            else
            {
                var handler = new JwtSecurityTokenHandler();
                var jwtSecurityToken = handler.ReadJwtToken(token);
                var userIdClaim = jwtSecurityToken.Claims.FirstOrDefault(c => c.Type == "Id")?.Value;

                int userId;
                if (int.TryParse(userIdClaim, out userId))
                {
                    return userId;
                }
                else
                {
                    return 0;
                }

            }
        }
    }
}

