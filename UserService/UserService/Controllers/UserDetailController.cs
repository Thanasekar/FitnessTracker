using Microsoft.AspNetCore.Mvc;
using UserService.Entities;
using UserService.Services;

namespace UserService.Controllers
{
    [ApiController]
    [Route("api/UserDetail")]
    public class UserDetailController : ControllerBase
    {
        private readonly IUserDetailService _userDetailService;

        public UserDetailController(IUserDetailService userDetailService)
        { 
            _userDetailService = userDetailService; 
        }
        [HttpGet("{id}")]
        public IActionResult GetUserAccountById([FromRoute] Guid id)
        {
            var userDetailResponse = _userDetailService.GetUserDetailById(id);

            return StatusCode(StatusCodes.Status200OK, userDetailResponse);
        }

        [HttpGet]
        public IActionResult GetAllUserDetails()
        {
            var userDetails = _userDetailService.GetAllUserDetails();
            if (userDetails.Count == 0)
            {

                return StatusCode(StatusCodes.Status204NoContent);
            }
            return StatusCode(StatusCodes.Status200OK, userDetails);
        }

        // POST: UserDetailController/Create
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] UserDetailCreateDto user)
        {

            var userDetail = _userDetailService.CreateUserDetail(user);
            if (userDetail == null)
            {
                string message = "User Details already exist";
                return StatusCode(StatusCodes.Status201Created, message);
            }
            return StatusCode(StatusCodes.Status201Created, userDetail);
            
        }
    }
    
}
