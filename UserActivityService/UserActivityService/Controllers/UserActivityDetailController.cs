using Microsoft.AspNetCore.Mvc;
using UserActivityService.Entities;
using UserActivityService.Services;

namespace UserActivityService.Controllers
{
    [ApiController]
    [Route("api/UserActivityDetail")]
    public class UserActivityDetailController : ControllerBase
    {
        private readonly IUserActivityDetailService _userActivityDetailService;

        public UserActivityDetailController(IUserActivityDetailService userActivityDetailService)
        {
            _userActivityDetailService = userActivityDetailService; 
        }
        [HttpGet("{id}")]
        public IActionResult GetUserAccountById([FromRoute] Guid id)
        {
            var userDetailResponse = _userActivityDetailService.GetUserDetailById(id);

            return StatusCode(StatusCodes.Status200OK, userDetailResponse);
        }

        [HttpGet]
        public IActionResult GetAllUserDetails()
        {
            var userDetails = _userActivityDetailService.GetAllUserDetails();
            if (userDetails.Count == 0)
            {

                return StatusCode(StatusCodes.Status204NoContent);
            }
            return StatusCode(StatusCodes.Status200OK, userDetails);
        }

        // POST: UserActivityDetailController/Create
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] UserActivityCreateDto user)
        {

            var userDetail = _userActivityDetailService.CreateUserDetail(user);
            return StatusCode(StatusCodes.Status201Created, userDetail);
            
        }
    }
    
}
