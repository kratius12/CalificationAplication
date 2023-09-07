namespace api.Datos
{
    public class Conexion
    {
        private string stringSql = string.Empty;

        public Conexion()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            stringSql = builder.GetSection("ConnectionStrings:conexion").Value;

        }

        public string GetStringSql()
        {
            return stringSql;
        }
    }
}
