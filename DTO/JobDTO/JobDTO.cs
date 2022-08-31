using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.JobDTO
{
    public class JobDTO
    {
        public Guid Id { get; set; }
        public string Company { get; set; } = null!;
        public string Position { get; set; } = null!;
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public string Descriptions { get; set; } = null!;
        public string ConfidencialityScale { get; set; } = null!;
    }
}
