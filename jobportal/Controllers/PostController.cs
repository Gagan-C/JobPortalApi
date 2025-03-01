using jobportal.Database;
using jobportal.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace jobportal.Controllers
{
    [Route("/api/[controller]")]
    public class PostController:ControllerBase
    {
        private readonly IPostService _postService;
        public PostController(IPostService postService)
        {
            _postService = postService;
        }
        [HttpGet]
        [Authorize]
        public IActionResult GetPost()
        {
            return Ok(_postService.GetPostValue());
        }
        [HttpPost]
        [Authorize]
        public IActionResult PostJob([FromBody] PostJobDTO postJobDTO)
        {
            var result = _postService.PostJob(postJobDTO);
            if (result > 0)
            {
                return StatusCode(201, new { message = "Post created successfully" });
            }
            else if (result == -1)
            {
                return StatusCode(500, new { message = "Unable to find Employer" });
            }
            return StatusCode(500, new { message = "Unable to create post." });
        }
    }
}
