<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="BUDGET_PLANNER_.nett.Pages.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../Styles/LoginStyle.css" rel="stylesheet" />
    <title>Giriş Yap</title>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="container">
                <div class="register-container">
                    <div action="#" class="register-form">
                        <h2>Giriş Yap</h2>
                        <asp:ScriptManager runat="server" ID="smanager2"></asp:ScriptManager>


                        <div class="form-control">
                            <label for="username">Kullanıcı Adı</label>
                            <asp:TextBox placeholder="Kullanıcı Adı" runat="server" type="text" ID="txtKulAdi"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" ID="txtKulAdiValidator"
                                ErrorMessage="Boş bırakılamaz" ControlToValidate="txtKulAdi" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-control">
                            <label for="password">Şifre</label>
                            <asp:TextBox placeholder="Şifre" runat="server" type="password" ID="txtSifre"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1"
                                ErrorMessage="Boş bırakılamaz" ControlToValidate="txtSifre" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>


                        <asp:UpdatePanel runat="server" ID="upanel" UpdateMode="Always">
                            <ContentTemplate>
                                <asp:Button Text="Giriş Yap" ID="btnGirisYap" runat="server" CssClass="btn" OnClick="BtnGirisYap_Click" />

                                <div>
                                    <asp:Label runat="server" ID="lblMesaj"></asp:Label>
                                </div>

                                <asp:UpdateProgress runat="server">
                                    <ProgressTemplate>
                                        <div>
                                            <asp:Label runat="server" ID="lblGirisMesaj">Giriş Başarılı! Yükleniyor..</asp:Label>
                                        </div>
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                            </ContentTemplate>
                        </asp:UpdatePanel>




                        <div class="form-text">
                            <p>Şifreni mi <a href="SifremiUnuttum.aspx">Unuttun ?</a></p>
                            <p><a href="KayitOl.aspx">Kayıt Ol</a></p>
                        </div>




                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
