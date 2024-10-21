using Api_Capacitacion.Model;
using API_Capacitacion.DTO.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Capacitacion.Data.Interfaces
{
    public interface IUserServices
    {
        public Task<UserModel?>Create(CreateUserDTO createUserDTO);
        public Task<IEnumerable<UserModel>>FindAll();
        public Task<UserModel?>Update(UpdateUserDTO updateUserDTO);
        public Task<UserModel?>Remove(int userId);
    }
}
