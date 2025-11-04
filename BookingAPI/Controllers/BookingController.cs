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
        private readonly BookingBL.BookingProcess _bookingProcess;

        
        public AppointmentController(BookingBL.BookingProcess bookingProcess)
        {
            _bookingProcess = bookingProcess; 
        }

        [HttpGet]
        public IEnumerable<Appointment> GetAppointments()
        {
            
            return _bookingProcess.GetAll();
        }

        [HttpPost]
        public IActionResult AddAppointment([FromBody] Appointment request)
        {
            _bookingProcess.Add(request.Name, request.Birthday, request.Date);
            return Ok(true);
        }

        [HttpGet("search")]
        public IEnumerable<Appointment> SearchAppointment([FromQuery] string name)
        {
            return _bookingProcess.Search(name);
        }

        [HttpPatch("update")]
        public IActionResult UpdateAppointment([FromQuery] string name, [FromQuery] string newDate)
        {
            var result = _bookingProcess.Update(name, newDate);
            return Ok(result);
        }

        [HttpDelete]
        public IActionResult DeleteAppointment([FromQuery] string name)
        {
            var result = _bookingProcess.Delete(name);
            return Ok(result);
        }

       
        [HttpPost("SendTestEmail")]
        public IActionResult SendTestEmail([FromQuery] string email)
        {
            bool result = _bookingProcess.SendNotification(email, "Test Email", "This is a test from the API");
            return Ok(result);
        }
    }
}