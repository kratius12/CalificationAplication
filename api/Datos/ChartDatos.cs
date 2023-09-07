using api.Models;
using System.Data;
using System.Data.SqlClient;

namespace api.Datos
{
    public class ChartDatos
    {
        public List<Chart> Listar()
        {
            var lista = new List<Chart>();

            var cnx = new Conexion();

            using (var conexion = new SqlConnection(cnx.GetStringSql()))
            {
                conexion.Open();

                SqlCommand cmd = new SqlCommand("chart", conexion);
                cmd.CommandType = CommandType.StoredProcedure;


                return lista;


            }
        }
    }
}
