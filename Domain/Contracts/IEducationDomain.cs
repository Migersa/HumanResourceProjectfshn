using DTO.EducationDTO;

namespace Domain.Contracts
{
    public interface IEducationDomain { 
        EducationDTO GetEducationById(Guid id);
        EducationDTO Add(EducationDTO education);
        void Update(EducationDTO education);
        void Remove(Guid id);
    }
}
