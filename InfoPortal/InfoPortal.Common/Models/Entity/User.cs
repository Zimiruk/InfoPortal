namespace InfoPortal.Common.Models
{
    public class User : ITable
    {
        public int Id { get; set; }

        public string Login { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Role{ get; set; }
    }
}
