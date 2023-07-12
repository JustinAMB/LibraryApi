using Library.Client.Dto.Request;
using Library.Client.Dto.Response;
using Library.Client.Services.Interfaces;
using Library.Config.Dto.Response;
using Library.Config;
using Library.Shared.Dto.Response;
using Library.Client.Dto.Db;


namespace Library.Client.Services
{
    public class ClientService : IClientService
    {
        

        public GenericResultDto addUpdateClient(ClientRequestDto request)
        {
            GenericResultDto result = new GenericResultDto();
            try
            {
                spClient_addUpdate sp = new spClient_addUpdate();
                sp.PrmId = request.Id;
                sp.PrmName = request.Name;
                sp.PrmEmail = request.Email;
                sp.PrmPhone= request.Phone;
                sp.PrmIsActive = true;
                DbResultDto resultSp = (new DbClass()).executeQuery(sp);

                if (resultSp != null && resultSp.Success)
                {
                    result.StatusError = 0;
                    result.Message = "Cliente guardado";
                }
                else
                {
                    result.StatusError = -3;
                    result.Message = "Ha ocurrido un error ";
                }

            }
            catch
            {

                result.StatusError = -2;
                result.Message = "Ha ocurrido un error en servidor";

            }
            return result;
        }

        public ClientsResultDto getClients(int pId)
        {
            ClientsResultDto result = new ClientsResultDto();

            try
            {
                spClient_get sp = new spClient_get();
                sp.PrmId = pId;
                sp.PrmPageNumber = 1;
                sp.PrmPageSize = 50;
                DbResultDto resultSp = (new DbClass()).executeQuery(sp);


                if (resultSp != null && resultSp.Success)
                {

                    result.Data = new List<ClientDto>();
                    while (resultSp.Data.Read())
                    {
                        ClientDto item = new ClientDto();

                        item.Id = int.Parse(resultSp.Data["Id"].ToString());
                        item.Name = resultSp.Data["Name"].ToString();
                        item.Email = resultSp.Data["Email"].ToString();
                        item.Phone = resultSp.Data["Phone"].ToString();
                        result.Data.Add(item);
                    }
                    result.StatusError = 0;
                }

            }
            catch (Exception e)
            {
                result.Message = e.Message;
                result.Data = null;
                result.StatusError = -2;
            }

            return result;
        }
    }
}
