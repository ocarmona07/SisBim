<%@ Page Title="" Language="C#" MasterPageFile="~/Base.Master" AutoEventWireup="true" CodeBehind="MantenedorUsuarios.aspx.cs" Inherits="SisBim.Vista.MantenedorUsuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphMasterHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMasterBody" runat="server">
    <form runat="server">
        <div class="row">
            <div class="col-lg-12">
                <h3 class="page-header"><i class="fa fa-users"></i>Mantenedor de Usuarios</h3>
                <ol class="breadcrumb">
                    <li><i class="fa fa-home"></i><a href="Inicio.aspx">Inicio</a></li>
                    <li><i class="fa fa-desktop"></i>Administrador</li>
                    <li><i class="fa fa-users"></i>Mantenedor de Usuarios</li>
                </ol>
            </div>
        </div>
        <div class="panel-body" style="text-align: right;">
            <asp:Button runat="server" ID="btnCrearUsuario" class="btn btn-primary btn-lg" Width="200px" Text="Crear Usuario"
                PostBackUrl="CrearUsuario.aspx" />
        </div>
        <div>
            <asp:GridView runat="server" ID="gvUsuarios" AutoGenerateColumns="False" GridLines="None"
                CssClass="table table-striped table-advance table-hover" EmptyDataText="No existen usuarios registrados!"
                OnRowDataBound="UsuariosDataBound">
                <Columns>
                    <asp:TemplateField HeaderText="RUT" ItemStyle-Width="120px">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblRut" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="Nombres" DataField="Nombres" />
                    <asp:BoundField HeaderText="Apellido Paterno" DataField="ApellidoPaterno" />
                    <asp:BoundField HeaderText="Apellido Materno" DataField="ApellidoMaterno" />
                    <asp:TemplateField HeaderText="Perfil">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblPerfil" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Acciones">
                        <ItemTemplate>
                            <asp:Button runat="server" ID="btnEditar" CommandName="Editar" CommandArgument='<%# Eval("RUT") %>'
                                CssClass="btn btn-primary"></asp:Button>
                            <asp:Button runat="server" ID="btnEstado" CommandName="Estado" CommandArgument='<%# Eval("RUT") %>'
                                OnClientClick="javascript: return confirm('¿Desea desactivar el usuario?');"
                                CssClass='<%# true.Equals(Eval("Estado")) ? "btn btn-success" : "btn btn-danger" %>'></asp:Button>
                            <i class='icon_<%# true.Equals(Eval("Estado")) ? "check" : "close" %>_alt2'></i>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</asp:Content>
