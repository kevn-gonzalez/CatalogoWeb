<%@ Page Title="" Language="C#" MasterPageFile="~/Catalogo.Master" AutoEventWireup="true" CodeBehind="ListaArticulos.aspx.cs" Inherits="AppCatalogo.Defoult" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1> Lista de articulos</h1>
    <asp:GridView id="dgvArticulos" runat="server" CssClass ="table" AutoGenerateColumns ="false">
        <Columns>
            <asp:BoundField headerText ="Nombre" DataField="Nombre"/>
            <asp:BoundField headerText ="IdMarca" DataField="IdMarca.Descripcion"/>
            <asp:BoundField headerText ="IdCategoria" DataField="IdCategoria.Descripcion"/>
        </Columns>

    </asp:GridView>
    
</asp:Content>
