namespace Library.Client.Dto.Db
{
    public class spClient_addUpdate
    {
        public int PrmId { get; set; }
        public string PrmName { get; set; }
        public string PrmEmail { get; set; }
        public string PrmPhone { get; set; }

        public bool PrmIsActive { get; set; }
    }
}
