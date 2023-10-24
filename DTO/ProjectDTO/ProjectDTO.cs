

namespace DTO.ProjectDTO
{
    public class ProjectDTO
    {
        public Guid Id { get; set; }
        public string Names { get; set; } = null!;
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public Guid UserID { get; set; }
    }
}

