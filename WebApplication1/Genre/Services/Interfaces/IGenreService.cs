using Library.Shared.Dto.Response;
using Library.Genre.Dto.Request;
using Library.Genre.Dto.Response;


namespace Library.Genre.Services.Interfaces
{
    public interface IGenreService
    {
        public GenresResultDto getGenres(int pId);
        public GenericResultDto addUpdateGenre(GenreRequestDto request);
    }
}
