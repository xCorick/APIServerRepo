using Api_Capacitacion.Model;
using API_Capacitacion.Data.Interfaces;
using API_Capacitacion.DTO.User;
using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Capacitacion.Data.Servicios
{
    public class UserService : IUserServices
    {
        private PostgresSQLConfiguration _postgresSQLConfiguration;
        public UserService(PostgresSQLConfiguration postgresSQLConfiguration) => _postgresSQLConfiguration = postgresSQLConfiguration;
        public NpgsqlConnection CreateConnection() => new NpgsqlConnection(_postgresSQLConfiguration.connection);

        #region Create
        public Task<UserModel?> Create(CreateUserDTO createUserDTO)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region FindAll
        public async Task<IEnumerable<UserModel>> FindAll()
        {
            string sqlQuery = "select * from view_usuario";
            using NpgsqlConnection connection = CreateConnection();

            Dictionary<int, List<TareaModel>> userTasks = [];

            try
            {
                await connection.OpenAsync();
                IEnumerable<UserModel> users = await connection.QueryAsync<UserModel, TareaModel, UserModel>(
                        sql: sqlQuery,
                        map: (user, task) =>
                        {
                            List<TareaModel> currentTasks = [];
                            userTasks.TryGetValue(user.idUsuario, out currentTasks);
                            currentTasks ??= [];
                            if (currentTasks.Count == 0 && task != null)
                            {
                                currentTasks = [task];
                            }
                            else if(currentTasks.Count > 0 && task != null)
                            {
                                currentTasks.Add(task);
                            }
                            userTasks[user.idUsuario] = currentTasks;
                            return user;
                        },
                        splitOn: "idTarea"
                    );
                await connection.CloseAsync();
                IEnumerable<UserModel> newUserList = users.Distinct().ToList().Select(user =>
                {
                    user.Tareas = userTasks[user.idUsuario];
                    return user;
                });
                return newUserList;
            }
            catch (Exception ex)
            {
                return [];
            }
        }
        #endregion
        #region Remove
        public Task<UserModel?> Remove(int userId)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Update
        public Task<UserModel?> Update(UpdateUserDTO updateUserDTO)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
