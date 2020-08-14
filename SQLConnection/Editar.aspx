<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Editar.aspx.cs" Inherits="SQLConnection.Editar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" />

    <title>CRUD</title>
</head>
<body>

    <h1 style="text-align: center;">CRUD</h1>
    <div class="container">
        <form id="form1" runat="server" style="text-align: center;">
            <div style="text-align: center;">
                <p>Coneccion Base de Datos SQL SERVER </p>

                <p id="idParrafo"> San Pedro Fabian Ezequiel </p>
                
                <hr />

                <div>
                    <asp:Label runat="server" Text="Ingrese la informacion Pertinente"></asp:Label>
                    <br />
                  
                </div>
               
                <div class="text-left">

                  
                    <asp:Label runat="server" Text="Nombre"></asp:Label>
                        <br />
                            <asp:TextBox runat="server" ID="idNombre"></asp:TextBox>
                                <br />
                    <asp:Label runat="server" Text="Apellido"></asp:Label>
                        <br />
                            <asp:TextBox runat="server" ID="idApellido"></asp:TextBox>
                                <br />
                     <asp:Label runat="server" Text="Fecha"></asp:Label> 
                        <br />
                            <asp:TextBox runat="server" ID="idFecha"></asp:TextBox><div style="color:grey; font-size:small;">(Day/Month/Year)</div>
                                <br />
                    <asp:Label runat="server" Text="Email"></asp:Label>
                        <br />
                            <asp:TextBox runat="server" ID="idEmail"></asp:TextBox>
                                <br />
                   
                    <asp:Label runat="server" Text="Descripcion"></asp:Label>
                        <br />
                            <asp:TextBox runat="server" ID="idDescripcion"></asp:TextBox>

                    <br style="margin-top:50px;" />
                    <br />
                    <!--Button-->
                     <asp:Button runat="server" Text="Aceptar" ID="idAceptar" OnClick="Aceptar"  class="btn-primary" />
                         <asp:Button runat="server" Text="Cancelar" ID="idCancelar" OnClick="Cancelar" class="btn-danger"/>
                        
                </div>

               

            </div>
            <footer style="text-align:center;">
               
                    <p id=""> San Pedro Fabian Ezequiel  </p>
                        <span> Derechos Reservados </span>
            </footer>



        </form>
    </div>
    <script src="Scripts/jquery-3.0.0.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
</body>
</html>
