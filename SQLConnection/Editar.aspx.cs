using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SQLConnection
{
    public partial class Editar : System.Web.UI.Page
    {

        int idRecibidoURL;
        string estado;
       
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request.QueryString["idEdit"] != "")    //Verificamos si existe una Query
            {                                               // la setiamos en la variable global
                idRecibidoURL = Convert.ToInt32( Request.QueryString["idEdit"] );
                estado = Request.QueryString["idNuevo"].ToString();
            }
            else
            {
                Response.Redirect("index.aspx");
            }






            //Cargamos la pagina si es primera vez

            if (!IsPostBack)
            {
                if (estado=="no" &&  idRecibidoURL >=1)
                {
                     CargLibroRecibido(idRecibidoURL);
                    

                }
                else if (estado=="yes" && idRecibidoURL >=1)
                {

                }
      
              
            }
                
                   
               
               
            
            


        }

        protected void CargLibroRecibido(int idBack)
        {
            //Hacemos la consulta y setiamos la informaciona  modificar dentro de los textBox con el ID recibido
            //Se podia hacer  con un store Procedure en SQL
            //En este caso lo vamos hacer de forma manual

            ObjetoSql miObj = new ObjetoSql();
            //LLamamos al metodo onlineData()

            //Necesitamos GUARDAR EL RETURN de la funcion en una variable del Mismo tipo para luego acceder
            //a sus ATRIBUTOS
            miObj = miObj.OnlineData(idRecibidoURL);

           
            //Asignamos el textbox con la informacion recbidida
            this.idNombre.Text = miObj.Nombre.ToString();
            this.idApellido.Text = miObj.Apellido.ToString();
            this.idEmail.Text =miObj.Email.ToString();
            this.idFecha.Text = miObj.Fecha.ToString(); 
            this.idDescripcion.Text = miObj.Descripcion.ToString();

        }
        protected void Cancelar(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }
        protected void Aceptar(object sender, EventArgs e)
        {

            if (this.idNombre.Text=="" | this.idApellido.Text=="" | this.idEmail.Text=="" | this.idFecha.Text=="" |this.idDescripcion.Text=="")
            {
                Response.Write("<script>alert('Complete todos los campos')</script>");
            }
            else
            {
                ObjetoSql objSend = new ObjetoSql();

                objSend.Nombre = this.idNombre.Text;
                objSend.Apellido = this.idApellido.Text;
                objSend.Email = this.idEmail.Text;
                objSend.Fecha = Convert.ToDateTime(this.idFecha.Text);
                objSend.Descripcion = this.idDescripcion.Text;




                if (idRecibidoURL >= 1 && estado == "no")
                {
                    objSend.Actualizar(objSend, idRecibidoURL);

                }
                else if (idRecibidoURL >= 1 && estado == "yes")
                {
                    objSend.Insertar(objSend);
                }

                Response.Redirect("index.aspx");


            }





        }

       
    }
}