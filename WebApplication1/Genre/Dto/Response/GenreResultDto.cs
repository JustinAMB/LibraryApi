using Library.Genre.Dto.Response;
using Library.Shared.Dto.Response;

namespace Library.Genre.Dto.Response
{
    public class GenreResultDto:GenericResultDto
    {
        public GenreDto Data { get; set; }
    }
}
