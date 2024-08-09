using System.Data.SqlClient;
using Dapper;

public class BD
{
    private static string _connectionString = @"Server=localhost;
    DataBase=JJOO;Trusted_Connection=True;";
    public static void AgregarDeportista(Deportista dep)
    {
        string SQL = "INSERT INTO Deportistas(Apellido, Nombre, FechaNacimiento, Foto, IdPais, IdDeporte) VALUES (@pApellido, @pNombre, @pFechaNacimiento, @pFoto, @pIdPais, @pIdDeporte)";
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            db.Execute(SQL, new { pApellido = dep.Apellido, pNombre = dep.Nombre, pFechaNacimiento = dep.FechaNacimiento, pFoto = dep.Foto, pIdPais = dep.IdPais, pIdDeporte = dep.IdDeporte });
        }
    }

    public static int EliminarDeportista(int IdDeportista)
    {
        int RegistrosEliminados = 0;
        string SQL = "DELETE FROM Deportistas WHERE IdDeportista = @pIdDeportista";
        using(SqlConnection db = new SqlConnection(_connectionString)) 
        {
            RegistrosEliminados = db.Execute(SQL, new {pIdDeportista = IdDeportista }); 
        } 
        return RegistrosEliminados; 

    }

    public static Deporte Deporte (int IdDeporte)
    {
        Deporte deporteConsultado = null;
            using(SqlConnection db = new SqlConnection(_connectionString))
            { 
                string SQL = "SELECT * FROM Deportes WHERE IdDeporte = @pIdDeporte";
                deporteConsultado = db.QueryFirstOrDefault<Deporte>(SQL, new {pIdDeporte = IdDeporte});
            }

        return deporteConsultado;

    } 
      public static Pais Pais (int IdPais)
    {
          Pais paisConsultado = null; 
            using(SqlConnection db = new SqlConnection(_connectionString))
            { 
                string SQL = "SELECT * FROM Paises WHERE IdPais = @pIdPais";
                paisConsultado = db.QueryFirstOrDefault<Pais>(SQL, new {pIdPais = IdPais});
            }

        return paisConsultado;

    }

      public static Deportista Deportista (int IdDeportista)
    {
          Deportista deportistaConsultado = null; 
            using(SqlConnection db = new SqlConnection(_connectionString))
            { 
                string SQL = "SELECT * FROM Deportistas WHERE IdDeportista = @pIdDeportista";
                deportistaConsultado = db.QueryFirstOrDefault<Deportista>(SQL, new {pIdDeportista = IdDeportista});
            }

        return deportistaConsultado;

    } 

    public static List ListarPaises ()
    {
        using(SqlConnection db = new SqlConnection(_connectionString)) 
        {
            string SQL = "SELECT * FROM Paises"; 
            _ListadoPaises = db.Query<Pais>(SQL).ToList(); 
        } 
        return _ListadoPaises; 
    }

    public static List ListarDeportistasXdep (int IdDeporte)
    {
        using(SqlConnection db = new SqlConnection(_connectionString)) 
        {
            string SQL = "SELECT * FROM Deportistas WHERE IdDeporte = @pIdDeporte"; 
            _ListadoDeportistas = db.Query<Deportistas>(SQL, new {pIdDeporte = IdDeporte}).ToList(); 
        } 
        return _ListadoDeportistas; 
    }

     public static List ListarDeportistasXpais (int IdPais)
    {
        using(SqlConnection db = new SqlConnection(_connectionString)) 
        {
            string SQL = "SELECT * FROM Deportistas WHERE IdPais = @pIdPais"; 
            _ListadoDeportistas = db.Query<Deportistas>(SQL, new {pIdPais = IdPais}).ToList(); 
        } 
        return _ListadoDeportistas; 
    }

    public static List ListarDeportes()
    {
        using(SqlConnection db = new SqlConnection(_connectionString)) 
        {
            string SQL = "SELECT * FROM Deportes"; 
            _ListadoDeportes = db.Query<Pais>(SQL).ToList(); 
        } 
        return _ListadoDeportes; 
    }

}


