using Data.Entity;
using Framework.Controller;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : BaseController<Account>
    {
        public AccountController(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }
    }
}
