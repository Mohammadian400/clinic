using Microsoft.AspNetCore.Mvc;

namespace clinic.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public abstract class BaseApiController : ControllerBase
    {
    }
}
