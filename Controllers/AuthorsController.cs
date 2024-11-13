using libreria_XGVC.Data.Services;
using libreria_XGVC.Data.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace libreria_XGVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private AuthorsService _authorsServices;
        public AuthorsController(AuthorsService authorsServices)
        {
            _authorsServices = authorsServices;
        }
        [HttpPost("Add-author")]
        public IActionResult AddAuthor([FromBody] AuthorVM author)
        {
            _authorsServices.AddAuthor(author);
            return Ok();
        }
    }
}
