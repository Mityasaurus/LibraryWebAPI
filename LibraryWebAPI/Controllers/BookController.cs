﻿using LibraryWebAPI.BusinessLogic.Builder;
using LibraryWebAPI.BusinessLogic.Contracts;
using LibraryWebAPI.BusinessLogic.Dtos;
using LibraryWebAPI.Infrastructure.Enums;
using LibraryWebAPI.Models.Books;
using Microsoft.AspNetCore.Mvc;

namespace LibraryWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly ILogger<BookController> _logger;
        private readonly IBookService _bookService;
        private readonly IBookBuilder _bookBuilder;

        public BookController(ILogger<BookController> logger, IBookService bookService, IBookBuilder bookBuilder)
        {
            _logger = logger;
            _bookService = bookService;
            _bookBuilder = bookBuilder;
        }

        [HttpGet("get", Name = "GetBook")]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetBook()
        {
            try
            {
                var result = await _bookService.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Failed to fetch books");
                return BadRequest();
            }
        }

        [HttpGet("getById/{id}", Name = "GetBookById")]
        public async Task<ActionResult<BookDto>> GetBookById([FromRoute] string id)
        {
            try
            {
                var result = await _bookService.Get(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Failed to fetch books");
                return BadRequest();
            }
        }

        [HttpGet("getByGenre/{genre}", Name = "GetBookByGenre")]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetBookByGenre(Genre genre)
        {
            try
            {
                var result = await _bookService.GetByGenre(genre);
                return Ok(result);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, $"Failed to fetch books");
                return BadRequest();
            }
        }

        [HttpPost("addBook", Name = "AddBook")]
        public async Task<ActionResult> AddBook([FromBody] CreateBookRequest request)
        {
            var entity = _bookBuilder.SetTitle(request.Title)
                                     .SetGenre(request.Genre)
                                     .SetPublishedDate(request.PublishedDate)
                                     .SetAuthorId(request.AuthorId)
                                     .Build();

            try
            {
                await _bookService.Add(entity);
                _logger.LogInformation($"Book {entity.Id} successfully created");
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Failed to create book with id={entity.Id}");
                return BadRequest();
            }
        }

        [HttpPut("updateBook", Name = "UpdateBook")]
        public async Task<ActionResult> UpdateBook([FromBody] UpdateBookRequest request)
        {
            var entity = _bookBuilder.SetId(request.Id)
                                     .SetTitle(request.Title)
                                     .SetGenre(request.Genre)
                                     .SetPublishedDate(request.PublishedDate)
                                     .SetAuthorId(request.AuthorId)
                                     .Build();

            try
            {
                await _bookService.Update(entity);
                _logger.LogInformation($"Book {entity.Id} successfully updated");
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Failed to update book with id={entity.Id}");
                return BadRequest();
            }
        }

        [HttpDelete("deleteBook", Name = "DeleteBook")]
        public async Task<ActionResult> DeleteBook(string id)
        {
            try
            {
                await _bookService.Delete(id);
                _logger.LogInformation($"Book {id} successfully deleted");
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Failed to delete book with id={id}");
                return BadRequest();
            }
        }
    }
}
