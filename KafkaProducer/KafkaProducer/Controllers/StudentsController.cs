using KafkaProducer.Data.Model;
using KafkaProducer.Data.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KafkaProducer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private ProducerService _ProducerService;
        public StudentsController(ProducerService producerService)
        {
            _ProducerService = producerService;
        }

        [HttpPost]
        public async Task<ActionResult> PublishStudent(StudentModel model)
        {
            await _ProducerService.PublishStudentAsync(model);
            return StatusCode(StatusCodes.Status201Created);
        }
    }
}
