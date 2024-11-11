using LibraryWebAPI.Application.Dtos;
using LibraryWebAPI.Application.Facade;
using LibraryWebAPI.Models.Authors;
using Microsoft.AspNetCore.Mvc;

namespace LibraryWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorController : ControllerBase
    {
        private readonly ILogger<AuthorController> _logger;
        private readonly ILibraryFacade _libraryFacade;

        public AuthorController(ILogger<AuthorController> logger, ILibraryFacade libraryFacade)
        {
            _logger = logger;
            _libraryFacade = libraryFacade;
        }

        [HttpGet("get", Name = "GetAuthor")]
        public async Task<ActionResult<IEnumerable<AuthorDto>>> GetAuthor()
        {
            try
            {
                var result = await _libraryFacade.GetAllAuthors();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Failed to fetch authors");
                return BadRequest();
            }
        }

        [HttpGet("getById/{id}", Name = "GetAuthorById")]
        public async Task<ActionResult<AuthorDto>> GetAuthorById([FromRoute] string id)
        {
            try
            {
                var result = await _libraryFacade.GetAuthor(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Failed to fetch author with id={id}");
                return BadRequest();
            }
        }

        [HttpPost("addAuthor", Name = "AddAuthor")]
        public async Task<ActionResult> AddAuthor([FromBody] CreateAuthorRequest request)
        {
            var entity = new AuthorDto(
                id: Guid.NewGuid().ToString(),
                name: request.Name,
                lastname: request.Lastname);

            try
            {
                await _libraryFacade.AddAuthor(entity);
                _logger.LogInformation($"Author {entity.Id} successfully created");
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Failed to create author with id={entity.Id}");
                return BadRequest();
            }
        }

        [HttpPut("updateAuthor", Name = "UpdateAuthor")]
        public async Task<ActionResult> UpdateAuthor([FromBody] UpdateAuthorRequest request)
        {
            var entity = new AuthorDto(
                id: request.Id,
                name: request.Name,
                lastname: request.Lastname);

            try
            {
                await _libraryFacade.UpdateAuthor(entity);
                _logger.LogInformation($"Author {entity.Id} successfully updated");
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Failed to update author with id={entity.Id}");
                return BadRequest();
            }
        }

        [HttpDelete("deleteAuthor/{id}", Name = "DeleteAuthor")]
        public async Task<ActionResult> DeleteAuthor([FromRoute] string id)
        {
            try
            {
                await _libraryFacade.DeleteAuthor(id);
                _logger.LogInformation($"Author {id} successfully deleted");
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Failed to delete author with id={id}");
                return BadRequest();
            }
        }
    }
}
