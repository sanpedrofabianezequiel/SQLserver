using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SQLConnection
{
    public partial class index : System.Web.UI.Page
    {
        private static int eleccion;
       
        protected void Page_Load(object sender, EventArgs e)
        {
           getAllData();
           
            

        }
      
 
        public void getAllData()
        {
            //Configuraciones del GridView
            this.idData.AutoGenerateColumns = false;
          

            ObjetoSql obj = new ObjetoSql();
            this.idData.DataSource= obj.GetInformacionTotal();
            this.idData.DataBind();
           

            this.idData.AutoGenerateSelectButton = true;
        }

        protected void verOpciones(object sender, EventArgs e)
        {
            //Generacion del Select
                 
            

            //Generecion la visibilidad de los 4 botones 
            this.nuevo.Visible = true;
            this.editar.Visible = true;           
            this.eliminar.Visible = true;
           


        }

        protected void idOpciones(object sender, EventArgs e)
        {   //Con este metodo setiado en el HTML, dentro del GRIDVIEW me permite, obtener el ID
            //previamente tuve que generar dentro de su HEAD el evento OnSelectedIndexChanged
            eleccion = Convert.ToInt32( idData.SelectedRow.Cells[1].Text);
            // this.labelId.Text = idData.SelectedRow.Cells[1].Text.ToString();
            // this.labelId2.Text = realizarAccion.ToString();
            this.labelId.Text = "El numero es:  " + eleccion.ToString();


        }
       
        protected void nuevoEvento(object sender, EventArgs e)
        {
            // Response.Redirect("Editar.aspx");

            Response.Redirect("Editar.aspx?idEdit=1&idNuevo=yes");
        }
        protected void editarEvento(object sender, EventArgs e)
        {
            if (eleccion <= 0)
            {
                Response.Write("<script class='alert alert-danger'>alert(' Debe Seleccionar un dato para continuar')</script>");
            }
            else if(eleccion >=1)
            {
                //Accion 
                //Envio la Informacion por URL del ID 

                Response.Redirect("Editar.aspx?idEdit=" + eleccion+"&idNuevo=no");

            }
                  
           
        }
        protected void eliminarEvento(object sender, EventArgs e)
        {
            if (eleccion <= 0)
            {
                Response.Write("<script class='alert alert-danger'>alert(' Debe Seleccionar un dato para continuar')</script>");
            }else if (eleccion >=0)
            {
                //Accion
                ObjetoSql obj = new ObjetoSql();
                obj.Eliminar(eleccion);
                //Reinicionar Eleccion
                eleccion = 0;
                Response.Redirect("index.aspx");
            }
           
        }
    }
}  


//Con el Index Obtenido realizar la accion correspondiente
//ObjetoSql obj = new ObjetoSql();
// obj.Eliminar(index);