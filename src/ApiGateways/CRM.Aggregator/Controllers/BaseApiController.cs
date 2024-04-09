
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CRM.Aggregator.Controllers
{

    [ApiController]
    [Route("api/v1/[controller]")]
    public abstract class BaseApiController : ControllerBase
    {
    }
}
