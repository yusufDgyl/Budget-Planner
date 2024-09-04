<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPages/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="PaketDuzenle.aspx.cs" Inherits="BUDGET_PLANNER_.nett.Admin.Pages.PaketDuzenle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/PaketDuzenleStyle.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="paket-container">
        <div class="plan-container">
            <div class="plan">
                <h4>
                    <asp:Label runat="server" ID="lblAdi"></asp:Label></h4>
                <h4>
                    <asp:Label runat="server" ID="lblFiyat"></asp:Label></h4>

                <ul>
                    <li>
                        <asp:Label runat="server" ID="lblListItem1"></asp:Label></li>
                    <li>
                        <asp:Label runat="server" ID="lblListItem2"></asp:Label></li>
                    <li>
                        <asp:Label runat="server" ID="lblListItem3"></asp:Label></li>
                    <li>
                        <asp:Label runat="server" ID="lblListItem4"></asp:Label></li>
                    <li>
                        <asp:Label runat="server" ID="lblListItem5"></asp:Label></li>
                </ul>
                <button class="btn" disabled="disabled"><a>
                    <asp:Label runat="server" ID="lblButonIcerik"></asp:Label></a></button>
            </div>

        </div>
        <div class="plan-container plan-content">
            <h2>
                <asp:Label runat="server" ID="lblHakkindaBaslik"></asp:Label></h2>
            <p>
                <asp:Label runat="server" ID="lblHakkindaIcerik"></asp:Label>
            </p>
            <button class="btn" disabled="disabled"><a>
                <asp:Label runat="server" ID="lblButonIcerik2"></asp:Label></a></button>
        </div>
        <div class="plan-container plan-input">
            <div>
                <div class="box">
                    <h4>Adi</h4>
                    <asp:TextBox runat="server" ID="txtPaketAdi" CssClass="txt" OnTextChanged="TextsChanged" AutoPostBack="true"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                        ControlToValidate="txtPaketAdi" ErrorMessage="*"></asp:RequiredFieldValidator>
                </div>
                <div class="box">
                    <h4>Fiyat</h4>
                    <asp:TextBox runat="server" ID="txtPaketFiyat" CssClass="txt" OnTextChanged="TextsChanged" AutoPostBack="true"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                        ControlToValidate="txtPaketFiyat" ErrorMessage="*"></asp:RequiredFieldValidator>
                </div>
                <div class="box">
                    <h4>Liste Elemanı 1</h4>
                    <asp:TextBox runat="server" ID="txtListItem1" CssClass="txt" OnTextChanged="TextsChanged" AutoPostBack="true"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                        ControlToValidate="txtListItem1" ErrorMessage="*"></asp:RequiredFieldValidator>
                </div>
                <div class="box">
                    <h4>Liste Elemanı 2</h4>
                    <asp:TextBox runat="server" ID="txtListItem2" CssClass="txt" OnTextChanged="TextsChanged" AutoPostBack="true"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                        ControlToValidate="txtListItem2" ErrorMessage="*"></asp:RequiredFieldValidator>
                </div>
                <div class="box">
                    <h4>Liste Elemanı 3</h4>
                    <asp:TextBox runat="server" ID="txtListItem3" CssClass="txt" OnTextChanged="TextsChanged" AutoPostBack="true"></asp:TextBox>
                </div>
                <div class="box">
                    <h4>Liste Elemanı 4</h4>
                    <asp:TextBox runat="server" ID="txtListItem4" CssClass="txt" OnTextChanged="TextsChanged" AutoPostBack="true"></asp:TextBox>
                </div>
                <div class="box">
                    <h4>Liste Elemanı 5</h4>
                    <asp:TextBox runat="server" ID="txtListItem5" CssClass="txt" OnTextChanged="TextsChanged" AutoPostBack="true"></asp:TextBox>
                </div>
                <div class="box">
                    <h4>Buton İçeriği</h4>
                    <asp:TextBox runat="server" ID="txtBtnIcerik" CssClass="txt" OnTextChanged="TextsChanged" AutoPostBack="true"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                        ControlToValidate="txtBtnIcerik" ErrorMessage="*"></asp:RequiredFieldValidator>
                </div>
                <div class="box">
                    <h4>Hakkında Başlık</h4>
                    <asp:TextBox runat="server" ID="txtHakkindaBaslik" CssClass="txt" OnTextChanged="TextsChanged" AutoPostBack="true"> </asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server"
                        ControlToValidate="txtHakkindaBaslik" ErrorMessage="*"></asp:RequiredFieldValidator>
                </div>
                <div class="box">
                    <h4>Hakkında İçeriği</h4>
                    <asp:TextBox runat="server" ID="txtHakkindaIcerik" CssClass="txt" OnTextChanged="TextsChanged" AutoPostBack="true"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server"
                        ControlToValidate="txtHakkindaIcerik" ErrorMessage="*"></asp:RequiredFieldValidator>
                </div>
                <div class="box">
                    <asp:Label ID="lblMesaj" runat="server"></asp:Label>
                </div>
                <div class="box">
                    <asp:Button runat="server" ID="btnEkle" Text="EKLE" CssClass="btn" OnClick="btnEkle_Click" />
                    <asp:Button runat="server" ID="btnGuncelle" Text="GUNCELLE" CssClass="btn" OnClick="btnGuncelle_Click" />
                    <asp:Button runat="server" ID="btnSil" Text="SİL" CssClass="btn" OnClick="btnSil_Click" />
                </div>
                <div class="box dDown">
                    <p>
                        Paket Seç
                    </p>
                    <asp:DropDownList runat="server" ID="dDownList" CssClass="ddList" OnSelectedIndexChanged="dDownListPaketler_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                    <p>
                        **Bu alan sadece güncelleme ve silme işlemlerinde kullanılabilir.
                    </p>
                    <p>
                        Paket ID : <asp:Label runat="server" ID="lblID"></asp:Label>
                    </p>
                </div>
            </div>
        </div>
    </div>


</asp:Content>
