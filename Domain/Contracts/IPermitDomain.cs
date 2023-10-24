using DTO.PermitDTO;
using Entities.Model;


namespace Domain.Contracts
{
    public interface IPermitDomain
    {
        Permit CreatePermit(PermitDTO permit);
        IList<PermitDTO1> GetAllPermit();
        Permit GetById(Guid id);
        void Remove(Guid id);
        void Update(PermitDTO1 permit);
    }
}
