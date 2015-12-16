<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="Index.aspx.cs" Inherits="SisBim.Vista.Default" %>

<!DOCTYPE html>
<html lang="es">
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="description" content="SisBim - Sistema de Reservas para Bibliotecas">
    <meta name="author" content="OCR innovaciones">

    <title>SisBim - Sistema de Reservas para Bibliotecas</title>
    <!-- Bootstrap CSS -->
    <link href="css/bootstrap.min.css" rel="stylesheet">
    <!-- bootstrap theme -->
    <link href="css/bootstrap-theme.css" rel="stylesheet">
    <!--external css-->
    <!-- font icon -->
    <link href="css/elegant-icons-style.css" rel="stylesheet" />
    <link href="css/font-awesome.css" rel="stylesheet" />
    <!-- Custom styles -->
    <link href="css/style.css" rel="stylesheet">
    <link href="css/style-responsive.css" rel="stylesheet" />

    <!-- HTML5 shim and Respond.js IE8 support of HTML5 -->
    <!--[if lt IE 9]>
    <script src="js/html5shiv.js"></script>
    <script src="js/respond.min.js"></script>
    <![endif]-->
</head>
<body class="login-img3-body">
    <div class="container">
        <form id="frmLogin" runat="server" class="login-form">
            <div class="login-wrap">
                <p class="login-img"><i class="icon_lock_alt"></i></p>
                <div class="input-group">
                    <span class="input-group-addon"><i class="icon_profile"></i></span>
                    <asp:TextBox ID="tbRut" runat="server" CssClass="form-control" placeholder="RUT" autofocus />
                </div>
                <div class="input-group">
                    <span class="input-group-addon"><i class="icon_key_alt"></i></span>
                    <asp:TextBox ID="tbClave" runat="server" CssClass="form-control" TextMode="Password" placeholder="Contraseña" />
                </div>
                <div class="red-bg" style="text-align: center;">
                    <asp:Label runat="server" ID="lblMensaje" CssClass="mensajeLogin" />
                </div>
                <div style="margin-top: 10px;">
                    <asp:Button runat="server" ID="btnIngresar" Text="Ingresar" class="btn btn-primary btn-lg btn-block" OnClick="Ingresar" />
                </div>
            </div>
        </form>
    </div>
</body>
</html>
