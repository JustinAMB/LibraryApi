using Library.Client.Dto.Request;
using Library.Client.Dto.Response;
using Library.Shared.Dto.Response;

namespace Library.Client.Services.Interfaces
{
    public interface IClientService
    {
        public GenericResultDto addUpdateClient(ClientRequestDto request);
        public ClientsResultDto getClients(int pId);
    }
}
