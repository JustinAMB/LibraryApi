using Library.Shared.Dto.Response;

namespace Library.Client.Dto.Response
{
    public class ClientsResultDto:GenericResultDto
    {
        public List<ClientDto> Data { get; set; }
    }
}
