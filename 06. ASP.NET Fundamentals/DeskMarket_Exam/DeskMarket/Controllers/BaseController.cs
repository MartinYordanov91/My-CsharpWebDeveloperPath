using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DeskMarket.Controllers;

[Authorize]
public class BaseController : Controller
{
    protected string GetUserId()
    {
        string userId = string.Empty;

        if (User != null)
        {
            userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        return userId;
    }

    protected string GetUserName()
    {
        string userName = string.Empty;

        if (User != null)
        {
            userName = User.FindFirstValue(ClaimTypes.Name);
        }

        return userName;
    }
}
