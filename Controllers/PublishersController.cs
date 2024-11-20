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
            var newPublisher =  _PublishersService.AddPublisher(publiser);
            return Created(nameof(AddPublisher), newPublisher);
        }

        [HttpGet("get-publisher-by-id/{id}")]
        public IActionResult GetPublisherById(int id)
        {
            var _response = _PublishersService.GetPublisherByID(id);
            if (_response != null)
            {
                return Ok(_response);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("get-publisher-books-with-authors/{id}")]
        public IActionResult GetPublisherData(int id)
        {
            var _response = _PublishersService.GetPublisherData(id);
            return Ok(_response);
        }

        [HttpDelete("delete-publisher-by")]
        public IActionResult DeletePublisherId(int id)
        {
            _PublishersService.DeletePublisherId(id);
            return Ok();
        }
    }
}