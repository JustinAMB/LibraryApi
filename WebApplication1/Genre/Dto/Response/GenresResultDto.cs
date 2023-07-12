using Library.Shared.Dto.Response;

namespace Library.Genre.Dto.Response
{
    public class GenresResultDto:GenericResultDto
    {
        public List<GenreDto> Data { get; set; }
    }
}
