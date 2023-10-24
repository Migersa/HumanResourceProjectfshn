

namespace DTO.ArchiveDTO
{
    public  class ArchiveDTO
    {
         //public Guid Id { get; set; }
        public string CardId { get; set; } = null!;
        public string Diploma { get; set; } = null!;
        public string RaportAftesie { get; set; } = null!;
        public Guid? EmployeeId { get; set; }
    }
}
