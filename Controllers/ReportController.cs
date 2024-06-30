using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace TimeReportHH.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReportController : ControllerBase
    {
        private readonly ILogger<ReportController> _logger;
        private readonly PostgresContext db;

        public ReportController(ILogger<ReportController> logger)
        {
            _logger = logger;
            db = new PostgresContext();
        }

        [HttpGet("get/{id}/{date}")]
        public ApiResult Get(int id, DateOnly date)
        {
            var user = db.Users.Include(u => u.Reports).FirstOrDefault(u => u.Id == id);
            if (user != null)
                return new ApiResult("OK", user.Reports.Where(
                    r => r.Date.Year == date.Year && 
                    r.Date.Month == date.Month
                ));
            else
                return new ApiResult("User not found");
        }

        [HttpPost("add/{id}")]
        public ApiResult Add(int id, [FromBody] Report report)
        {
            var user = db.Users.Include(u => u.Reports).FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                user.Reports.Add(report);
                db.SaveChanges();
                return new ApiResult("OK", report);
            }
            else
                return new ApiResult("User not found");
            
        }

        [HttpPost("update")]
        public ApiResult Update([FromBody] Report upd)
        {
            if (upd.Id == 0)
                return new ApiResult("Report Id Is Required");
            var report = db.Reports.FirstOrDefault(r => r.Id == upd.Id);
            if (report != null)
            {
                report.Note = upd.Note;
                report.Hours = upd.Hours;
                report.Date = upd.Date;

                report = db.Reports.Update(report).Entity;
                db.SaveChanges();
                return new ApiResult("OK", report);
            }
            else
                return new ApiResult("Report not found");
        }

        [HttpPost("delete/{id}")]
        public ApiResult Delete(int id)
        {
            var report = db.Reports.Find(id);
            if (report != null)
            {
                db.Reports.Remove(report);
                db.SaveChanges();
                return new ApiResult("OK");
            }
            else
                return new ApiResult("Report not found");
        }
    }
}
