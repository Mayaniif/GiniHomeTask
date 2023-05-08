
using Microsoft.AspNetCore.Mvc;

namespace GiniHomeTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookmarkController : ControllerBase
    {
       
        
        [HttpGet("{key}")]
        public IActionResult GetSessionData()
        {
            var sessionData = new Dictionary<string, string>();

            foreach (var key in HttpContext.Session.Keys)
            {
                sessionData[key] = HttpContext.Session.GetString(key);
            }
            return Ok(sessionData);

        }


        [HttpPost("{key}")]
        public IActionResult Post([FromBody] object value,string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                return BadRequest("missing key");
            }
            else if (value == null)
            {
                return BadRequest("Missing value");
            }
            else if (HttpContext.Session.GetString(key) != null)
            {
                HttpContext.Session.SetString(key, value.ToString());
                return Ok();
            }
            else
            {
                HttpContext.Session.Remove(key);
                return Ok();
            }
        }

        
    }
}
