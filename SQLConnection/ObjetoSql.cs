using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace SQLConnection
{
    public class ObjetoSql
    {
        //Tabla a la que voy a realizar las consultas
        string nameTabla = "Tabla1";


        public int objetoID { get; set; }      //Propiedades del ObjetoSql
        public string Nombre { get; set; }     //Propiedades del ObjetoSql
        public string Apellido { get; set; }   //Propiedades del ObjetoSql
        public string Email { get; set; }      //Propiedades del ObjetoSql
        public DateTime Fecha { get; set; }    //Propiedades del ObjetoSql
        public string Descripcion { get; set; }//Propiedades del ObjetoSql
        


        //Coneccion con SQL con ADO.NET
        //Este metodo devuelve la Connection String
        public string ConexionSQL()
        {
            SqlConnectionStringBuilder conexion = new SqlConnectionStringBuilder();
            conexion.DataSource = "DESKTOP-5ILIF80";    // SERVER
            conexion.InitialCatalog = "prueba_SQL";      //DATABASE
            conexion.IntegratedSecurity = true;

            return conexion.ConnectionString;   //Retorno la conexion.ConnectionString
        }
        //------------------------------------------------------------------------
        //Este metodo ingresa datos en la BD y recibe como parametros
        //nombre-apellido-email-fecha-descripcion
        public void Insertar(ObjetoSql miObjRecibido)
        {           //Modificar
            string conexion = ConexionSQL();
            string query = "INSERT INTO " + nameTabla + "(Nombre,Apellido,Email,Fecha,Descripcion) VALUES ( @Nombre , @Apellido , @Email , @Fecha , @Descripcion)";


            //Iniciamos la consulta
            using (SqlConnection conn = new SqlConnection(conexion))
            {
                //1 Creamos el cursor
                SqlCommand cursor = new SqlCommand(query, conn);
                cursor.Parameters.AddWithValue("@Nombre",miObjRecibido.Nombre);
                cursor.Parameters.AddWithValue("@Apellido", miObjRecibido.Apellido);
                cursor.Parameters.AddWithValue("@Email", miObjRecibido.Email);
                cursor.Parameters.AddWithValue("@Fecha", miObjRecibido.Fecha);
                cursor.Parameters.AddWithValue("@Descripcion", miObjRecibido.Descripcion);

                //2 Abrimos la conexion
                conn.Open();

                //cursor.ExecuteScalar(); Ejecuta y Devuelve la fila en INT 
                // y necesitariamos Return de la variable donde almacenamos el ExecuteScalar()
                cursor.ExecuteNonQuery();
                conn.Close();

            }

        }
        //-------------------------------------------------------------------------

        

        public List<ObjetoSql> GetInformacionTotal()
        {
            string conexion = ConexionSQL();
            string query = "SELECT * FROM " + nameTabla;
            //Creamos un la lista de objetos donde almacenaremos todos los objetos tipo OBjetosSQl a devolver
            List<ObjetoSql> totalData = new List<ObjetoSql>();

            SqlConnection conn = new SqlConnection(conexion);

            SqlCommand cursor = new SqlCommand(query, conn);

            conn.Open();

            SqlDataReader dr = cursor.ExecuteReader();
            if(dr != null)
            {
                while (dr.Read())
                {
                    ObjetoSql data = new ObjetoSql(); //Se crea un objeto por cada uno que encuentra y le asignamos los valores

                    data.objetoID = Convert.ToInt32( dr["ID"]);               
                    data.Nombre = dr["Nombre"].ToString();
                    data.Apellido = dr["Apellido"].ToString();
                    data.Email = dr["Email"].ToString();
                    data.Fecha = Convert.ToDateTime(dr["Fecha"]);
                    data.Descripcion = dr["Descripcion"].ToString();

                    //Por cada DATA COMPLETA que encuentra la agrego a la lista de DATA
                    totalData.Add(data);
                }
            }

            conn.Close();
            return totalData;





        }//Este metodo devuelve un objeto de toda la base de datos

        public ObjetoSql OnlineData(int idR)
        {

            //Lista/objeto a retornar
           

            string conexion = ConexionSQL();
            string query = "SELECT Nombre, Apellido, Email, Descripcion, Fecha  FROM "+nameTabla +" WHERE ID ="+ idR;

            SqlConnection conn = new SqlConnection(conexion);

            conn.Open();
            SqlCommand cursor = new SqlCommand(query, conn);

                    //Creamos la lectura del archivo/s con DATAREADER
                   
                    SqlDataReader dr = cursor.ExecuteReader();

                   ObjetoSql miObjetoR = new ObjetoSql();   
                    if (dr!=null)
                    {
                        while (dr.Read())
                        {
                           
                        
                            miObjetoR.Nombre =  dr["Nombre"].ToString();
                            miObjetoR.Apellido = dr["Apellido"].ToString();
                            miObjetoR.Email = dr["Email"].ToString();
                            miObjetoR.Fecha =Convert.ToDateTime( dr["Fecha"].ToString());
                            miObjetoR.Descripcion = dr["Descripcion"].ToString();
                           // miObjetoR.objetoID = Convert.ToInt32(dr["ID"]);

                           
                         
                           
                        }
                    }
           
                    return miObjetoR;
                  
                
            
           

        }

       /* public List<ObjetoSql> PrimerosResultados()
        {
            string conexion = ConexionSQL();
            string query = "SELECT TOP 10 * FROM " + nameTabla;
            //Creamos un la lista de objetos donde almacenaremos todos los objetos tipo OBjetosSQl a devolver
            List<ObjetoSql> totalData = new List<ObjetoSql>();

            SqlConnection conn = new SqlConnection(conexion);

            SqlCommand cursor = new SqlCommand(query, conn);

            conn.Open();

            SqlDataReader dr = cursor.ExecuteReader();
            if (dr != null)
            {
                while (dr.Read())
                {
                    ObjetoSql data = new ObjetoSql(); //Se crea un objeto por cada uno que encuentra y le asignamos los valores

                    data.objetoID = Convert.ToInt32(dr["ID"]);
                    data.Nombre = dr["Nombre"].ToString();
                    data.Apellido = dr["Apellido"].ToString();
                    data.Email = dr["Email"].ToString();
                    data.Fecha = Convert.ToDateTime(dr["Fecha"]);
                    data.Descripcion = dr["Descripcion"].ToString();

                    //Por cada DATA COMPLETA que encuentra la agrego a la lista de DATA
                    totalData.Add(data);
                }
            }

            conn.Close();
            return totalData;





        }*/

        public void Eliminar(int idRecibido)
        {
            string conexion = ConexionSQL();
            string query = "DELETE FROM " + nameTabla + " WHERE ID = @ID ";


                try
                {

                    using (SqlConnection conn = new SqlConnection(conexion))
                    {
                        SqlCommand cursor=new SqlCommand(query,conn);
                        
                            cursor.Parameters.AddWithValue("@ID", idRecibido);
                           
                            
                            //Open de Connection 
                            conn.Open();
                            cursor.ExecuteNonQuery();
                            conn.Close();
                            
                    
                     }

                }
                catch(Exception e)
                {
                    throw e;
                }

           


        }   //Conexion BD con C# Elimar


        public void Actualizar(ObjetoSql objetoRecibido,int idRecibidoXURL)
        {
            string conexion = ConexionSQL();
            string query = "UPDATE Tabla1 SET  Nombre = @NAME, Apellido = @SURNAME ,Email = @EMAIL , Fecha = @FECHA, Descripcion = @DESCRIPCION  WHERE ID = @ID";
            try
            {
                using (SqlConnection conn= new SqlConnection(conexion))
                {

                    SqlCommand cursor = new SqlCommand(query,conn);
                    //cursor.CommandType = CommandType.StoredProcedure;
                    //Tiene que recibir los parametros
                    cursor.Parameters.AddWithValue("@ID", idRecibidoXURL);
                    cursor.Parameters.AddWithValue("@NAME",objetoRecibido.Nombre );
                    cursor.Parameters.AddWithValue("@SURNAME",objetoRecibido.Apellido);
                    cursor.Parameters.AddWithValue("@EMAIL",objetoRecibido.Email);
                    cursor.Parameters.AddWithValue("@FECHA",objetoRecibido.Fecha);
                    cursor.Parameters.AddWithValue("DESCRIPCION",objetoRecibido.Descripcion);
                    
                    

                    conn.Open();
                    cursor.ExecuteNonQuery();
                    conn.Close();

                    

                }
            }
            catch (Exception e)
            {
                throw e;
            }



        }


       
    }
}