namespace Library.Shared.Dto.Response
{
    public class GenericResultDto
    {
        public string Message { get; set; }
        public List<string> Messages { get; set; }
        public int StatusError { get; set; }

        public GenericResultDto() {
            this.StatusError = -1;
            this.Message = string.Empty;
            this.Messages= new List<string>();

        }
    } 
}
