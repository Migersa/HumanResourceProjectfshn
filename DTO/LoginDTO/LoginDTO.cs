
namespace DTO.LoginDTO
{
    public class LoginDTO { 
    
        public Guid Id { get; set; }
        public string Username { get; set; } = null!;
        public string RefreshToken { get; set; } = string.Empty;
        public DateTime TokenCreated { get; set; }
        public DateTime TokenExpires { get; set; }
        public List<UserRoleDTO> UserRoles { get; set; }
    
    }

    public class UserRoleDTO
    {
        public Guid RoleId { get; set; }
        public Guid UserId { get; set; }
        public RoleDTO Role { get; set; }
    }

    public class RoleDTO
    {
        public Guid RoleId { get; set; }
        public string Name { get; set; } = null!;
    }

}