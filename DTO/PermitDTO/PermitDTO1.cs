

namespace DTO.PermitDTO
{
    public class PermitDTO1
    {
        public Guid Id { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public string Title { get; set; } = null!;
        public string PermitType { get; set; } = null!;
        public Guid? EmployeeId { get; set; }
    }
}
