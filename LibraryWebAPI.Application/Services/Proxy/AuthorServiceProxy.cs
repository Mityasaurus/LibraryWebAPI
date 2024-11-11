using LibraryWebAPI.Application.Contracts;
using LibraryWebAPI.Application.Dtos;

namespace LibraryWebAPI.Application.Services.Proxy
{
    public class AuthorServiceProxy(AuthorService authorService) : IAuthorService
    {
        private readonly AuthorService _authorService = authorService;
        private readonly Dictionary<string, AuthorDto> _cache = [];
        private IReadOnlyList<AuthorDto>? _allAuthorsCache = null;

        public async Task<IReadOnlyList<AuthorDto>> GetAll()
        {
            if (_allAuthorsCache != null)
            {
                return _allAuthorsCache;
            }

            var authors = await _authorService.GetAll();
            _allAuthorsCache = authors;
            return authors;
        }

        public async Task<AuthorDto> Get(string id)
        {
            if (_cache.TryGetValue(id, out AuthorDto? value))
            {
                return value;
            }

            var author = await _authorService.Get(id);
            if (author != AuthorDto.Default)
            {
                _cache[id] = author;
            }
            return author;
        }

        public async Task Add(AuthorDto authorDto)
        {
            await _authorService.Add(authorDto);

            InvalidateCache(invalidateById: false);
        }

        public async Task Update(AuthorDto authorDto)
        {
            await _authorService.Update(authorDto);

            InvalidateCache();
        }

        public async Task Delete(string id)
        {
            await _authorService.Delete(id);

            InvalidateCache();
        }

        private void InvalidateCache(bool invalidateList = true, bool invalidateById = true)
        {
            if(invalidateList)
                _allAuthorsCache = null;
            
            if(invalidateById)
                _cache.Clear();
        }
    }

}
