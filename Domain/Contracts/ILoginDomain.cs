using DTO.LoginDTO;
using DTO.UserDTO;

namespace Domain.Contracts
{
    public interface ILoginDomain
    {
       LoginDTO AuthUsers(LoginCredentialsDTO dto);

       string GenerateAccessAndRefreshToken();
    }
}
