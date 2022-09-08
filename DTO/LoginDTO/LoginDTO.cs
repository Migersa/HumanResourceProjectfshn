using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.LoginDTO
{
    public class LoginDTO
    {

  

        public Guid Id { get; set; }
        public List<string> Role { get; set; }
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
        public bool? EmailConfirm { get; set; }

        public string RefreshToken { get; set; } = string.Empty;
        public DateTime TokenCreated { get; set; }
        public DateTime TokenExpires { get; set; }

    }
    public class LoginDataDTO
    {
        public Guid Id { get; set; }
        public string Username { get; set; } = null!;
        public List<UserRoleDTO> Role { get; set; }


    }
    public class UserRoleDTO
    {
        public Guid RoleId { get; set; }
        public Guid UserId { get; set; }
        public RoleDTO role { get; set; }

    }
    public class RoleDTO
    {

        public Guid RoleId { get; set; }
        public string Name { get; set; } = null!;
    }



}