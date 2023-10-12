using AutoMapper;
using Tahseen.Data.IRepositories;
using Tahseen.Domain.Entities.Books;
using Tahseen.Service.DTOs.Books.Author;
using Tahseen.Service.DTOs.Books.Genre;

namespace Tahseen.Service.Services.Books;

public class GenreService
{
    private readonly IMapper _mapper;
    private readonly IRepository<Genre> _repository;

    public GenreService(IMapper mapper, IRepository<Genre> repository)
    {
        this._mapper = mapper;
        this._repository = repository;
    }

    public async Task<GenreForResultDto> AddAsync(GenreForCreationDto dto)
    {
        var genre = _mapper.Map<Genre>(dto);
        var result= await _repository.CreateAsync(genre);
        return _mapper.Map<GenreForResultDto>(result);
    }

    public async Task<GenreForResultDto> ModifyAsync(long id, GenreForUpdateDto dto)
    {
        var genre = await _repository.SelectByIdAsync(id);
        if (genre is not null && !genre.IsDeleted)
        {
            var mappedGenre = _mapper.Map<Genre>(dto);
            var result = await _repository.UpdateAsync(mappedGenre);
            return _mapper.Map<GenreForResultDto>(result);
        }
        throw new Exception("Genre not found");
    }

    public async Task<bool> RemoveAsync(long id)
    {
        return await _repository.DeleteAsync(id);
    }

    public async ValueTask<GenreForResultDto> RetrieveByIdAsync(long id)
    {
        var genre = await _repository.SelectByIdAsync(id);
        if (genre is not null && !genre.IsDeleted)
            return _mapper.Map<GenreForResultDto>(genre);

        throw new Exception("Genre  not found");
    }
}