using DTO.EmployeeDTO;


namespace Domain.Contracts
{
    public interface IEmployeeDomain
    {
        IList<EmployeeDTO> GetAllUsers();
        EmployeeDTO GetUserById(Guid id);
        EmployeeDTO Create(EmployeeDTO employee);
        void Update(EmployeeDTO1 employee);
    }
}
