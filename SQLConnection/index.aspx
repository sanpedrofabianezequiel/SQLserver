<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="SQLConnection.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    
    <title>CRUD</title>
</head>
<body>

    <h1 style="text-align: center;">CRUD</h1>
    <div class="container">


        <form id="form1" runat="server" style="text-align: center;">
            <div style="text-align: center;">
                <p>Coneccion Base de Datos SQL SERVER </p>

                    
                    <hr />
                <asp:GridView runat="server" ID="idData"  OnSelectedIndexChanged="idOpciones"  class="table table-striped table-dark" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="objetoID" HeaderText="ID" />
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                        <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                        <asp:BoundField DataField="Email" HeaderText="Email" />
                        <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                        <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />


                    </Columns>
                     
                </asp:GridView>
                    <div class="text-left">
                         
                         <asp:Button runat="server" Text="Ver Opciones" OnClick="verOpciones"  class="btn-primary"/>
                         <asp:Button runat="server" Text="Nuevo" ID="nuevo" Visible="false" OnClick="nuevoEvento" class="btn-primary"/> 
                         <asp:Button runat="server" Text="Editar" ID="editar" Visible="false" OnClick="editarEvento" class="btn-primary"/>
                         <asp:Button runat="server" Text="Eliminar" ID="eliminar" Visible="false" OnClick="eliminarEvento" class="btn-danger" />
                       
                     </div >
            </div>
          
               
        

            <asp:Label runat="server" ID="labelId"></asp:Label>
          
        </form>
    </div>
    <script src="Scripts/jquery-3.0.0.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
</body>
</html>
