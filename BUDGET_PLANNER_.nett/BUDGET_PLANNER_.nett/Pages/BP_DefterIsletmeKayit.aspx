<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BP_DefterIsletmeKayit.aspx.cs" Inherits="BUDGET_PLANNER_.nett.Pages.BP_DefterIsletmeKayıt" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../Styles/DefterIsletmeKayitStyle.css" rel="stylesheet" />
    <title>Defter ve İşletme Kayıt</title>
</head>


<script type="text/javascript" lang="js">  
    function txtOnKeyPress(txt1, lbl) {
        if (txt1 != 'undefined') {
            lbl.innerHTML = txt1.value;
        }
    }

    function DDownListChange(dList, lbl) {
        if (dList != 'undefined') {
            lbl.innerHTML = dList.value;
        }
    }

</script>

<body>
    <form id="form1" runat="server">
        <div>
            <div class="bg-container">
                <div class="form-container">
                    <h1>Defter Oluştur
                    </h1>
                    <div class="input-group">
                        <label>Defter Adı</label>
                        <asp:TextBox runat="server" ID="txtDefterAdi" CssClass="input" type="text" onkeydown="txtOnKeyPress(this,lblDefterAdi)" onBlur="txtOnKeyPress(this,lblDefterAdi)"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                            ControlToValidate="txtDefterAdi" ErrorMessage="*"></asp:RequiredFieldValidator>
                    </div>
                    <div class="input-group">
                        <label>Defter Açıklaması</label>
                        <asp:TextBox runat="server" ID="txtDefterAciklamasi" CssClass="input" onkeydown="txtOnKeyPress(this,lblDefterAciklamasi)" onBlur="txtOnKeyPress(this,lblDefterAciklamasi)"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                            ControlToValidate="txtDefterAciklamasi" ErrorMessage="*"></asp:RequiredFieldValidator>
                    </div>
                    <h2>İşletme Bilgileri</h2>
                    <div class="input-group">
                        <label>İşletme Türü</label>
                        <asp:DropDownList runat="server" ID="dListIsletmeTuru" CssClass="input" onchange="DDownListChange(this,lblIsletmeTuru)">
                            <asp:ListItem>Seçiniz</asp:ListItem>
                            <asp:ListItem>Küçük İşletme</asp:ListItem>
                            <asp:ListItem>Büyük İşletme</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="input-group">
                        <label>İşletme Adı</label>
                        <asp:TextBox runat="server" ID="txtIsletmeAdi" CssClass="input" onkeydown="txtOnKeyPress(this,lblIsletmeAdi)" onBlur="txtOnKeyPress(this,lblIsletmeAdi)"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                            ControlToValidate="txtIsletmeAdi" ErrorMessage="*"></asp:RequiredFieldValidator>
                    </div>
                    <div class="input-group">
                        <label>İşletme Açıklaması</label>
                        <asp:TextBox runat="server" ID="txtIsletmeAciklamasi" CssClass="input" onkeydown="txtOnKeyPress(this,lblIsletmeAciklamasi)" onBlur="txtOnKeyPress(this,lblIsletmeAciklamasi)"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                            ControlToValidate="txtIsletmeAciklamasi" ErrorMessage="*"></asp:RequiredFieldValidator>
                    </div>
                    <div class="btn-container">
                        <asp:Button runat="server" CssClass="btn" Text="Kaydet" OnClick="btn_Click" />
                    </div>

                </div>


                <div class="photo">
                    <div class="form-placeholder">
                        <h2>Defter Bilgileri
                        </h2>
                        <div class="input-group">
                            <label>Defter Adı :</label>
                            <asp:Label runat="server" ID="lblDefterAdi" CssClass="label-input"></asp:Label>
                        </div>
                        <div class="input-group">
                            <label>Defter Açıklaması :</label>
                            <asp:Label runat="server" ID="lblDefterAciklamasi" CssClass="label-input"></asp:Label>
                        </div>
                        <h2>İşletme Bilgileri</h2>
                        <div class="input-group">
                            <label>İşletme Türü :</label>
                            <asp:Label runat="server" ID="lblIsletmeTuru" CssClass="label-input"></asp:Label>
                        </div>
                        <div class="input-group">
                            <label>İşletme Adı :</label>
                            <asp:Label runat="server" ID="lblIsletmeAdi" CssClass="label-input"></asp:Label>
                        </div>
                        <div class="input-group">
                            <label>İşletme Açıklaması : </label>
                            <asp:Label runat="server" ID="lblIsletmeAciklamasi" CssClass="label-input"></asp:Label>
                        </div>
                        <div class="message-container">
                            <asp:Label ID="lblMesaj" runat="server"></asp:Label>
                        </div>
                    </div>
                    <img src="../Images/parsomen.png" />
                </div>

            </div>

        </div>
    </form>
</body>
</html>
