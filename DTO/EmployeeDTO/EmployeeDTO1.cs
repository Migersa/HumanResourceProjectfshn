
namespace DTO.EmployeeDTO
{
    public class EmployeeDTO1
    {
        public Guid Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Descriptions { get; set; } = string.Empty;
        public byte[] ProfilePhoto { get; set; }
        public int PhoneNumber { get; set; }
        public string Contact2 { get; set; } = string.Empty;
        public string Adress { get; set; } = string.Empty;
        public DateTime ComeDate { get; set; }
    }
}
