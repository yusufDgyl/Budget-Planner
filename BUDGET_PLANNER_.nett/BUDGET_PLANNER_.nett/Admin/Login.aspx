<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="BUDGET_PLANNER_.nett.Admin.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="Styles/Admin-Login.css" rel="stylesheet" />
    <title>Admin Giriş</title>
</head>
<body>
    <form id="form1" runat="server">
        <header>
            <div class="header-baslik">
                <h1>Admin Giriş</h1>
            </div>
        </header>
        <main>
            <div class="login-container">
                <div class="login">
                    <div class="username">
                        <asp:TextBox placeholder="Kullanıcı Adı" type="text" class="txt" runat="server" ID="txtKulAdi"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ID="txtKulAdiValidator"
                            ErrorMessage="Boş bırakılamaz" ControlToValidate="txtKulAdi" forecolor="Red"></asp:RequiredFieldValidator>
                    </div>
                    <div class="pass">
                        <asp:TextBox placeholder="Parola" type="password" class="txt" runat="server" ID="txtParola"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ID="txtParolaValidator"
                            ErrorMessage="Boş bırakılamaz" ControlToValidate="txtParola" forecolor="Red"></asp:RequiredFieldValidator>
                    </div>
                    <div class="chk">
                        <asp:CheckBox  ID="chkHatirla" runat="server" text="Beni hatırla"/>
                    </div>
                    <div class="buttonGiris" >
                        <asp:Button runat="server" ID="btnGirisYap" CssClass="btn" text="Giriş Yap" onclick="BtnGirisYap_Click"/>
                        <asp:Label ID="lblMesaj" runat="server" CssClass="lbl-mesaj"></asp:Label>
                    </div>
                </div>

            </div>
        </main>
    </form>

    <script src="Scripts/jquery-1.9.1min.js" type="text/javascript"></script>

</body>
</html>
