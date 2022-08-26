using GymServices.TrainerService.Interface;
using GymServices.TrainerService.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GymAPI.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    [Route("api/[controller]/[action]")]
    public class TrainerController : ControllerBase
    {
        private readonly ITrainer _ITrainer;
        public TrainerController(ITrainer ITrainer)
        {
            _ITrainer = ITrainer;
        }


        [HttpPost]
        public string GetTrainer([FromBody] string email)
        {
            return _ITrainer.GetTrainer(email);
        }

        [HttpPost]
        public ActionResult InsertTrainer([FromBody] TrainerModel TrainerModel)
        {
            try
            {
                _ITrainer.InsertUser(TrainerModel);
                return Ok(new { response = "123" });
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


        [HttpPost]
        public string GetApps()
        {
            return _ITrainer.GetApps();
        }
    }
}
