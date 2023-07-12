using FluentValidation;

namespace Library.Client.Dto.Request
{
    public class ClientRequestValidationDto:   AbstractValidator<ClientRequestDto>
    {
        public ClientRequestValidationDto() {

            RuleFor(x => x.Id).NotNull().GreaterThan(-1);
            RuleFor(x => x.Name).NotNull().Length(3,50);
            RuleFor(x => x.Email).NotNull().EmailAddress();
            RuleFor(x => x.Phone).NotNull().Length(8,12);

        }
    }
}
