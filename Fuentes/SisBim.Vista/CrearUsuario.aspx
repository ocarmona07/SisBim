<%@ Page Title="" Language="C#" MasterPageFile="~/Base.Master" AutoEventWireup="true" CodeBehind="CrearUsuario.aspx.cs" Inherits="SisBim.Vista.CrearUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphMasterHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMasterBody" runat="server">
    <div class="row">
        <div class="col-lg-12">
            <h3 class="page-header"><i class="fa fa-user"></i>
                <asp:Label runat="server" ID="lblCrearUsuario" /></h3>
            <ol class="breadcrumb">
                <li><i class="fa fa-home"></i><a href="Inicio.aspx">Inicio</a></li>
                <li><i class="fa fa-desktop"></i>Administrador</li>
                <li><i class="fa fa-user"></i><%= lblCrearUsuario.Text %></li>
            </ol>
        </div>
    </div>
    <form runat="server" class="form-horizontal" method="get">
        <div class="row">
            <div class="col-lg-12">
                <section class="panel">
                    <header class="panel-heading">
                        <asp:Label runat="server" ID="lblTituloPanel" />
                    </header>
                    <div class="panel-body">
                        <div class="form-group">
                            <label class="col-sm-2 control-label">Nombres <span class="required">*</span></label>
                            <div class="col-sm-10">
                                <asp:TextBox runat="server" ID="tbNombres" CssClass="form-control" required />
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-sm-2 control-label">Apellido Paterno <span class="required">*</span></label>
                            <div class="col-sm-10">
                                <asp:TextBox runat="server" ID="tbApPaterno" CssClass="form-control" required />
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-sm-2 control-label">Apellido Materno</label>
                            <div class="col-sm-10">
                                <asp:TextBox runat="server" ID="tbApMaterno" CssClass="form-control" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-sm-2 control-label">Perfil <span class="required">*</span></label>
                            <div class="col-sm-10">
                                <asp:DropDownList runat="server" ID="ddlPerfil" CssClass="form-control m-bot15" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-sm-2 control-label">Clave</label>
                            <div class="col-sm-10">
                                <div class="alert alert-info fade in">
                                    <button data-dismiss="alert" class="close close-sm" type="button"></button>
                                    La clave de inicio por defecto será <strong>1234</strong>.
                                    Esta se cambiará en el primer acceso al sitio.
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-sm-2 control-label">Estado</label>
                            <div class="col-lg-10">
                                <asp:CheckBox runat="server" ID="chkEstado" Width="30px" Text="Activo" Checked="True"
                                    CssClass="checkbox form-control" />
                            </div>
                        </div>
                    </div>
                </section>
            </div>
        </div>
        <div class="row" style="text-align: center;">
            <div class="col-lg-4">
                <asp:Button runat="server" ID="btnGuardar" Text="Guardar" CssClass="btn btn-primary btn-lg" Width="150px"
                    OnClick="GuardarUsuario" />
            </div>
            <div class="col-lg-4">
                <input type="reset" value="Limpiar" class="btn btn-danger btn-lg" style="width: 150px" />
            </div>
            <div class="col-lg-4">
                <input class="btn btn-warning btn-lg" value="Volver" style="width: 150px"
                    onclick="if (confirm('¿Desea volver sin guardar los cambios?')) history.back(-1); else return false;" />
            </div>
        </div>
    </form>
</asp:Content>
