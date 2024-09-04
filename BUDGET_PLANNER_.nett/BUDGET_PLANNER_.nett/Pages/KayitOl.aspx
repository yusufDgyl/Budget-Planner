<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KayitOl.aspx.cs" Inherits="BUDGET_PLANNER_.nett.Pages.KayitOl" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../Styles/KayitOlStyle.css" rel="stylesheet" />
    <title>Kayıt Ol</title>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="container">
                <div class="register-container">
                    <div class="register-form">
                        <h2>Kayıt Ol</h2>
                        <div class="form-control">
                            <label for="txtAd">Ad</label>
                            <asp:TextBox runat="server" ID="txtAd" placeholder="Ad" type="text" CssClass="input"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" ID="txtKulAdiValidator"
                                ErrorMessage="Boş bırakılamaz" ControlToValidate="txtAd" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-control">
                            <label for="txtSurname">Soyad</label>
                            <asp:TextBox runat="server" ID="txtSurname" placeholder="Soyad" type="text" CssClass="input"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1"
                                ErrorMessage="Boş bırakılamaz" ControlToValidate="txtSurname" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-control">
                            <label for="txtMail">E-Posta</label>
                            <asp:TextBox runat="server" ID="txtMail" placeholder="E-posta" type="email" CssClass="input"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator2"
                                ErrorMessage="Boş bırakılamaz" ControlToValidate="txtMail" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-control">
                            <label for="txtKulAdi">Kullanıcı Adı</label>
                            <asp:TextBox runat="server" ID="txtKulAdi" placeholder="Kullanıcı Adı" type="text" CssClass="input"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator3"
                                ErrorMessage="Boş bırakılamaz" ControlToValidate="txtKulAdi" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-control">
                            <label for="txtSifre">Şifre</label>
                            <asp:TextBox runat="server" ID="txtSifre" placeholder="Şifre" type="password" CssClass="input"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator4"
                                ErrorMessage="Boş bırakılamaz" ControlToValidate="txtSifre" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                        <asp:ScriptManager runat="server"></asp:ScriptManager>
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <asp:Button runat="server" ID="btnKayitOl" OnClick="btnKayitOl_Click" Text="Kayıt Ol" CssClass="btn" />
                                <div class="form-text">
                                    <p>Zaten bir <a href="Login.aspx">hesabın var mı?</a></p>
                                    <div>
                                        <asp:Label runat="server" ID="lblMesaj"></asp:Label>
                                    </div>
                                </div>

                                <asp:UpdateProgress runat="server">
                                <progresstemplate>
                                    <asp:Label runat="server" ID="lblMesajGiris">Kayıt Başarıyla Tamamlandı! Yönlendiriyoruz..</asp:Label>
                                </progresstemplate>
                            </asp:UpdateProgress>

                            </ContentTemplate>


                            

                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
