using Library.Client.Dto.Request;
using Library.Client.Dto.Response;
using Library.Client.Services.Interfaces;
using Library.Genre.Dto.Request;
using Library.Genre.Dto.Response;
using Library.Genre.Services.Interfaces;
using Library.Shared.Dto.Response;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Library.Client.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;
        public ClientController(IClientService _clientService)
        {
            this._clientService = _clientService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            ClientsResultDto result = this._clientService.getClients(0);
            return Ok(result);
        }


        [HttpPost]
        public IActionResult save([FromBody] ClientRequestDto body)
        {
            var validator = new ClientRequestValidationDto();
            var validateResult = validator.Validate(body);
            if (!validateResult.IsValid)
            {
                return BadRequest(validateResult.Errors);
            }

            GenericResultDto result = this._clientService.addUpdateClient(body);
            return Ok(result);

        }
    }
}
