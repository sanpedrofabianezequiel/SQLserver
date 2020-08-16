# SQLserver

El siguiente Repositiorio 
Cuenta con una carpeta Base de Datos insertada en SQLSERVER
Donde se van a realizar las Querys

EL programa esta desarrollado en Csharp, IDE: Visual Studio

Utilizamos estas dos tecnologias y realizamos un Software tipo CRUD. 

San Pedro Fabian Ezequiel


/*
Notas y Manejo de errores

 protected void Page_Error()
        {
            Exception ex = Server.GetLastError();
            Session["Error"] = ex.Message;
            Server.Transfer("~/PageError.aspx");

        }

        //Pagina receptora//----------------------------------------

        Exception ex = (Exception)Session["Error"];
        this.idLabel.Text=ex.Message;
        Session["Error"]=null;



/-------------------------------------------
En el archivo Global.asax.cs

protected void Application_Error(object sender, EventArgs e)
        {
            Exception ex = Server.GetLastError();
            Session["Error"] = ex.Message;
            Server.ClearError();
            Server.Transfer("~/PaginaError.aspx?ex=" + ex);
        }

*/
