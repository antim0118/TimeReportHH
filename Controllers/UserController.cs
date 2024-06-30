using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace TimeReportHH.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly PostgresContext db;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
            db = new PostgresContext();
        }

        [HttpGet("get")]
        public ApiResult Get()
        {
            return new ApiResult("OK", db.Users.Include(u => u.Reports).ToList());
        }

        [HttpGet("get/{id}")]
        public ApiResult Get(int id)
        {
            var user = db.Users.Include(u => u.Reports).FirstOrDefault(u=>u.Id == id);
            if (user != null)
                return new ApiResult("OK", user);
            else
                return new ApiResult("User not found");
        }

        [HttpPost("add")]
        public ApiResult Add([FromBody] User user)
        {
            user = db.Users.Add(user).Entity;
            db.SaveChanges();
            return new ApiResult("OK", user);
        }

        [HttpPost("update")]
        public ApiResult Update([FromBody] User upd)
        {
            if (upd.Id == 0)
                return new ApiResult("User Id Is Required");
            var user = db.Users.Include(u => u.Reports).FirstOrDefault(u => u.Id == upd.Id);
            if (user != null)
            {
                user.Email = upd.Email;
                user.Firstname = upd.Firstname;
                user.Secondname = upd.Secondname;
                user.Patronymic = upd.Patronymic;

                user = db.Users.Update(user).Entity;
                db.SaveChanges();
                return new ApiResult("OK", user);
            }
            else
                return new ApiResult("User not found");
        }

        [HttpPost("delete/{id}")]
        public ApiResult Delete(int id)
        {
            var user = db.Users.Find(id);
            if (user != null)
            {
                db.Users.Remove(user);
                db.SaveChanges();
                return new ApiResult("OK");
            }
            else
                return new ApiResult("User not found");
        }
    }
}
