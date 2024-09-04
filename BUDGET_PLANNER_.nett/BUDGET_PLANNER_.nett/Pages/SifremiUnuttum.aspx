<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SifremiUnuttum.aspx.cs" Inherits="BUDGET_PLANNER_.nett.Pages.SifremiUnuttum" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Şifremi Unuttum</title>
    <link href="../Styles/SifremiUnuttumStyle.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="container">
                <div class="register-container">
                    <div action="#" class="register-form">
                        <h2>Şifre Yenileme</h2>
                        <asp:ScriptManager runat="server" ID="scriptmanager"></asp:ScriptManager>
                        <asp:UpdatePanel runat="server" ID="updatePnl" UpdateMode="Conditional" ChildrenAsTriggers="true">
                            <ContentTemplate>
                                <asp:Panel runat="server" ID="pnlFirstArea">
                                    <div class="form-control">
                                        <asp:Label runat="server" ID="lblMail" for="txtMail">E-Posta</asp:Label>
                                        <asp:TextBox runat="server" ID="txtMail" type="email" CssClass="input" placeholder="E-Posta"></asp:TextBox>
                                    </div>
                                </asp:Panel>
                                <asp:Panel runat="server" ID="pnlSecondArea">
                                    <div class="form-control">
                                        <asp:Label runat="server" ID="lblKod" for="txtKod">Kod</asp:Label>
                                        <asp:TextBox runat="server" ID="txtKod" type="number" CssClass="input" placeholder="Kod"></asp:TextBox>
                                    </div>
                                </asp:Panel>
                                <asp:Panel runat="server" ID="pnlPasswordArea">
                                    <div class="form-control">
                                        <label for="txtSifre">Şifre</label>
                                        <asp:TextBox runat="server" ID="txtSifre" type="password" CssClass="input" placeholder="Şifre"></asp:TextBox>
                                    </div>
                                    <div class="form-control">
                                        <label for="txtTekrarSifre">Tekrar Şifre</label>
                                        <asp:TextBox runat="server" ID="txtTekrarSifre" type="password" CssClass="input" placeholder="Tekrar Şifre"></asp:TextBox>
                                    </div>
                                </asp:Panel>
                                <asp:Button  runat="server" ID="btnGonder" CssClass="btn" Text="Gönder" OnClick="btnGonder_Click" AutoPostback="false" />
                                <asp:Button  runat="server" ID="btnKod" CssClass="btn" Text="Kodu Onayla" OnClick="btnKod_Click" AutoPostback="false" />
                                <asp:Button  runat="server" ID="btnSifreDegistir" CssClass="btn" Text="Şifre Değiştir" OnClick="btnSifreDegistir_Click" AutoPostBack="false" />

                                <div class="form-text">
                                    <asp:Label runat="server" ID="lblMesaj"></asp:Label>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>

                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
