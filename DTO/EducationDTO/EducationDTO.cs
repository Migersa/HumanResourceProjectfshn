using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.EducationDTO
{
    public class EducationDTO
    {
        public Guid Id { get; set; }
        public string University { get; set; } = null!;
        public DateTime StartYear { get; set; }
        public DateTime? EndYear { get; set; }
        public bool IsFollowing { get; set; }
        public double Average { get; set; }
        public string AcademicProfile { get; set; } = null!;
        public string? MasterType { get; set; }
    }
}
