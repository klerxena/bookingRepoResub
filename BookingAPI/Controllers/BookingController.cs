using BookingCommon;
using BookingBL;
using BookingDL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        BookingBL.BookingProcess bookingProcess = new BookingBL.BookingProcess();

        [HttpGet]
        public IEnumerable<Appointment> GetAppointments()
        {
            return bookingProcess.GetAll();
        }

        [HttpPost]
        public IActionResult AddAppointment([FromBody] Appointment request)
        {
            bookingProcess.Add(request.Name, request.Birthday, request.Date);
            return Ok(true);
        }

        [HttpGet("search")]
        public IEnumerable<Appointment> SearchAppointment([FromQuery] string name)
        {
            return bookingProcess.Search(name);
        }

        [HttpPatch("update")]
        public IActionResult UpdateAppointment([FromQuery] string name, [FromQuery] string newDate)
        {
            var result = bookingProcess.Update(name, newDate);
            return Ok(result);
        }

        [HttpDelete]
        public IActionResult DeleteAppointment([FromQuery] string name)
        {
            var result = bookingProcess.Delete(name);
            return Ok(result);
        }

        
    }
}