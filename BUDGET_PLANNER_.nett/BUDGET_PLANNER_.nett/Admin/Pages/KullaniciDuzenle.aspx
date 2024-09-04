<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPages/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="KullaniciDuzenle.aspx.cs" Inherits="BUDGET_PLANNER_.nett.Admin.Pages.KullaniciDuzenle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/KullaniciDuzenleStyle.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="form-container">

        <div class="form">

            <div class="box" style="text-align:left;">
                <p style="display:inline-block; margin-right:10px;">Kullanıcı Kodu</p>
                <asp:Label runat="server" ID="lblId" CssClass="lblId"></asp:Label>
            </div>
            <div class="box">
                <p>Kullanıcı Adı</p>
                <asp:TextBox runat="server" ID="txtKulAdi" CssClass="txtDuzenle"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                    ControlToValidate="txtKulAdi" ErrorMessage="*"></asp:RequiredFieldValidator>
            </div>
            <div class="box">
                <p>Şifre</p>
                <asp:TextBox runat="server" ID="txtSifre" CssClass="txtDuzenle"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                    ControlToValidate="txtSifre" ErrorMessage="*"></asp:RequiredFieldValidator>
            </div>
            <div class="box">
                <p>Tekrar Şifre</p>
                <asp:TextBox runat="server" ID="txtTekrarSifre" CssClass="txtDuzenle"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                    ControlToValidate="txtTekrarSifre" ErrorMessage="*"></asp:RequiredFieldValidator>
            </div>
            <div class="box">
                <p>Hesap Durumu</p>
                <asp:RadioButton  runat="server" ID="rbAcik" Text="Açık" GroupName="durum"/>
                <asp:RadioButton  runat="server" ID="rbKapali" Text="Kapalı" GroupName="durum"/>    
            </div>
            <div class="box">
                <asp:Label ID="lblMesaj" runat="server"></asp:Label>
            </div>
            <div class="box">
                <asp:Button ID="btnEkle" runat="server" Text="EKLE" CssClass="genelButon btnEkle"
                    OnClick="btnEkle_Click" />
                <asp:Button ID="btnGuncelle" runat="server" Text="GÜNCELLE"
                    CssClass="genelButon btnGuncelle" OnClick="btnGuncelle_Click" />
                <asp:Button ID="btnSil" runat="server" Text="SİL" CssClass="genelButon btnSil"
                    OnClick="btnSil_Click" ValidationGroup="555" />
            </div>
            <div class="kulSec">
                <p>Kullanıcı Seç</p>
                <asp:DropDownList runat="server" ID="dDownListKul" CssClass="dDownList" OnSelectedIndexChanged="dDownListKul_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                <p>**Bu alan sadece güncelleme ve silme işlemlerinde kullanılabilir.</p>
            </div>


        </div>


    </div>



</asp:Content>
