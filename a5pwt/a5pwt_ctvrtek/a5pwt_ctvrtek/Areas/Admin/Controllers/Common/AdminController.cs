using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace a5pwt_ctvrtek.Areas.Admin.Controllers.Common
{
    [Authorize(Roles = "Manager, Admin"), Area("Admin")]
    public class AdminController : Controller
    {
    }
}