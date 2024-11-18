using libreria_XGVC.Data.Services;
using libreria_XGVC.Data.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace libreria_XGVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        private PublishersService _PublishersService;
        public PublishersController(PublishersService publishersService)
        {
            _PublishersService = publishersService; 
        }
        [HttpPost("Add-publisher")]
        public IActionResult AddPublisher([FromBody] PublisherVM publiser)
        {
            _PublishersService.AddPublisher(publiser);
            return Ok();
        }
        [HttpGet("get-publisher-books-with-authors/{id}")]
        public IActionResult GetPublisherData(int id)
        {
            var _response = _PublishersService.GetPublisherData(id);
            return Ok(_response);
        }
    }
}