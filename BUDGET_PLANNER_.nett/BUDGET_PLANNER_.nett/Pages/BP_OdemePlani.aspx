<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/BP_MasterPage.Master" AutoEventWireup="true" CodeBehind="BP_OdemePlani.aspx.cs" Inherits="BUDGET_PLANNER_.nett.Pages.BP_OdemePlani" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/BP_OdemePlaniStyle.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="premium-info-container">
        <div class="premium-info">
            <h1>Paketini Premium'a Yükselt!</h1>
            <p>Ayda 9.99$ ödeyerek premium fırsatlarından yararlan.</p>
            <a>Premium'u Edin</a>
        </div>
    </div>

    <div class="premium-avantaj-container">
        <h1 style="text-align: center; font-weight: 800; font-size: 40px;">Premium Avantajları</h1>
        <div class="premium-avantajlari">
            <div class="premium-avantaj">
                <i class="fa-solid fa-book"></i>
                <h2>Daha fazla defter!</h2>
                <p>Daha fazla defter ekleyerek işletmelerini yönet.</p>
            </div>
            <div class="premium-avantaj">
                <i class="fa-solid fa-briefcase"></i>
                <h2>1 Defterin 3 işletme imkanı!</h2>
                <p>Aynı defterde 1'den fazla işletmenin bütçesini planla.</p>
            </div>
            <div class="premium-avantaj">
                <i class="fa-solid fa-rocket"></i>
                <h2>Notlarını daha fonksiyonlu hale getir!</h2>
                <p>Notlarını istersen zamanla , otomatik işlem yaptır ya da dilediğin gibi kullan.</p>
            </div>
        </div>
    </div>

    <div class="premium-info-container">
        <div class="premium-info">
            <h1>Paketini Premium'a Yükselt!</h1>
            <p>Ayda 9.99$ ödeyerek premium fırsatlarından yararlan.</p>
            <a>Premium'u Edin</a>
        </div>
    </div>


    <script>

        window.onload = function () {
            var link = document.querySelector("#ayarlar");
            link.classList.toggle("active-menu-item");
        }
    </script>
</asp:Content>
