using Microsoft.Data.SqlClient;
namespace imagenDental.Services
{
    public class DatabaseService
    {
        private readonly string _connectionString;

        public DatabaseService(string connectionString)
        {
            _connectionString = connectionString;
        }

        /// <summary>
        /// Verifica si el usuario y contraseña son válidos en la tabla tbUsuariosIndicadores.
        /// </summary>
        /// <returns>True si son válidos, false si no.</returns>
        public async Task<bool> ValidateUserAsync(string usuario, string clave)
        {
            // IMPORTANTE: En producción debes manejar contraseñas encriptadas (hash).
            // Esto es solo un ejemplo con texto plano.
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var query = @"
                    SELECT COUNT(1) 
                    FROM tbUsuariosIndicadores 
                    WHERE strUsuario = @usuario 
                      AND strClave = @clave
                ";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@usuario", usuario);
                    command.Parameters.AddWithValue("@clave", clave);

                    var count = (int)await command.ExecuteScalarAsync();
                    return count > 0;  // Si existe al menos 1 registro, es válido.
                }
            }
        }
    }
}
