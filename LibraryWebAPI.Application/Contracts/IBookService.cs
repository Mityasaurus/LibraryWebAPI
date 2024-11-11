﻿using LibraryWebAPI.Application.Dtos;
using LibraryWebAPI.Domain.Enums;

namespace LibraryWebAPI.Application.Contracts
{
    public interface IBookService
    {
        Task<IReadOnlyList<BookDto>> GetAll();
        Task<BookDto> Get(string id);
        Task Add(BookDto bookDto);
        Task Update(BookDto bookDto);
        Task Delete(string id);
        Task<IReadOnlyList<BookDto>> GetByTitle(string title);
        Task<IReadOnlyList<BookDto>> GetByGenre(Genre genre);
    }
}