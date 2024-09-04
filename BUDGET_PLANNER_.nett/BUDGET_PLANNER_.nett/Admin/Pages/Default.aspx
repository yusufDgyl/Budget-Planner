<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPages/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BUDGET_PLANNER_.nett.Admin.Pages.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="../Styles/DefaultStyle.css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="gorusme-getir-duzenle">
        <div class="gorusme-container">
            <h2>PAKET</h2>
            <div class="flex-item">
                <div>
                    <a href="PaketDuzenle.aspx">
                        <img src="../Images/arti.png" />
                    </a>
                    <h2>EKLE</h2>
                </div>
                <div>
                    <a href="PaketListeleme.aspx">
                        <img src="../Images/buyutec.png" />
                    </a>
                    <h2>BUL</h2>
                </div>
            </div>
        </div>
        <div class="gorusme-container">
            <h2>KULLANICI</h2>
            <div class="flex-item">
                <div>
                    <a href="KullaniciDuzenle.aspx">
                        <img src="../Images/arti.png" />
                    </a>
                    <h2>EKLE</h2>
                </div>
                <div>
                    <a href="KullaniciListeleme.aspx">
                        <img src="../Images/buyutec.png" />
                    </a>
                    <h2>BUL</h2>
                </div>
            </div>
        </div>

    </div>

</asp:Content>
