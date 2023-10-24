
namespace DTO
{
    public  class EmployeeDTOpass
    {
        public Guid Id { get; set; }
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
        public bool? EmailConfirm { get; set; }
        public byte[] PasswordHash { get; set; } = null!;
        public string Descriptions { get; set; } = null!;
        public byte[] ProfilePhoto { get; set; } = null!;
        public int PhoneNumber { get; set; }
        public string Contact2 { get; set; } = null!;
        public string Adress { get; set; } = null!;
    }
}
