using Api_Capacitacion.Model;
using API_Capacitacion.Data.Interfaces;
using API_Capacitacion.DTO.Tarea;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace API_Capacitacion.Data.Servicios
{
    public class TareaService : ITareaServices
    {
        private PostgresSQLConfiguration _connection;

        public TareaService(PostgresSQLConfiguration connection) => _connection = connection;
        private NpgsqlConnection CreateConnection() => new(_connection.connection);

        #region Create

        public async Task<TareaModel> Create(CreateTareaDTO createTareaDTO)
        {
            using NpgsqlConnection database = CreateConnection();
            string sqlQuery = "select * from fun_task_create(" +
                "p_tarea:= @task," +
                "p_descripcion:= @descripcion," +
                "p_idUsuario:= @userId," +
                ");";

            try
            {
                await database.OpenAsync();

                var result = await database.QueryAsync<TareaModel, UserModel, TareaModel>(
                    sqlQuery,
                    param: new
                    {
                        task = createTareaDTO.Tarea,
                        descripcion = createTareaDTO.Descripcion,
                        userId = createTareaDTO.idUsuario
                    },
                map: (tarea, user) =>
                {
                    tarea.User.idUsuario = user.idUsuario;
                    return tarea;
                },
                splitOn: "usuarioId"
                );

                await database.CloseAsync();

                return result.FirstOrDefault();
            }
            catch
            {
                return null;
            }
        } 

        #endregion
    }
}
