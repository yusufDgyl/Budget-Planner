<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/BP_MasterPage.Master" AutoEventWireup="true" CodeBehind="BP_IsletmeGecisYap.aspx.cs" Inherits="BUDGET_PLANNER_.nett.Pages.BP_IsletmeGecisYapp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="../Styles/BP_IsletmeGecisYapStyle.css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1 class="isletme-sec-baslik">İşletme Seç</h1>


    <div class="box-container">
        <asp:DataList runat="server" ID="dListIsletme">
            <ItemTemplate>
                <div class="box">
                    <div class="icon">
                        <i class="fa-solid fa-business-time"></i>
                    </div>
                    <div>
                        <label><span>İşletme Adı:</span> <%# Eval("isletme_adi")  %></label>
                    </div>
                    <div>
                        <label><span>İşletme Açıklaması:</span> <%# Eval("isletme_aciklama")  %></label>
                    </div>
                    <div>
                        <label><span>İşletme Tür:</span> <%# Eval("isletme_tur")  %></label>
                    </div>
                    <div>
                        <label><span>Defter Adı:</span> <%# Eval("def_adi")  %></label>
                    </div>
                    <div>
                        <label><span>Defter Açıklaması:</span> <%# Eval("def_aciklama")  %></label>
                    </div>
                    <div class="button-container">
                        <a class="btn-sec" href="BP_Anasayfa.aspx?ID=<%#Eval("isletme_id")%>">Seç</a>
                    </div>
                </div>
            </ItemTemplate>
        </asp:DataList>
    </div>

    <div class="isletme-ekle">
        <a onclick="ShowSure()">+</a>
    </div>

    <div class="emin-misin-container" id="eminMisin">
        <div class="emin-misin">
            <h2>Premium Fırsatlarından yararlan!</h2>
            <p>İşletme ekleyebilmen için premium üye olmalısın.</p>
            <div class="emin-misin-btn-group">
                <a class="btn-emin-misin" href="Paketler.aspx">YÖNLENDİR</a>
                <a class="btn-emin-misin" onclick="CloseSure()">İPTAL</a>
            </div>
        </div>
    </div>


    <script>

        window.onload = function () {
            var link = document.querySelector("#isletme-gecis");
            link.classList.toggle("active-menu-item");
        }

        function ShowSure() {
            var link = document.getElementById("eminMisin");
            link.style.display = "flex";
        }
        function CloseSure() {
            var link = document.getElementById("eminMisin");
            link.style.display = "none";
        }
    </script>

</asp:Content>
