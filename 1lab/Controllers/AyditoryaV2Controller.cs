using Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace _1lab.Controllers
{
    [Route("api/ayditorya")]
    [ApiController]
    public class AyditoryasV2Controller : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        public AyditoryasV2Controller(IRepositoryManager repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAyditoryas()
        {
            var ayditoryas = await _repository.Ayditorya.GetAllAyditoryasAsync(trackChanges: false);
            return Ok(ayditoryas);
        }
    }
}
