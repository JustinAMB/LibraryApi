using Library.Shared.Dto.Response;
using Library.Config;
using Library.Config.Dto.Response;
using Library.Genre.Dto.Db;
using Library.Genre.Dto.Request;
using Library.Genre.Dto.Response;
using Library.Genre.Services.Interfaces;


namespace Library.Genre.Services
{
    public class GenreService : IGenreService
    {



        public GenreService() { }
        public GenresResultDto getGenres(int pId)
        {
            GenresResultDto result = new GenresResultDto();
            
            try
            {
                spGenre_get sp = new spGenre_get();
                sp.PrmId = pId;
                sp.PrmPageNumber = 1;
                sp.PrmPageSize = 50;
                DbResultDto resultSp = (new DbClass()).executeQuery(sp);


                if (resultSp != null  && resultSp.Success) {

                    result.Data = new List<GenreDto>();
                    while (resultSp.Data.Read()) {
                        GenreDto item = new GenreDto();

                        item.Id= int.Parse(resultSp.Data["Id"].ToString());
                        item.Name= resultSp.Data["Name"].ToString();
                        result.Data.Add(item);
                    }
                    result.StatusError = 0;
                }

            }
            catch(Exception e) {
                result.Message = e.Message;
                result.Data = null;
                result.StatusError = -2;
            }

            return result;
        }
        public GenericResultDto addUpdateGenre(GenreRequestDto request)
        {
            GenericResultDto result = new GenericResultDto();
            try {
                spGenre_addUpdate sp = new spGenre_addUpdate();
                sp.PrmId = request.Id;
                sp.PrmName = request.Name;
                sp.PrmIsActive = true;
                DbResultDto resultSp = (new DbClass()).executeQuery(sp);

                if (resultSp != null && resultSp.Success)
                {
                    result.StatusError = 0;
                    result.Message = "Genero guardado";
                }
                else {
                    result.StatusError = -3;
                    result.Message = "Ha ocurrido un error ";
                }

            }
            catch {
             
                result.StatusError = -2;
                result.Message = "Ha ocurrido un error en servidor";

            }
            return result;

        }
    }
}
