namespace InfoPortal.Common.Models
{
    public class File : ITable
    {
        public int Id { get; set; }

        public byte[] Content { get; set; }

        public int ArticleId { get; set; }
    }
}
