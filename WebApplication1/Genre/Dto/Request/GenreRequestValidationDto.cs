using FluentValidation;

namespace Library.Genre.Dto.Request
{
    public class GenreRequestValidationDto : AbstractValidator<GenreRequestDto>
    {
        public GenreRequestValidationDto()
        {
            RuleFor(x => x.Id).NotNull().GreaterThan(-1);
            RuleFor(x => x.Name).NotNull().Length(3, 20);
        }
    }
}
