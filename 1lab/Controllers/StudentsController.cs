using _1lab.ActionFilters;
using AutoMapper;
using Azure;
using Entities.Models;
using Entities.RequestFeatures;
using Entities1._0.DataTransferObjects;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace _1lab.Controllers
{
    [Route("api/ayditoryas/{ayditoryaId}/students")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public StudentsController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetStudentsForAyditorya(Guid ayditoryaId, [FromQuery] StudentParameters studentParameters)
        {
            if (!studentParameters.ValidAgeRange)
                return BadRequest("Max age can't be less than min age.");

            var ayditorya = await _repository.Ayditorya.GetAyditoryaAsync(ayditoryaId, trackChanges: false);
            if (ayditorya == null)
            {
                _logger.LogInfo($"Ayditorya with id: {ayditoryaId} doesn't exist in the database.");
                return NotFound();
            }

            var studentsFromDb = await _repository.Student.GetStudentsAsync(ayditoryaId, studentParameters, trackChanges: false);
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(studentsFromDb.MetaData));

            var studentsDto = _mapper.Map<IEnumerable<StudentDto>>(studentsFromDb);
            return Ok(studentsDto);
        }

        [HttpGet("{id}", Name = "GetStudentForAyditorya")]
        public async Task<IActionResult> GetStudentForAyditorya(Guid ayditoryaId, Guid id)
        {
            var ayditorya = await _repository.Ayditorya.GetAyditoryaAsync(ayditoryaId, trackChanges: false);
            if (ayditorya == null)
            {
                _logger.LogInfo($"Ayditorya with id: {ayditoryaId} doesn't exist in the database.");
                return NotFound();
            }

            var studentForAyditoryaDb = await _repository.Student.GetStudentAsync(ayditoryaId, id, trackChanges: false);
            if (studentForAyditoryaDb == null)
            {
                _logger.LogInfo($"Student with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            var studentForAyditorya = _mapper.Map<StudentDto>(studentForAyditoryaDb);
            return Ok(studentForAyditorya);
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateStudentForAyditorya(Guid ayditoryaId, [FromBody] StudentForCreationDto student)
        {
            var ayditorya = await _repository.Ayditorya.GetAyditoryaAsync(ayditoryaId, trackChanges: false);
            if (ayditorya == null)
            {
                _logger.LogInfo($"Ayditorya with id: {ayditoryaId} doesn't exist in the database.");
                return NotFound();
            }

            var studentEntity = _mapper.Map<Student>(student);
            _repository.Student.CreateStudentForAyditorya(ayditoryaId, studentEntity);
            await _repository.SaveAsync();

            var studentToReturn = _mapper.Map<StudentDto>(studentEntity);
            return CreatedAtRoute("GetStudentForAyditorya", new
            {
                ayditoryaId,
                id = studentToReturn.Id
            }, studentToReturn);
        }

        [HttpDelete("{id}")]
        [ServiceFilter(typeof(ValidateStudentForAyditoryaExistsAttribute))]
        public async Task<IActionResult> DeleteStudentForAyditorya(Guid ayditoryaId, Guid id)
        {
            var studentForAyditoria = HttpContext.Items["studentForAyditoria"] as Student;
            _repository.Student.DeleteStudent(studentForAyditoria);
            await _repository.SaveAsync();
            return NoContent();
        }

        [HttpPut("{id}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [ServiceFilter(typeof(ValidateStudentForAyditoryaExistsAttribute))]
        public async Task<IActionResult> UpdateStudentForAyditorya(Guid ayditoryaId, Guid id, [FromBody] StudentForUpdateDto student)
        {
            var studentEntity = HttpContext.Items["studentForAyditorya"] as Student;
            _mapper.Map(student, studentEntity);
            await _repository.SaveAsync();
            return NoContent();
        }

        [HttpPatch("{id}")]
        [ServiceFilter(typeof(ValidateStudentForAyditoryaExistsAttribute))]
        public async Task<IActionResult> PartiallyUpdateStudentForAyditorya(Guid AyditoryaId, Guid id, [FromBody] JsonPatchDocument<StudentForUpdateDto> patchDoc)
        {
            var Ayditorya = await _repository.Ayditorya.GetAyditoryaAsync(AyditoryaId, trackChanges: false);
            if (Ayditorya == null)
            {
                _logger.LogInfo($"Ayditorya with id: {AyditoryaId} doesn't exist in the database.");
                return NotFound();
            }
            var studentEntity = HttpContext.Items["student"] as Student;
            if (studentEntity == null)
            {
                _logger.LogInfo($"Student with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            var studentToPatch = _mapper.Map<StudentForUpdateDto>(studentEntity);
            patchDoc.ApplyTo(studentToPatch, ModelState);
            TryValidateModel(studentToPatch);
            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid model state for the patch document");
                return UnprocessableEntity(ModelState);
            }
            _mapper.Map(studentToPatch, studentEntity);
            await _repository.SaveAsync();
            return NoContent();
        }
    }
}

