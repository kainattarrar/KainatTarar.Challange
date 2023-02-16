using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace KainatTarar.Challange.API.Controllers.Base
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("_myAllowSpecificOrigins")]
    [Authorize]
    public abstract class BaseController:ControllerBase
    {
    }
}
