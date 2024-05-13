<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="take_notes.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <div class="container">
        <div class="row justify-content-center mt-5">
            <div class="col-md-4">
                <div class="card">
                    <div class="card-header">
                        <h4 class="text-center">Taking Notes</h4>
                    </div>
                    <div class="card-body">
                        <form runat="server">
                            <div class="form-group">
                                <label for="txtName">Name:</label>
                                <asp:TextBox ID="txtName" CssClass="form-control" runat="server" placeholder="test"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label for="txtPassword">Password:</label>
                                <asp:TextBox ID="txtPassword" TextMode="Password" CssClass="form-control" runat="server" placeholder="test123"></asp:TextBox>
                            </div>
                            <asp:Button ID="btnLogin" Text="Sign in" CssClass="btn btn-primary btn-block" runat="server" OnClick="btnLogin_Click" />
                            <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
</body>
</html>
