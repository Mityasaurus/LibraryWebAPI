using LibraryWebAPI.BusinessLogic.Dtos;
using LibraryWebAPI.BusinessLogic.Facade;
using Microsoft.AspNetCore.Mvc;

namespace LibraryWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StatisticsController : ControllerBase
    {
        private readonly ILogger<AuthorController> _logger;
        private readonly ILibraryFacade _libraryFacade;

        public StatisticsController(ILogger<AuthorController> logger, ILibraryFacade libraryFacade)
        {
            _logger = logger;
            _libraryFacade = libraryFacade;
        }

        [HttpGet("get", Name = "GetStatistics")]
        public async Task<ActionResult<StatisticsDto>> GetStatistics()
        {
            try
            {
                var result = await _libraryFacade.GetStatistics();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Failed to fetch statistics");
                return BadRequest();
            }
        }
    }
}
