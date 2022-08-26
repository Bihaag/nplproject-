using GymAPI.Models;
using GymServices.UsersService;
using GymServices.UsersService.Model;
using GymServices.Utils;
using GymServices.Utils.Interface;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace GymAPI.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    [Route("api/[controller]/[action]")]
    public class UsersController : ControllerBase
    {
        private readonly IUsers _Iusers;
        private readonly IMail _IMails;
        public UsersController(IUsers Iusers, IMail IMails)
        {
            _Iusers = Iusers;
            _IMails = IMails;

        }

        [HttpPost]
        public string GetAllUser()
        {
             return _Iusers.GetAllUser();
        }

        [HttpPost]
        public string GetAllUserData([FromBody] string email)
        {
            return _Iusers.GetUserData(email);
        }

        [HttpPost]
        public ActionResult InsertUser([FromBody] UsersModel UsersModel) 
        {
            try
            {
                _Iusers.InsertUser(UsersModel);
                 return Ok(new { response = "123" });
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public ActionResult UpdateUser([FromBody] UsersModel UsersModel) 
        {
            try
            {
                _Iusers.UpdateUser(UsersModel);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public ActionResult GetPassword([FromBody] string email) 
        {
            string password = _Iusers.GetUserPasswordFromEmail(email);

            if (password == null) 
            {
                return BadRequest();
            }

            string p = JsonConvert.DeserializeObject<List<PasswordViewModel>>(password).First().Password;

            if (p == null) 
            {
                return BadRequest();
            }

            _IMails.EmailSend(p, email,"Password Reset");
            return Ok(new { response = "Password Found" });

        }

        [HttpPost]
        public ActionResult UpdateUserCourse([FromBody] UsersCourseModel UsersCourseModel)
        {
            try
            {
                _Iusers.UpdateUserCourse(UsersCourseModel);
                return Ok(new { response = "123" });
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
