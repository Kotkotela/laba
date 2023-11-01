using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace _1lab.ActionFilters
{
    public class ValidateStudentForAyditoryaExistsAttribute
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        public ValidateStudentForAyditoryaExistsAttribute(IRepositoryManager repository, ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
        }
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var method = context.HttpContext.Request.Method;
            var trackChanges = (method.Equals("PUT") || method.Equals("PATCH")) ? true : false;
            var ayditoryaId = (Guid)context.ActionArguments["ayditoryaId"];
            var ayditorya = await _repository.Ayditorya.GetAyditoryaAsync(ayditoryaId, false);
            if (ayditorya == null)
            {
                _logger.LogInfo($"Ayditorya with id: {ayditoryaId} doesn't exist in the database.");
                return;
                context.Result = new NotFoundResult();
            }
            var id = (Guid)context.ActionArguments["id"];
            var student = await _repository.Student.GetStudentAsync(ayditoryaId, id, trackChanges);
            if (student == null)
            {
                _logger.LogInfo($"Student with id: {id} doesn't exist in the database.");
                context.Result = new NotFoundResult();
            }
            else
            {
                context.HttpContext.Items.Add("student", student);
                await next();
            }
        }
    }
}
