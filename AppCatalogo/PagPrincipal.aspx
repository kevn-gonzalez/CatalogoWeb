<%@ Page Title="" Language="C#" MasterPageFile="~/Catalogo.Master" AutoEventWireup="true" CodeBehind="PagPrincipal.aspx.cs" Inherits="AppCatalogo.PagPrincipal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Bienvenidos
    </h1>
    <h2>En esta pagina podras encontrar los mejores articulos del mercado
    </h2>

    <div class="row row-cols-1 row-cols-md-3 g-4">

        <%--        <% 
            foreach (ClasesArt.Articulos art in ListaArticulos)
            {
        %>

        <div class="col">
            <div class="card">
                <img src="<%: art.ImagenUrl %>" class="card-img-top" alt="...">
                <div class="card-body">
                    <h5 class="card-title"><%: art.Nombre %></h5>
                    <p class="card-text"><%: art.Descripcion %></p>
                    <a href="Detalles.aspx?Id= <%:art.Id %>">Detalles</a>
                </div>
            </div>
        </div>

        <%  } %>--%>

        <asp:Repeater ID="Repetidor" runat="server">
            <ItemTemplate>
                <div class="col">
                    <div class="card">
                        <img src="<%# Eval("ImagenUrl") %>" class="card-img-top" alt="...">
                        <div class="card-body">
                            <h5 class="card-title"><%# Eval("Nombre") %></h5>
                            <p class="card-text"><%# Eval("Descripcion") %></p>
                            <a href="Detalles.aspx?Id= <%# Eval("Id") %>">Detalles</a>
                            <asp:Button Text="ejemplo" cssclass="btn btn-primary" ID="btnEjemplo" runat="server" CommandArgument='<%#Eval("Id") %>' CommandName="ArtId" OnClick="btnEjemplo_Click" />
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>

    </div>

</asp:Content>
