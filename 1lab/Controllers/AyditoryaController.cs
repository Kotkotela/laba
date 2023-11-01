using _1lab.ActionFilters;
using _1lab.ModelBinder;
using AutoMapper;
using Entities.Models;
using Entities1._0.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;

namespace _1lab.Controllers
{
    [Route("api/ayditoryas")]
    [ApiController]
    public class AyditoryaController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public AyditoryaController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAyditoryas()
        {
            var ayditoryas = await _repository.Ayditorya.GetAllAyditoryasAsync(trackChanges: false);
            var ayditoryasDto = _mapper.Map<IEnumerable<AyditoryaDto>>(ayditoryas);
            return Ok(ayditoryasDto);
        }

        [HttpGet("{id}", Name = "AyditoryaById")]
        public async Task<IActionResult> GetAyditorya(Guid id)
        {
            var ayditorya = await _repository.Ayditorya.GetAyditoryaAsync(id, trackChanges: false);
            if (ayditorya == null)
            {
                _logger.LogInfo($"Ayditorya with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            else
            {
                var ayditoryaDto = _mapper.Map<AyditoryaDto>(ayditorya);
                return Ok(ayditoryaDto);
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateAyditorya([FromBody] AyditoryaForCreationDto ayditorya)
        {
            var ayditoryaEntity = _mapper.Map<Ayditorya>(ayditorya);
            _repository.Ayditorya.CreateAyditorya(ayditoryaEntity);
            await _repository.SaveAsync();
            var ayditoryaToReturn = _mapper.Map<AyditoryaDto>(ayditoryaEntity);
            return CreatedAtRoute("AyditoryaById", new { id = ayditoryaToReturn.Id }, ayditoryaToReturn);
        }

        [HttpGet("collection/({ids})", Name = "AyditoryaCollection")]
        public async Task<IActionResult> GetAyditoryaCollection([ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<Guid> ids)
        {
            if (ids == null)
            {
                _logger.LogError("Parameter ids is null");
                return BadRequest("Parameter ids is null");
            }

            var ayditoryaEntities = await _repository.Ayditorya.GetByIdsAsync(ids, trackChanges: false);
            if (ids.Count() != ayditoryaEntities.Count())
            {
                _logger.LogError("Some ids are not valid in a collection");
                return NotFound();
            }

            var ayditoryasToReturn = _mapper.Map<IEnumerable<AyditoryaDto>>(ayditoryaEntities);
            return Ok(ayditoryasToReturn);
        }

        [HttpPost("collection")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateAyditoryaCollection([FromBody] IEnumerable<AyditoryaForCreationDto> ayditoryaCollection)
        {
            var ayditoryaEntities = _mapper.Map<IEnumerable<Ayditorya>>(ayditoryaCollection);
            foreach (var ayditorya in ayditoryaEntities)
            {
                _repository.Ayditorya.CreateAyditorya(ayditorya);
            }
            await _repository.SaveAsync();
            var ayditoryaCollectionToReturn = _mapper.Map<IEnumerable<AyditoryaDto>>(ayditoryaEntities);
            var ids = string.Join(",", ayditoryaCollectionToReturn.Select(c => c.Id));
            return CreatedAtRoute("AyditoryaCollection", new { ids }, ayditoryaCollectionToReturn);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAyditorya(Guid id)
        {
            var ayditorya = await _repository.Ayditorya.GetAyditoryaAsync(id, trackChanges: false);
            if (ayditorya == null)
            {
                _logger.LogInfo($"Ayditorya with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            _repository.Ayditorya.DeleteAyditorya(ayditorya);
            await _repository.SaveAsync();
            return NoContent();
        }

        [HttpPut("{id}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [ServiceFilter(typeof(ValidateAyditoryaExistsAttribute))]
        public async Task<IActionResult> UpdateAyditorya(Guid id, [FromBody] AyditoryaForUpdateDto ayditorya)
        {
            var ayditoryaEntity = HttpContext.Items["ayditorya"] as Ayditorya;
            _mapper.Map(ayditorya, ayditoryaEntity);
            await _repository.SaveAsync();
            return NoContent();
        }
    }
}
